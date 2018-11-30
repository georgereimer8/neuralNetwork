using MathNet.Numerics.LinearAlgebra.Double;
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
        public Action<string> Log { get; set; }
        public Action<List<Layer>> DisplayLayers { get; set; }
        public Action<int> UpdateCurrentImage { get; set; }
        public Action<int> ShowCurrentEpoch { get; set; }

        public List<Layer> Layers { get; set; }
        public double Epochs { get; set; }

        public NeuralNetwork( )
        {
            Layers = new List<Layer>();
        }

        public void AddLayer( int neuronCount )
        {
            Layers.Add(new Layer(neuronCount, Layers.LastOrDefault(), Layers.Count));
        }

        public void TrainingTest( List<NetworkData> trainingData )
        {
            try
            {
                update(trainingData, learningRate: 1.0);
            }
            catch
            {
                Log?.Invoke(String.Format("Training Test failed"));
            }
        }

        public void Train(List<NetworkData> trainingData, List<NetworkData> testingData, int epochs, int batchSize, double learningRate)
        {
            try
            {
                StochasticGradientDescent(trainingData, testingData, epochs, batchSize, learningRate);
            }
            catch (System.Exception ex)
            {
                Log?.Invoke(String.Format("Training failed: {0}", ex.Message));
            }
        }

        void StochasticGradientDescent( List<NetworkData>trainingData, List<NetworkData> testingData, int epochs, int batchSize, double learningRate )
        {
            for (int epoch = 0; epoch < epochs; ++epoch)
            {
                var batchData = trainingData.GetRange(0, batchSize);
                update(batchData, learningRate);
                // trainingData.Shuffle();
                ShowCurrentEpoch?.Invoke(epoch);
                DisplayLayers?.Invoke(Layers);
                var correctCount = evaluate(testingData);
                Log?.Invoke(String.Format("Epoch #{0}: {1}/{2}", epoch, correctCount, testingData.Count())); 
            }
        }

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


        void update( List<NetworkData> batchData, double learningRate )
        {
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
                    var db = o * z; 
                    layer.deltaGradientBiases = (layer.Activations - label).PointwiseMultiply( Activation.SigmoidPrime(layer.Z)); // update output error
                    layer.deltaGradientWeights = layer.PreviousLayer.Activations.Dot(layer.deltaGradientBiases);
                }
                else
                {
                    // hidden layers
                    layer.deltaGradientBiases = layer.NextLayer.Weights.Transpose().Dot(layer.NextLayer.GradientBiases).PointwiseMultiply( Activation.SigmoidPrime(layer.Z)); // update output error
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

        void calcCost( Layer layer)
        {
            layer.Biases.Add(layer.GradientBiases);
            layer.Weights.Add(layer.GradientWeights);
            return; 
            // TODO implement cost and gradient descent test4
            layer.Costs = layer.Error.PointwiseMultiply(layer.Activations);
            // cost derivative for weights
            var deltaM = DenseMatrix.Build.DenseOfColumnVectors(layer.Error);
            var act = DenseMatrix.Build.DenseOfColumnVectors(layer.PreviousLayer.Activations);
            layer.GradientWeights = deltaM * act.Transpose();

            //var dw = learningRate * layer.GradientWeights;
            //layer.Weights -= dw.Transpose();
            //layer.Weights -= (learningRate * layer.GradientWeights).Transpose();
        }

        void updateParameters( Layer layer, Matrix<double> deltaM )
        {

        }

    }
}
