using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Network
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
        /// <summary>
        /// Randomly shuffle a list of objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
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
        /// Emulate Python's Dot product for np.Dot(Vector 1, Vector 2 )
        /// no need to transpose Vector2
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public Matrix<double> Dot( this Vector<double> v1, Vector<double>v2)
        {
            Matrix<double> a = DenseMatrix.Build.DenseOfColumnVectors(v1);
            Matrix<double> b = DenseMatrix.Build.DenseOfRowVectors(v2);
            Matrix<double> m = a.Multiply(b).Transpose();
            //var rows = v2.Count;
            //var cols = v1.Count;
            //Matrix<double> m = DenseMatrix.Build.Dense(rows, cols);
            //if (v1.Count > 0 && v2.Count > 0)
            //{
            //    for( int col = 0; col < cols; ++col)
            //    {
            //        // for( int row = 0; row < v1.Count; ++row )
            //        Parallel.For(0, rows, (int row) =>
            //        {
            //            m[row, col] = v2[row] * v1[col];
            //        });
            //    }
            //}
            //else
            //{
            //    throw new ArgumentOutOfRangeException(String.Format("parameter error in Vector.Dot()"));
            //}
            return m;
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
            if (m.ColumnCount == v.Count)
            {
                result = DenseVector.Build.Dense(m.RowCount);
                var ca = m.ToRowArrays();
                //for ( int i = 0; i < result.Count; ++i  )
                Parallel.For(0, result.Count, (int i ) =>
                {
                    var cav = DenseVector.Build.Dense(ca[i]);
                    result[i] = cav * v; 
                });
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(String.Format("Matrix({0},{1}) columns must equal vector({2}) count", m.RowCount, m.ColumnCount, v.Count));
            }
            return result;
        }

        static public bool TestDot()
        {
            bool result = false;
            double[] p1 = { 1, 2 };
            double[,] p2 = { { 3,4},{ 5,6} };
            var v = DenseVector.Build.Dense(p1);
            var m = DenseMatrix.Build.DenseOfArray(p2);
            var d = m.Dot(v);
            if( d[0] == 13 && d[1] == 16)
            {
                result = true;
            }
            return result;
        }

    }
}
