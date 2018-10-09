using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MnistViewer
{
    public partial class TrainingForm : Form
    {
        public TrainingForm()
        {
            InitializeComponent();
        }

        public void SetVisiblity( bool setting )
        {
            Visible = setting;
        }
        public void Log( string message)
        {
            richTextBox_console.SafeInvoke(() =>
            {
                richTextBox_console.AppendText(message + Environment.NewLine);
            });
        }

                    /// <summary>
                    /// Overide form close
                    /// <para>Dont really close it. Just hide.</para>
                    /// </summary>
                    /// <param name="e"></param>
        private void TrainingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Visible = false;
                e.Cancel = true;
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
