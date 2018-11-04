using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
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
                action.Invoke();
            }
        }
    }
}
