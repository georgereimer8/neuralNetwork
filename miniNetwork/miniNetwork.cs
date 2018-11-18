using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniNetwork
{
    public class Layer
    {
        public const double DefaultWeight = 0.5;

        public double Weight { get; set; }
        public double Activation { get; set; }
        public double Error { get; set; }
        public double Cost { get; set; }

        public double Z { get; set; }
        public double WeightDerivative { get; set; }
        public Layer PrevLayer { get; set; }
        public Layer NextLayer { get; set; }
        public int ID { get; set; }

        public Layer()
        {
            Weight = DefaultWeight;
            Z = 0;
            Activation = 0;
            Error = 0;
            WeightDerivative = 0;
        }

        public void FeedForward()
        {
            Z = PrevLayer.Activation * Weight;
            Activation = Sigmoid(Z);
        }

        public void BackPropagateOutput( double target, double learningRate)
        {
            Error = Activation - target * SigmoidPrime(Z);
            Cost = Error * PrevLayer.Activation;
            WeightDerivative = Error * Activation;
            Weight -= learningRate * WeightDerivative;
        }

        public void BackPropagateHidden( double learningRate )
        {
            Error = NextLayer.Error * NextLayer.Weight * SigmoidPrime(Z);
            Cost = Error * PrevLayer.Activation;
            WeightDerivative = Error * Activation;
            Weight -= learningRate * WeightDerivative;
        }

        public double Sigmoid(double x)
        {
            //return 2 / (1 + Math.Exp(-2 * x)) - 1;
            return 1 / (1 + Math.Exp(-x));
        }

        /// <summary>
        /// Derivative of the sigmoid function.
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public double SigmoidPrime(double z)
        {
            //return 1 - (Math.Pow(Sigmoid(z), 2));
            return Sigmoid(z) * (1 - Sigmoid(z));
        }
    }

    public class MiniNetwork
    {
        const int DefaultLayerCount = 4;
        public Action<string> Log;
        public Action<List<Layer>> DisplayLayers;

        public int Input { get; set; }
        public int Target { get; set; }
        public double LearningRate { get; set; }
        public double Epochs { get; set; }
        List<Layer> layers = new List<Layer>();

        public MiniNetwork()
        {
            InitLayers(DefaultLayerCount);
        }

        public void Train()
        {
            InitLayers(DefaultLayerCount);
                for (int epoch = 0; epoch < Epochs; ++epoch)
                {
                    layers.First().Activation = Input;
                    for (int i = 1; i < layers.Count; ++i)
                    {
                        layers[i].FeedForward();
                    }

                    layers.Last().BackPropagateOutput(Target, LearningRate);
                    for (int i = layers.Count - 2; i > 0; --i)
                    {
                        layers[i].BackPropagateHidden(LearningRate);
                    }

                    Log?.Invoke(String.Format("Epoch {0}", epoch));
                    DisplayLayers?.Invoke(layers);
                }
        }

        public void InitLayers(int count)
        {
            layers = new List<Layer>();
            for (int i = 0; i < count; ++i)
            {
                var layer = new Layer();
                layer.ID = i;
                if (layers.Count > 0)
                {
                    layer.PrevLayer = layers.Last();
                    layers.Last().NextLayer = layer;
                }
                layers.Add(layer);
            }
        }
        public double Sigmoid(double x)
        {
            //return 2 / (1 + Math.Exp(-2 * x)) - 1;
            return 1 / (1 + Math.Exp(-x));
        }

        /// <summary>
        /// Derivative of the sigmoid function.
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public double SigmoidPrime(double z)
        {
            //return 1 - (Math.Pow(Sigmoid(z), 2));
            return Sigmoid(z) * (1 - Sigmoid(z));
        }
    }
}
