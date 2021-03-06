﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;

namespace Network 
{
    /// <summary>
    /// A container class for network data and its label
    /// </summary>
    public class NetworkData
    {
        public Vector<double> data { get; set; }
        public Vector<double> label { get; set; }
        public int Index { get; set; }

        public NetworkData(int myIndex, Vector<double> myData, Vector<double> myLabel )
        {
            data = myData;
            label = myLabel;
            Index = myIndex;
        }

        public NetworkData(int myIndex, double[] myValues, string myLabel, int outputActivations)
        {
            data = DenseVector.Build.Dense(myValues);
            label = DenseVector.Build.Dense(toArray(myLabel, outputActivations));
            Index = myIndex;
        }
        double[] toArray(string label, int outputActivations)
        {
            double[] result = new double[outputActivations];
            var value = int.Parse(label);
            result[value] = 1;
            return result;
        }
    }
}
