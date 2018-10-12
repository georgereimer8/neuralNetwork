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
        public TrainingData(double[] myValues, string myLabel)
        {
            data = DenseVector.Build.Dense(myValues);
            label = DenseVector.Build.Dense(toArray(myLabel));
        }
        double[] toArray(string label)
        {
            double[] result = new double[10];
            var value = int.Parse(label);
            result[value] = 1;
            return result;
        }
    }
    public class Neuron
    {
        public double Input
        {
            get
            {
                return Parent.Inputs[Index];
            }
            set
            {
                Parent.Inputs[Index] = value;
            }

        }
        public Layer Parent { get; set; }
        public int Index { get; set; }
        public Neuron(int me, Layer myParent)
        {
            Index = me;
            Parent = myParent;
        }
    }

    public class Layer
    {
        public Layer PreviousLayer { get; set; }
        public Layer NextLayer { get; set; }
        public Vector<double> Inputs { get; set; }
        public Vector<double> Biases { get; set; }
        public Vector<double> Activation { get; set; }
        public Vector<double> Z { get; set; }
        public Matrix<double> Weights { get; set; }
        

        public List<Neuron> Neurons;
        public Layer(int myNeuronCount, Layer myPreviousLayer)
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
                Inputs = DenseVector.Build.Dense(Neurons.Count());
                Activation = DenseVector.Build.Dense(Neurons.Count());
                Biases = DenseVector.Build.Dense(Neurons.Count(), 0);
                // one input, one output
                Weights = DenseMatrix.Build.Dense(1,Neurons.Count(), 0);

            }
            else
            {
                // connections are a view backwards to previous layer
                // so setup connections between this and the previous layer
                PreviousLayer.NextLayer = this;
                Inputs = DenseVector.Build.Dense(PreviousLayer.Neurons.Count());
                Activation = DenseVector.Build.Dense(Neurons.Count());
                // activation weights,  one row per neurons
                Weights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(), 0);
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
                    weightValues.Add(i + 1); // test weights are 1,2,3...
                }
                Biases = DenseVector.Build.Dense(biasValues.ToArray());
                Weights = DenseMatrix.Build.Dense(PreviousLayer.Neurons.Count(), Neurons.Count(), (i, j) => i + j);

                var weightVector = DenseVector.Build.Dense(weightValues.ToArray());
                Weights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count());
                if (Weights.RowCount > 1)
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
                Weights = DenseMatrix.Build.Random(Neurons.Count(), PrevioActivationusLayer.Neurons.Count());
#endif
            }
        }
        
        public void CalcActivation()
        {  
            var h = Weights * PreviousLayer.Activation;
            var k = h + Biases;
            Z = (Weights * PreviousLayer.Activation )- Biases;
            Activation = NeuralNetwork.Sigmoid(Z);
        }

    } 

    public class NeuralNetwork
    {
        public Action<string> Log { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Vector<double>> Activations { get; set; }
        public NeuralNetwork( )
        {
            Layers = new List<Layer>();
            Activations = new List<Vector<double>>();
        }

        public void AddLayer( int neuronCount )
        {
            if( Layers.Count == 0 )
            {
                // first layer is input layer
                Layers.Add(new Layer(neuronCount, null ));
            }
            else
            {
                Layers.Add(new Layer( neuronCount, Layers.Last())); 
            }
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
            Layer hiddenLayer = Layers[1]; // TODO: this code only does one layer, expand to do all
            var biasGradient = DenseVector.Build.Dense(hiddenLayer.NextLayer.Neurons.Count(),0);
            var weightGradient = DenseMatrix.Build.Dense(hiddenLayer.Weights.RowCount, hiddenLayer.Weights.ColumnCount, 0);

            foreach (var batch in batchData)
            {
                backPropagation(hiddenLayer, batch, ref biasGradient, ref weightGradient);
            }
        }

        void backPropagation( Layer layer, TrainingData batch, ref Vector<double> biasGradient, ref Matrix<double> weightGradient )
        {
            Layers[0].Inputs = batch.data;
            //Layers[0].CalcActivation();

            //Layers[1].Inputs.SetValues(Layers[0].Activation.ToArray());
            Layers[1].Inputs = batch.data;
            Layers[1].CalcActivation();
            Activations.Add(Layers[1].Activation); 
            

            Layers[2].Inputs.SetValues(Layers[1].Activation.ToArray());
            Layers[2].CalcActivation();
            Activations.Add(Layers[2].Activation);

            // TODO: implement cost functior


            // cost derivative
            var delta = (Layers[2].Activation - batch.label) * SigmoidPrime(Layers[2].Z);
            Layers[2].Biases = delta;

            var deltaM = DenseMatrix.Build.DenseOfColumnVectors(delta);

            var act = DenseMatrix.Build.DenseOfColumnVectors(Layers[1].Activation);
            Layers[2].Weights = deltaM * act.Transpose(); 

            var sp = SigmoidPrime(Layers[2].Activation);
            var bm = (Layers[2].Weights.Transpose() * deltaM) * sp;
            Layers[2].Biases = bm.Column(0);
            Layers[2].Weights = deltaM * act.Transpose() * sp;
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
