using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;

namespace Network
{
    public class Layer
    {
        public const int InputLayerID = 0;
        public Layer PreviousLayer { get; set; }
        public Layer NextLayer { get; set; }
        public int Index { get; set; }

        public Vector<double> Activations { get; set; }
        public Vector<double> Biases { get; set; }
        public Matrix<double> Weights { get; set; }
        public Vector<double> Z { get; set; } // weighted neuron input
        public Vector<double> Error { get; set; }
        public Vector<double> Costs { get; set; }

        public Vector<double> GradientBiases { get; set; }
        public Matrix<double> GradientWeights { get; set; }


        public List<Neuron> Neurons;
        public Layer(int myNeuronCount, Layer myPreviousLayer, int myIndex)
        {
            Index = myIndex;
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
                // Input Layer,  just need activations for input values
                Activations = DenseVector.Build.Dense(Neurons.Count(), 0.0);
            }
            else
            {
                // so setup connections between this and the previous layer
                PreviousLayer.NextLayer = this;
                Activations = DenseVector.Build.Dense(Neurons.Count());
                // Biases = DenseVector.Build.Random(Neurons.Count());
                Biases = DenseVector.Build.Dense(Neurons.Count());
                Costs = DenseVector.Build.Dense(Neurons.Count());

                // activation weights,  one row per previous layer neurons, columns = this layer neurons
               // Weights = DenseMatrix.Build.Random(Neurons.Count(), PreviousLayer.Neurons.Count());
                Weights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count());
                GradientWeights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(), 0);
                GradientBiases = DenseVector.Build.Dense(Neurons.Count());
            }
        }

        public void CalcActivation()
        {
            // first layer is input layer so activations don't get updated
            if (PreviousLayer != null)
            {
                Z = Weights.Dot(PreviousLayer.Activations) + Biases;
                Activations = Activation.Sigmoid(Z);
            }
        }

    }
}
