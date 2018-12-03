﻿using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Neural Network Class
namespace Network
{
    public class NeuralNetwork
    {
        public Action<string>Log { get; set; }
        public Action<List<Layer>> DisplayLayers { get; set; }
        public Action<int> UpdateCurrentImage { get; set; }
        public Action<int> ShowCurrentEpoch { get; set; }
        public Action<double> ShowAccuracy { get; set; }

        public List<Layer> Layers { get; set; }
        public double Epochs { get; set; }

        public bool TestEachEpoch { get; set; }
        bool stop = false;
        public bool Stop
        {
            get { return stop; }
            set { stop = value; }
        }

        public NeuralNetwork( )
        {
            Layers = new List<Layer>();
        }

        /// <summary>
        /// Layers connect themselves to previous layers as they are added
        /// First layer becomes input layer, last layer is output layer
        /// </summary>
        /// <param name="neuronCount"></param>
        public void AddLayer( int neuronCount )
        {
            Layers.Add(new Layer(neuronCount, Layers.LastOrDefault(), Layers.Count));
        }

        /// <summary>
        /// Train the network using the training data and using the hyper parameters
        /// </summary>
        /// <param name="trainingData"></param>
        /// <param name="testingData"></param>
        /// <param name="epochs"></param>
        /// <param name="batchSize"></param>
        /// <param name="learningRate"></param>
        public void Train(List<NetworkData> trainingData, List<NetworkData> testingData, int epochs, int batchSize, double learningRate)
        {
            Log?.Invoke("Training Started");
            try
            {
                StochasticGradientDescent(trainingData, testingData, epochs, batchSize, learningRate);
            }
            catch (System.Exception ex)
            {
                Log?.Invoke(String.Format("Training failed: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Stochastic descent uses batches of the training data at a time to train instead of the entire training set
        /// </summary>
        /// <param name="trainingData"></param>
        /// <param name="testingData"></param>
        /// <param name="epochs"></param>
        /// <param name="batchSize"></param>
        /// <param name="learningRate"></param>
        void StochasticGradientDescent( List<NetworkData>trainingData, List<NetworkData> testingData, int epochs, int batchSize, double learningRate )
        {
            int batchIndex = 0;
            int correctCount = 0;
            for (int epoch = 0; epoch < epochs; ++epoch)
            {
                if( Stop == true )
                {
                    Log?.Invoke("Training Stopped");
                    break;
                }
                var batchData = trainingData.GetRange(batchIndex, batchSize);
                update(batchData, learningRate);
                trainingData.Shuffle();
                ShowCurrentEpoch?.Invoke(epoch);
                DisplayLayers?.Invoke(Layers);

                if (TestEachEpoch)
                {
                    correctCount = evaluate(testingData);
                    ShowAccuracy?.Invoke(((double)correctCount / (double)testingData.Count()) * 100.0);
                    Log?.Invoke(String.Format("Epoch #{0}: {1}/{2}", epoch, correctCount, testingData.Count()));
                }
                else
                {
                    Log?.Invoke(String.Format("Epoch #{0}", epoch));
                }
                batchIndex += 10;
            }
            correctCount = evaluate(testingData);
            ShowAccuracy?.Invoke(((double)correctCount / (double)testingData.Count()) * 100.0);
            Log?.Invoke(String.Format("Epoch #{0}: {1}/{2}", epochs, correctCount, testingData.Count()));
        }

        /// <summary>
        /// Apply the test data to the current weights and biases
        /// and evaluate their performance
        /// </summary>
        /// <param name="testingData"></param>
        /// <returns></returns>
        int evaluate(List<NetworkData> testingData)
        {
            int correctCount = 0;
            foreach (var networkData in testingData)
            {
                Layers.First().Activations = networkData.data;
                foreach (var layer in Layers)
                {
                    layer.CalcActivation();
                }
                if( Layers.Last().Activations.MaximumIndex() == networkData.label.MaximumIndex())
                {
                    ++correctCount;
                }
            }
            return correctCount;
        } 

        void clearGradients()
        {
            foreach( var layer in Layers )
            {
                if (layer.PreviousLayer != null)
                {
                    layer.GradientBiases.Clear();
                    layer.GradientWeights.Clear();
                }
            }
        }

        /// <summary>
        /// Apply the batch to training data
        ///     1. Feed forward
        ///     2. back propagate
        ///     3. update via gradient descent
        /// </summary>
        /// <param name="batchData"></param>
        /// <param name="learningRate"></param>
        void update( List<NetworkData> batchData, double learningRate )
        {
            clearGradients();
            foreach (var batch in batchData)
            {
                UpdateCurrentImage?.Invoke(batch.Index);
                // feed forward
                Layers.First().Activations = batch.data;
                foreach(var layer in Layers)
                {
                    layer.CalcActivation();
                }

                // back propagate
                // start at the last layer and don't do the first layer
                for( int i = Layers.Count-1; i > 0; --i )
                {
                    backPropagation(Layers[i], batch.label);
                }

                foreach (var layer in Layers)
                {
                    // skip input layer
                    if (layer.PreviousLayer != null)
                    {
                        // update gradients
                        layer.GradientBiases = layer.GradientBiases.Add(layer.deltaGradientBiases);
                        layer.GradientWeights = layer.GradientWeights.Add(layer.deltaGradientWeights);
                    }
                }
            }

            gradientDescent( learningRate / batchData.Count);
        }

        /// <summary>
        /// Apply the bias/weights to as per their corresponding gradients and the learning rate
        /// </summary>
        /// <param name="eta"></param>
        void gradientDescent( double eta )
        {
            foreach( var layer in Layers )
            {
                if( layer.PreviousLayer != null )
                {
                    layer.Biases = layer.Biases - eta * layer.GradientBiases;
                    layer.Weights = layer.Weights - eta * layer.GradientWeights;
                }
            }
        }

        /// <summary>
        ///  Back propagate the layer errors 
        ///  from the outside back towards the input layer
        ///  using the chain rule
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        bool backPropagation( Layer layer, Vector<double> label)
        {
            bool result = false;
            try
            {
                if (layer.NextLayer == null)
                {
                    // output layer
                    var o = (layer.Activations - label);
                    var z = Activation.SigmoidPrime(layer.Z);
                    var db = o.PointwiseMultiply( z); 
                    layer.deltaGradientBiases = (layer.Activations - label).PointwiseMultiply( Activation.SigmoidPrime(layer.Z)); // update output error
                    layer.deltaGradientWeights = layer.PreviousLayer.Activations.Dot(layer.deltaGradientBiases);
                }
                else
                {
                    // hidden layers
                    layer.deltaGradientBiases = layer.NextLayer.Weights.Transpose().Dot(layer.NextLayer.deltaGradientBiases).PointwiseMultiply( Activation.SigmoidPrime(layer.Z)); // update output error
                    layer.deltaGradientWeights = layer.PreviousLayer.Activations.Dot(layer.deltaGradientBiases);
                }
                result = true;
            }
            catch( System.ArgumentOutOfRangeException ex)
            {
                Log?.Invoke(String.Format("Backpropagation exception in layer #{0}: {1}", layer.Index, ex.Message));
                throw;
            }
            return result;
        }
    }
}
