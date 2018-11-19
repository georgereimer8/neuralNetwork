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
                Parallel.For(0, result.Count, (int i ) =>
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
