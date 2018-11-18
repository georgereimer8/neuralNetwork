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
using Common;

namespace miniNetwork
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        delegate void DisplayLogSafe(string msg);
        public void Log( string msg )
        {
            if (richTextBox_console.InvokeRequired == true)
            {
                DisplayLogSafe d = new DisplayLogSafe(Log);
                richTextBox_console.Invoke(d, msg);
            }
            else
            {
                richTextBox_console.SelectionStart = 0;
                richTextBox_console.SelectedText = (msg + Environment.NewLine);
                richTextBox_console.Update();
            }
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
                Series weights = new Series("Weights", layers.Count);
                Series z = new Series("Z", layers.Count);
                Series costs = new Series("Costs", layers.Count);
                foreach (var layer in layers)
                {
                    activations.Points.AddY(layer.Activation);
                    weights.Points.AddY(layer.Weight);
                    z.Points.AddY(layer.Z);
                    costs.Points.AddY(layer.Cost);
                }

                chartActivations.Series[0] = activations;
                chartWeights.Series[0] = weights;
                chartErrors.Series[0] = z;
                chartCost.Series[0] = costs;

                chartActivations.ChartAreas[0].RecalculateAxesScale();
                chartWeights.ChartAreas[0].RecalculateAxesScale();
                chartErrors.ChartAreas[0].RecalculateAxesScale();
                chartCost.ChartAreas[0].RecalculateAxesScale();

                Application.DoEvents();
                //Refresh();
            }
        }
        
        public void Init()
        {
            SetInput?.Invoke((int)numericUpDown_input.Value);
            SetTarget?.Invoke((int)numericUpDown_target.Value);
            SetLearningRate?.Invoke((double)numericUpDown_learningRate.Value);
            SetEpochs?.Invoke((int)numericUpDownEpochs.Value);
        }

        public Action<int> SetInput;
        private void numericUpDown_input_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            SetInput?.Invoke((int)n.Value);
        }

        public Action<int> SetTarget;
        private void numericUpDown_target_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            SetTarget?.Invoke((int)n.Value);
        }

        public Action<double> SetLearningRate;
        private void numericUpDown_learningRate_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            SetLearningRate?.Invoke((double)n.Value);
        }

        public Action Start;
        private void button_start_Click(object sender, EventArgs e)
        {
            Init();
            Start?.Invoke();
        }

        public Action<int> SetEpochs;
        private void numericUpDownEpochs_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            SetEpochs?.Invoke((int)n.Value);
        }
    }
}
