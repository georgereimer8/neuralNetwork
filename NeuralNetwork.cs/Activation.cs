using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Network
{
    public class Activation
    {
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
