using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Network
{
    /// <summary>
    /// These are Vector extenions that implement the sigmoid activation function
    /// </summary>
    public class Activation
    {
        static public Vector<double> Sigmoid(Vector<double> z)
        {
            var result = 1.0 / (1.0 + Vector.Exp(-z));
            return result;
        }

        /// <summary>
        /// Derivative of the sigmoid function.
        ///  result =  Sigmoid(z) * (1 - Sigmoid(z));
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        static public Vector<double> SigmoidPrime(Vector<double> z)
        {
            var s1 = Sigmoid(z);
            var result = s1.PointwiseMultiply(1 - s1);
            return result;
        }
    }
}
