using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// Neural Network Class
namespace NetworkBeta
{
    static public class Extensions
    {
        public static class ThreadSafeRandom
        {
            [ThreadStatic] private static Random Local;

            public static Random ThisThreadsRandom
            {
                get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
            }
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        /// <summary>
        /// Emulate Python's Dot Product for Matrix * Vector 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        static public Vector<double> Dot(this Matrix<double> m, Vector<double> v)
        {
            Vector<double> result = null;
            if (m.RowCount == v.Count)
            {
                result = DenseVector.Build.Dense(m.ColumnCount);
                var ca = m.ToColumnArrays();
                //for ( int i = 0; i < result.Count; ++i  )
                Parallel.For(0, result.Count, (int i) =>
                {
                    var cav = DenseVector.Build.Dense(ca[i]);
                    result[i] = cav * v;
                });
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(String.Format("Matrix({0},{1}) rows must equal vector({2}) count", m.RowCount, m.ColumnCount, v.Count));
            }
            return result;
        }

        static public bool TestDot()
        {
            bool result = false;
            double[] p1 = { 1, 2 };
            double[,] p2 = { { 3, 4 }, { 5, 6 } };
            var v = DenseVector.Build.Dense(p1);
            var m = DenseMatrix.Build.DenseOfArray(p2);
            var d = m.Dot(v);
            if (d[0] == 13 && d[1] == 16)
            {
                result = true;
            }
            return result;
        }
    }
    public class TrainingData
    {
        public Vector<double> data { get; set; }
        public Vector<double> label { get; set; }

        public TrainingData(Vector<double> myData, Vector<double> myLabel)
        {
            data = myData;
            label = myLabel;
        }

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

        public double Activation
        {
            get
            {
                return Parent.Activations[NeuronID];
            }
            set
            {
                Parent.Activations[NeuronID] = value;
            }
        }
    }

    public class Layer
    {
        public const int InputLayerID = 0;
        public Layer PreviousLayer { get; set; }
        public Layer NextLayer { get; set; }

        public Vector<double> Activations { get; set; }
        public Vector<double> Biases { get; set; }
        public Matrix<double> Weights { get; set; }
        public Vector<double> Z { get; set; }
        public Vector<double> Error { get; set; }

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
            // Extensions.TestDot();
            if (PreviousLayer == null)
            {
                // Input Layer,  just need activations for input values
                Activations = DenseVector.Build.Dense(Neurons.Count(), 0.0);
            }
            else
            {
                // so setup connections between this and the previous layer
                PreviousLayer.NextLayer = this;
                Activations = DenseVector.Build.Dense(Neurons.Count());
                Biases = DenseVector.Build.Dense(Neurons.Count(), 0.5);
                // activation weights,  one row per previous layer neurons, columns = this layer neurons
                Weights = DenseMatrix.Build.Dense(PreviousLayer.Neurons.Count(), Neurons.Count(), 1.0);
                GradientWeights = DenseMatrix.Build.Dense(PreviousLayer.Neurons.Count(), Neurons.Count(), 0);
                GradientBiases = DenseVector.Build.Random(Neurons.Count());

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
#endif
            }
        }

        public void CalcActivation()
        {
            // first layer is input layer so activations don't get updated
            if (PreviousLayer != null)
            {
                Z = Weights.Dot(PreviousLayer.Activations) + Biases;
                Activations = NeuralNetwork.Sigmoid(Z);
            }
        }

    }

    public class NeuralNetwork
    {
        public Action<string> Log { get; set; }
        public List<Layer> Layers { get; set; }

        public NeuralNetwork()
        {
            Layers = new List<Layer>();
        }

        public void AddLayer(int neuronCount)
        {
            Layers.Add(new Layer(neuronCount, Layers.LastOrDefault()));
        }

        public void TrainingTest(List<TrainingData> trainingData)
        {
            update(trainingData, learningRate: 1.0);
        }

        public void Train(List<TrainingData> trainingData, int epochs, int batchSize, double learningRate, bool includeTestData)
        {
            StochasticGradientDescent(trainingData, epochs, batchSize, learningRate, includeTestData);
        }

        void StochasticGradientDescent(List<TrainingData> trainingData, int epochs, int batchSize, double learningRate, bool includeTestData)
        {
            for (int epoch = 0; epoch < epochs; ++epoch)
            {
                var batchData = trainingData.GetRange(0, batchSize);
                update(batchData, learningRate);
                trainingData.Shuffle();
                Log?.Invoke(String.Format("Completed epoch {0}", epoch));
            }
        }

        void update(List<TrainingData> batchData, double learningRate)
        {
            foreach (var batch in batchData)
            {
                // feed forward
                Layers.First().Activations = batch.data;
                foreach (var layer in Layers)
                {
                    layer.CalcActivation();
                }

                // back propagate
                // start at the last layer and don't do the first layer
                for (int i = Layers.Count - 1; i > 0; --i)
                {
                    backPropagation(Layers[i], batch.label);
                }
            }
        }

        void backPropagation(Layer layer, Vector<double> label)
        {
            try
            {
                // layer error : (yHat - y ) * Sigmoid'(Z)
                layer.Error = (layer.Activations - label) * SigmoidPrime(layer.Z);

                // cost derivative for weights
                var deltaM = DenseMatrix.Build.DenseOfColumnVectors(layer.Error);
                var act = DenseMatrix.Build.DenseOfColumnVectors(layer.PreviousLayer.Activations);
                layer.GradientWeights = deltaM * act.Transpose();

                var sp = SigmoidPrime(Layers[1].Activations);
                var bm = (Layers[2].Weights.Transpose() * deltaM) * sp;
            }
            catch
            {
                Log?.Invoke("not yet");
            }
        }

        void updateParameters(Layer layer, Matrix<double> deltaM)
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
