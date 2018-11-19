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

        public List<Layer> Layers { get; set; }
        public double LearningRate { get; set; }
        public double Epochs { get; set; }

        public NeuralNetwork( )
        {
            Layers = new List<Layer>();
        }

        public void AddLayer( int neuronCount )
        {
            Layers.Add(new Layer(neuronCount, Layers.LastOrDefault()));
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
                trainingData.Shuffle();
                Log?.Invoke(String.Format("Completed epoch {0}",epoch));
            }
        }

        void update( List<TrainingData> batchData, double learningRate )
        {
            foreach (var batch in batchData)
            {
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
        }

        bool backPropagation( Layer layer, Vector<double> label)
        {
            bool result = false;
            try
            {
                if( layer.NextLayer == null )
                {
                    // output layer
                    layer.Error = (layer.Activations - label) * Activation.SigmoidPrime(layer.Z);
                }
                else
                {
                    // hidden layers
                    layer.Error = layer.NextLayer.Error * layer.Weights * Activation.SigmoidPrime(layer.Z);
                }

                layer.Costs = layer.Error.PointwiseMultiply( layer.Activations );
                // cost derivative for weights
                var deltaM = DenseMatrix.Build.DenseOfColumnVectors(layer.Error);
                var act = DenseMatrix.Build.DenseOfColumnVectors(layer.PreviousLayer.Activations);
                layer.GradientWeights = deltaM * act.Transpose();

                var dw = LearningRate * layer.GradientWeights;
                layer.Weights -= dw.Transpose();
                layer.Weights -= (LearningRate * layer.GradientWeights).Transpose();

                result = true;
            }
            catch( System.ArgumentOutOfRangeException ex)
            {
                Log?.Invoke(String.Format("Backpropagation exception: {0}", ex.Message));
                throw;
            }
            return result;
        }

        void updateParameters( Layer layer, Matrix<double> deltaM )
        {

        }

    }
}
