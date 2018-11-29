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
        public double LearningRate { get; set; }
        public double Epochs { get; set; }

        public NeuralNetwork( )
        {
            Layers = new List<Layer>();
        }

        public void AddLayer( int neuronCount )
        {
            Layers.Add(new Layer(neuronCount, Layers.LastOrDefault(), Layers.Count));
        }

        public void TrainingTest( List<TrainingData> trainingData )
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

        public void Train(List<TrainingData> trainingData, int epochs, int batchSize, double learningRate, bool includeTestData)
        {
            try
            {
                StochasticGradientDescent(trainingData, epochs, batchSize, learningRate, includeTestData);
            }
            catch (System.Exception ex)
            {
                Log?.Invoke(String.Format("Training failed: {0}", ex.Message));
            }
        }

        void StochasticGradientDescent( List<TrainingData>trainingData, int epochs, int batchSize, double learningRate, bool includeTestData )
        {
            for (int epoch = 0; epoch < epochs; ++epoch)
            {
                var batchData = trainingData.GetRange(0, batchSize);
                update(batchData, learningRate);
                // trainingData.Shuffle();
                ShowCurrentEpoch?.Invoke(epoch);
                DisplayLayers?.Invoke(Layers);
            }
        }

        void update( List<TrainingData> batchData, double learningRate )
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
            }

            gradientDescent( LearningRate / batchData.Count);
        }

        void gradientDescent( double eta )
        {
            //self.weights = [w - (eta / len(mini_batch)) * nw
            //            for w, nw in zip(self.weights, nabla_w)]
            //self.biases = [b - (eta / len(mini_batch)) * nb
            //           for b, nb in zip(self.biases, nabla_b)
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
                Vector<double> deltaGradientBiases;// = DenseVector.Build.Dense(layer.GradientBiases.Count);
                Matrix<double> deltaGradientWeights;// = DenseMatrix.Build.Dense(layer.GradientWeights.RowCount, layer.GradientWeights.ColumnCount);
                if (layer.NextLayer == null)
                {
                    // output layer
                    deltaGradientBiases = (layer.Activations - label) * Activation.SigmoidPrime(layer.Z); // update output error
                    deltaGradientWeights = layer.PreviousLayer.Activations.Dot(layer.GradientBiases);
                }
                else
                {
                    // hidden layers
                    deltaGradientBiases = layer.NextLayer.Weights.Transpose().Dot(layer.NextLayer.GradientBiases) * Activation.SigmoidPrime(layer.Z); // update output error
                    deltaGradientWeights = layer.PreviousLayer.Activations.Dot(deltaGradientBiases);
                }
                // update gradients
                layer.GradientBiases = layer.GradientBiases.Add(deltaGradientBiases);
                layer.GradientWeights = layer.GradientWeights.Add(deltaGradientWeights);
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

            //var dw = LearningRate * layer.GradientWeights;
            //layer.Weights -= dw.Transpose();
            layer.Weights -= (LearningRate * layer.GradientWeights).Transpose();
        }

        void updateParameters( Layer layer, Matrix<double> deltaM )
        {

        }

    }
}
