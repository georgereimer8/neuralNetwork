using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using Network;

namespace BinaryConvertor
{ 
    public class BinaryTrainingData
    {

        Dictionary<int,Vector<double>> binary = new Dictionary<int, Vector<double>>()
        {
            {0, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,0,0,0 }) },
            {1, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,0,0,1 }) },
            {2, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,0,1,0 }) },
            {3, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,0,1,1 }) },
            {4, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,1,0,0 }) },
            {5, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,1,0,1 }) },
            {6, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,1,1,0 }) },
            {7, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,1,1,1 }) },
            {8, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,1,0,0,0 }) },
            {9, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,1,0,0,0 }) }
        };

        Dictionary<int,Vector<double>> labels = new Dictionary<int,Vector<double>>()
        { 
            {0, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,0,0,1 }) },
            {1, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,0,1,0 }) },
            {2, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,0,1,0,0 }) },
            {3, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,0,1,0,0,0 }) },
            {4, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,0,1,0,0,0,0 }) },
            {5, DenseVector.Build.DenseOfArray(new double[]{0,0,0,0,1,0,0,0,0,0 }) },
            {6, DenseVector.Build.DenseOfArray(new double[]{0,0,0,1,0,0,0,0,0,0 }) },
            {7, DenseVector.Build.DenseOfArray(new double[]{0,0,1,0,0,0,0,0,0,0 }) },
            {8, DenseVector.Build.DenseOfArray(new double[]{0,1,0,0,0,0,0,0,0,0 }) },
            {9, DenseVector.Build.DenseOfArray(new double[]{1,0,0,0,0,0,0,0,0,0 }) }
        };

        Random random = new Random();


        public Vector<double> GetSample(int i)
        {
            Vector<double>  result = null;
            if( i < binary.Count)
            {
                result = binary[i]; 
            }
            return result;
        }

        public Vector<double> GetLabel(int i)
        {
            Vector<double> result = null;
            if( i < binary.Count)
            {
                result = labels[i]; 
            }
            return result;
        }

        public List<TrainingData> GenerateTrainingData( int count, int fixedSample = -1 )
        {
            List<TrainingData> t = new List<TrainingData>();
            for( int i = 0; i < count; ++i )
            {
                var s = fixedSample;
                if( fixedSample == -1 )
                {
                    s = random.Next(binary.Count);
                }
                t.Add(new TrainingData(i, GetSample(s), GetLabel(s)));
            }
            return t;
        }
    }
}
