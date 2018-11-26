using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Network;

namespace MnistViewer
{
    public partial class TrainingForm : Form
    {
        public TrainingForm()
        {
            InitializeComponent();
          
        }

        delegate void DisplayLayersSafe(List<Layer> layers);
        public void DisplayLayers(List<Layer> layers)
        {
            if (this.InvokeRequired == true)
            {
                DisplayLayersSafe d = new DisplayLayersSafe(DisplayLayers);
                this.Invoke(d, layers);
            }
            else
            {

                Series activations = new Series("Activations", layers.Count);
                //Series weights = new Series("Weights", layers.Count);
                //Series z = new Series("Z", layers.Count);
                //Series costs = new Series("Costs", layers.Count);
                //foreach (var layer in layers)
                //{
                //    activations.Points.AddY(layer.Activations);
                //    //weights.Points.AddY(layer.Weight);
                //    //z.Points.AddY(layer.Z);
                //    //costs.Points.AddY(layer.Cost);
                //}

                foreach (var d in layers.Last().Activations)
                {
                    activations.Points.AddY(d);
                }

                chartActivations.Series[0] = activations;
                //chartWeights.Series[0] = weights;
                //chartErrors.Series[0] = z;
                //chartCost.Series[0] = costs;

                chartActivations.ChartAreas[0].RecalculateAxesScale();
                //chartWeights.ChartAreas[0].RecalculateAxesScale();
                //chartErrors.ChartAreas[0].RecalculateAxesScale();
                //chartCost.ChartAreas[0].RecalculateAxesScale();

                Application.DoEvents();
                //Refresh();
            }
        }
        public void SetEpochMax( int count)
        {
            aquaGauge_epochs.SafeInvoke(() =>
            {
                aquaGauge_epochs.MaxValue = count;
            });
        }

        public void SetCurrentEpoch( int count )
        {
            aquaGauge_epochs.SafeInvoke(() =>
            {
                aquaGauge_epochs.Value = count;
                Refresh();
            });
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
