using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace BinaryConvertor
{
    public partial class NetworkView : Form
    {
        public NetworkView()
        {
            InitializeComponent();
        }

        public void ShowInputLayerSize( int size )
        {
            numericUpDownHiddenLayerNeuronCount.SafeInvoke(() =>
            {
                numericUpDownInputLayerNeuronCount.Value = size;
            });
        }
        public void ShowHiddenLayerSize( int size ) 
        {
            numericUpDownHiddenLayerNeuronCount.SafeInvoke(() =>
            {
                numericUpDownHiddenLayerNeuronCount.Value = size;
            });
        }
        public void ShowOutputLayerSize( int size )
        {
            numericUpDownHiddenLayerNeuronCount.SafeInvoke(() =>
            {
                numericUpDownOutputLayerNeuronCount.Value = size;
            });
        }
        public void ShowLearningRate( decimal rate )
        {
            numericUpDownLearningRate.SafeInvoke(() =>
            {
                numericUpDownLearningRate.Value = rate;
            });
        }

        public Action<int> SetInputLayerSize;
        public Action<int> SetHiddenLayerSize;
        public Action<int> SetOutputLayerSize;
        public Action<decimal> SetLearningRate;

        private void numericUpDownOutputLayerNeuronCount_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetOutputLayerSize?.Invoke((int)n.Value);
        }

        private void numericUpDownInputLayerNeuronCount_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetInputLayerSize?.Invoke((int)n.Value);
        }

        private void numericUpDownHiddenLayerNeuronCount_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetHiddenLayerSize?.Invoke((int)n.Value);
        }

        private void numericUpDownLearningRate_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetLearningRate?.Invoke(n.Value);
        }

        public Action CreateNetwork;
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateNetwork?.Invoke();
        }

        public Action TrainNetwork;
        private void buttonTrain_Click(object sender, EventArgs e)
        {
            TrainNetwork?.Invoke(); 
        }

        delegate void DisplayLogSafe(string msg);
        public void Log(string msg)
        {
            if (richTextBox_log.InvokeRequired == true)
            {
                DisplayLogSafe d = new DisplayLogSafe(Log);
                richTextBox_log.Invoke(d, msg);
            }
            else
            {
                richTextBox_log.SelectionStart = 0;
                richTextBox_log.SelectedText = (msg + Environment.NewLine);
                richTextBox_log.Update();
            }
        }
    }
}
