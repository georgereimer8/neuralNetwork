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
    public class TrainingData
    {
        public Vector<double> data { get; set; }
        public Vector<double> label { get; set; }
        public TrainingData(double[] myValues, string myLabel, int outputActivations)
        {
            data = DenseVector.Build.Dense(myValues);
            label = DenseVector.Build.Dense(toArray(myLabel, outputActivations));
        }
        double[] toArray(string label, int outputActivations)
        {
            double[] result = new double[outputActivations];
            var value = int.Parse(label);
            result[value] = 1;
            return result;
        }
    }
    public class Neuron
    {
        public Layer Parent { get; set; }
        public int NeuronID { get; set; }
        public Neuron(int myNeuronID, Layer myParent)
        {
            NeuronID = myNeuronID;
            Parent = myParent;
        }

        double activation;
        public double Activation
        {
            get
            {
                double value;
                if(Parent.Number == Layer.InputLayerID )
                {
                    value = activation;
                }
                else
                {
                    value = Parent.Activations[NeuronID];
                }
                return value;
            }

            set
            {
                if( Parent.Number == Layer.InputLayerID)
                {
                    activation = value; 
                }
                else
                {
                    Parent.Activations[NeuronID] = value;
                }
            }
        }
    }

    public class Layer
    {
        public const int InputLayerID = 0;
        public int Number { get; set; }
        public Layer PreviousLayer { get; set; }
        public Layer NextLayer { get; set; }

        public Vector<double> Activations { get; set; }
        public Vector<double> Biases { get; set; }
        public Matrix<double> Weights { get; set; }
        public Vector<double> Z { get; set; }

        public Vector<double> GradientBiases { get; set; }
        public Matrix<double> GradientWeights { get; set; }
        

        public List<Neuron> Neurons;
        public Layer(int myNeuronCount, Layer myPreviousLayer = null)
        {
            Neurons = new List<Neuron>();
            for (int i = 0; i < myNeuronCount; ++i)
            {
                Neurons.Add(new Neuron(i, this));
            }

            PreviousLayer = myPreviousLayer;
            Init();
        }

        public void Init()
        {
            if (PreviousLayer == null)
            {
                // setup default outputs, one per neuron, no bias, unity weight
                Activations = DenseVector.Build.Dense(Neurons.Count());
                Biases = DenseVector.Build.Dense(Neurons.Count(), 0);
                GradientBiases = DenseVector.Build.Dense(Neurons.Count(), 0);
                // one input, one output
                Weights = DenseMatrix.Build.Dense(1,Neurons.Count(), 0);
                GradientWeights = DenseMatrix.Build.Dense(1,Neurons.Count(), 0);

            }
            else
            {
                // connections are a view backwards to previous layer
                // so setup connections between this and the previous layer
                PreviousLayer.NextLayer = this;
                Activations = DenseVector.Build.Dense(Neurons.Count());
                // activation weights,  one row per neurons
                Weights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(), 0);
                GradientWeights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(), 0);
#if TEST_NETWORK_MATH
                // set biaes and weights equal to neuron number + 1
                List<double> biasValues = new List<double>();
                // one overall bias per neuron in current layer
                for(int i = 0; i < Neurons.Count(); ++i)
                {
                    biasValues.Add(0.5);
                }

                List<double> weightValues = new List<double>();
                // one overall bias per neuron in current layer
                // one weight per neuron in previous layer
                for(int i = 0; i < PreviousLayer.Neurons.Count(); ++i)
                {
                    PreviousLayer.Activations[i] = i + 1;
                    weightValues.Add(i + 1); // test weights are 1,2,3...
                }
                Biases = DenseVector.Build.Dense(biasValues.ToArray());
                Weights = DenseMatrix.Build.Dense(PreviousLayer.Neurons.Count(), Neurons.Count(), (i, j) => i + j);

                var weightVector = DenseVector.Build.Dense(weightValues.ToArray());
                Weights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count());
                if (Weights.RowCount >= 1)
                {
                    for (int i = 0; i < Neurons.Count; ++i)
                    {
                        // replace values
                        Weights = Weights.InsertRow(i, weightVector);
                        Weights = Weights.RemoveRow(i + 1);
                    }
                } 
                var w = Weights.ToString();
#else
                Biases = DenseVector.Build.Random(Neurons.Count());
                GradientBiases = DenseVector.Build.Random(Neurons.Count());
                Weights = DenseMatrix.Build.Random(Neurons.Count(), PrevioActivationusLayer.Neurons.Count());
                GradientWeights = DenseMatrix.Build.Random(Neurons.Count(), PrevioActivationusLayer.Neurons.Count());
#endif
            }
        }
        
        public void CalcActivation()
        {
            // first layer is input layer so activations don't get updated
            if (PreviousLayer != null)
            {
                var h = Weights * PreviousLayer.Activations;
                var k = h + Biases;
                Z = (Weights * PreviousLayer.Activations) - Biases;
                Activations = NeuralNetwork.Sigmoid(Z);
            }
        }

    } 

    public class NeuralNetwork
    {
        public Action<string> Log { get; set; }
        public List<Layer> Layers { get; set; }

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
            update(trainingData, learningRate: 1.0);
        }

        public void Train(List<TrainingData> trainingData, int epochs, int batchSize, double learningRate, bool includeTestData)
        {
            StochasticGradientDescent(trainingData, epochs, batchSize, learningRate, includeTestData);
        }

        void StochasticGradientDescent( List<TrainingData>trainingData, int epochs, int batchSize, double learningRate, bool includeTestData )
        {
            var testDataCount = 0;
            if (includeTestData)
            {
                //testDataCount = TODO:
            }

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
                Layers[Layer.InputLayerID].Activations = batch.data;
                foreach(var layer in Layers)
                {
                    layer.CalcActivation();
                }
                backPropagation( batch.label);
            }
        }

        void backPropagation( Vector<double> label)
        {
            try
            {
                // cost derivative
                var delta = (Layers[2].Activations - label) * SigmoidPrime(Layers[2].Z);
                Layers[2].GradientBiases = delta;

                var deltaM = DenseMatrix.Build.DenseOfColumnVectors(delta);

                var act = DenseMatrix.Build.DenseOfColumnVectors(Layers[1].Activations);
                Layers[2].GradientWeights = deltaM * act.Transpose();

                var sp = SigmoidPrime(Layers[1].Activations);
                var bm = (Layers[2].Weights.Transpose() * deltaM) * sp;
                Layers[1].GradientBiases = bm.Column(0);
                Layers[1].GradientWeights = deltaM * act.Transpose() * sp;
            }
            catch
            {
                Log?.Invoke("not yet");
            }
        }

        void updateParameters( Layer layer, Matrix<double> deltaM )
        {

        }
        static public Vector<double> Sigmoid(Vector<double> z)
        {
            return 1.0 / (1.0 + Vector.Exp(-z));
        }

        /// <summary>
        /// Derivative of the sigmoid function.
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        static public double SigmoidPrime(Vector<double> z)
        {
            return Sigmoid(z) * (1 - Sigmoid(z));
        }
    }
}
