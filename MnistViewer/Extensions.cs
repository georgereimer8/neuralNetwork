using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MnistViewer
{
    static public class Extensions
    {
        static public void SafeInvoke(this Control control, Action action, bool synchronous = false)
        {
            if (control.IsDisposed == false)
            {
                if (control.InvokeRequired)
                {
                    if (synchronous)
                        control.Invoke((Action)delegate { SafeInvoke(control, action, synchronous); });
                    else
                        control.BeginInvoke((Action)delegate { SafeInvoke(control, action, synchronous); });
                }
                else if (control.IsHandleCreated == false)
                {
                    IntPtr h = control.Handle;
                }
                // we're on the controls thread, make sure it has a handle before invoking action on it
                // may want to restore default handle creation? 
                action.Invoke();
            }
        }

        /// <summary>
        /// Normalize a list of integers into an array of doubles that range between 0 and 1
        /// </summary>
        /// <param name="input"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        static public double[] Normalize( this List<int> input, int range )
        {
            double[] n = new double[input.Count()];
            for( int i = 0; i < input.Count; ++i )
            {
                n[i] = (double)input[i] / (double)range;
            }
            return n;
        }
    }
}



