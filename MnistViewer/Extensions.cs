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
                else if (control.IsHandleCreated == true)
                {
                    // we're on the controls thread, make sure it has a handle before invoking action on it
                    // may want to restore default handle creation? IntPtr h = p_control.Handle;
                    action.Invoke();
                }
            }
        }
    }
}



