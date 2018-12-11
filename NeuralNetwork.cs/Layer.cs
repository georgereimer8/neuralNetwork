using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Text;
using System.IO;

namespace Network
{
    /// <summary>
    /// Layers for a neural network
    /// </summary>
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

        public Vector<double> GradientBiases { get; set; }
        public Matrix<double> GradientWeights { get; set; }

        public Vector<double> deltaGradientBiases { get; set; }
        public Matrix<double> deltaGradientWeights { get; set; }
        public string Name { get; set; }
        public bool Shuffle { get; set; }

        public List<Neuron> Neurons;
        public Layer( string myName, int myNeuronCount, Layer myPreviousLayer, int myIndex, bool myShuffle)
        {
            Index = myIndex;
            Name = myName;
            Shuffle = myShuffle;
            Neurons = new List<Neuron>();
            for (int i = 0; i < myNeuronCount; ++i)
            {
                Neurons.Add(new Neuron(i, this));
            }
            PreviousLayer = myPreviousLayer;
            Init();
        }
        public Layer(string folderPath, string myName, Layer myPreviousLayer, int myIndex, bool myShuffle)
        {
            Index = myIndex;
            Name = myName;
            Shuffle = myShuffle;
            PreviousLayer = myPreviousLayer;

            if (Load(folderPath) == true)
            {
                Neurons = new List<Neuron>();
                for (int i = 0; i < Activations.Count; ++i)
                {
                    Neurons.Add(new Neuron(i, this));
                }
                if (PreviousLayer != null)
                {
                    // so setup connections between this and the previous layer
                    PreviousLayer.NextLayer = this;
                    // activation weights,  one row per previous layer neurons, columns = this layer neurons
                    GradientWeights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(), 0);
                    GradientBiases = DenseVector.Build.Dense(Neurons.Count());
                }
            }
        } 

        public void Save( string folderPath )
        {
            string layerPath = folderPath + "\\" + Name;
            Directory.CreateDirectory(layerPath);

            if (Activations != null)
            {
                Matrix<double> a = DenseMatrix.Build.DenseOfRowVectors(Activations);
                var activationsFilePath = String.Format("{0}\\Activations.csv", layerPath);
                DelimitedWriter.Write(activationsFilePath, a, ",");
            }

            if (Biases != null)
            {
                Matrix<double> bm = DenseMatrix.Build.DenseOfRowVectors(Biases);
                var biasesFilePath = String.Format("{0}\\Biases.csv", layerPath);
                DelimitedWriter.Write(biasesFilePath, bm, ",");
            }

            if (Weights != null)
            {
                var weightsFilePath = String.Format("{0}\\Weights.csv", layerPath);
                DelimitedWriter.Write(weightsFilePath, Weights, ",");
            }
        }
        public bool Load(string folderPath)
        {
            bool result = false;
            string layerPath = folderPath;
            if (Directory.Exists(folderPath) == true)
            {

                var activationsFilePath = String.Format("{0}\\Activations.csv", layerPath);
                if (File.Exists(activationsFilePath))
                {
                    Matrix<double> a = DelimitedReader.Read<double>(activationsFilePath, sparse: false, delimiter: ",");
                    var arrays = a.ToRowArrays();
                    Activations = DenseVector.Build.DenseOfArray(arrays[0]);
                }
                else throw new System.IO.DirectoryNotFoundException(activationsFilePath);

                if (Name != "Input")
                {
                    var biasesFilePath = String.Format("{0}\\Biases.csv", layerPath);
                    if (File.Exists(biasesFilePath))
                    {
                        Matrix<double> a = DelimitedReader.Read<double>(biasesFilePath, sparse: false, delimiter: ",");
                        var arrays = a.ToRowArrays();
                        Biases = DenseVector.Build.DenseOfArray(arrays[0]);
                    }
                    else throw new System.IO.DirectoryNotFoundException(biasesFilePath);

                    var weightsFilePath = String.Format("{0}\\Weights.csv", layerPath);
                    if (File.Exists(weightsFilePath))
                    {
                        Weights = DelimitedReader.Read<double>(weightsFilePath, sparse: false, delimiter: ",");
                    }
                    else throw new System.IO.DirectoryNotFoundException(weightsFilePath);
                }
                result = true;
            }
            else throw new System.IO.DirectoryNotFoundException(folderPath);
            return result;
        } 


        /// <summary>
        /// initialize a new layer
        /// special attention paid to first layer as it is the input layer
        /// </summary>
        public void Init()
        {
            // Input Layer only needs activations for input values
            Activations = DenseVector.Build.Dense(Neurons.Count(), 0.0);
            if (PreviousLayer != null)
            {
                // so setup connections between this and the previous layer
                PreviousLayer.NextLayer = this;

                // activation weights,  one row per previous layer neurons, columns = this layer neurons
                GradientWeights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(), 0);
                GradientBiases = DenseVector.Build.Dense(Neurons.Count());

                // use shuffle semaphore for zero init for testing the network with deterministic values
                if (Shuffle == true)
                {
                    Biases = DenseVector.Build.Random(Neurons.Count());
                    Weights = DenseMatrix.Build.Random(Neurons.Count(), PreviousLayer.Neurons.Count());
                }
                else
                { 
                    Biases = DenseVector.Build.Dense(Neurons.Count(),0.0);
                    Weights = DenseMatrix.Build.Dense(Neurons.Count(), PreviousLayer.Neurons.Count(),0.0);
                }
            }
        }

        /// <summary>
        /// Apply the layer's activation function
        /// </summary>
        public void CalcActivation()
        {
            // first layer is input layer so activations don't get updated
            if (PreviousLayer != null)
            {
                Z = ( Weights * PreviousLayer.Activations) + Biases;
                // Z = Weights.Dot(PreviousLayer.Activations) + Biases;
                Activations = Activation.Sigmoid(Z);
            }
        }

        public string printActivations( int sampleNumber )
        {
            var s = String.Format("{0},", sampleNumber);
            foreach (var a in Activations)
            {
                s += String.Format("{0:0.00000000},", a);
            }
            s += Environment.NewLine;
            return s;
        }

        override public string ToString()
        {
            string s;
            s = String.Format("Layer({0}) -----------", Name) + Environment.NewLine;
            s += String.Format("           Activations:{0}", Activations) + Environment.NewLine;
            s += String.Format("                Biases:{0}", Biases) + Environment.NewLine;
            s += String.Format("               Weights:{0}", Weights) + Environment.NewLine;
            s += String.Format("        GradientBiases:{0}", GradientBiases) + Environment.NewLine;
            s += String.Format("       GradientWeights:{0}", GradientWeights) + Environment.NewLine;
            s += String.Format("   deltaGradientBiases:{0}", deltaGradientBiases) + Environment.NewLine;
            s += String.Format("  deltaGradientWeights:{0}", deltaGradientWeights) + Environment.NewLine;
            s += Environment.NewLine;

            return s;
        }
    }
}
