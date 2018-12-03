using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://jamesmccaffrey.wordpress.com/2013/11/23/reading-the-mnist-data-set-with-c/

namespace MnistViewer
{
    public partial class NetworkView : Form
    {

        public NetworkView()
        {
            InitializeComponent();
        }

        public Action<string> SetIfsLabelsPath;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\GeorgeR\source\repos\handwriting\mnist";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_labelsPath.Text = openFileDialog1.FileName;
                SetIfsLabelsPath?.Invoke(openFileDialog1.FileName);
            }
        }

        public Action<string> SetIfsImagesPath;
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\GeorgeR\source\repos\handwriting\mnist";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_imagesPath.Text = openFileDialog1.FileName;
                SetIfsImagesPath?.Invoke(openFileDialog1.FileName);
            }
        }

        public void ShowImage(Bitmap b)
        {
            button1.SafeInvoke(() =>
            {
                zoomPicBox1.Image = b;
                Refresh();
            });
        }

        public Action ReadImages;
        private void button_load_Click(object sender, EventArgs e)
        {
            ReadImages?.Invoke();
        }

        public Action CreateNetwork;
        private void button_createNetwork_Click(object sender, EventArgs e)
        {
            CreateNetwork?.Invoke();
        }

        public Action TrainNetwork;
        private void button_trainNetwork_Click(object sender, EventArgs e)
        {
            TrainNetwork?.Invoke();
        }

        public Action<int> Epochs;
        private void numericUpDown_epochs_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            Epochs?.Invoke((int)n.Value);
        }

        public Action<int> BatchSize;

        private void numericUpDown_batchSize_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            BatchSize?.Invoke((int)n.Value);
        }

        public Action<double> LearningRate;
        private void numericUpDown_learningRate_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            LearningRate?.Invoke((double)n.Value);
        }

        public Action<bool> TestEachEpoch;
        private void checkBox_TestEachEpoch_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            TestEachEpoch?.Invoke(c.Checked);
        }

        /// <summary>
        ///  this function initializes the model as per the values set for these controls set in the designer
        /// </summary>
        /// <param name="epochs"></param>
        /// <param name="batchSize"></param>
        /// <param name="learningRate"></param>
        /// <param name="includeTestData"></param>
        public void Init(int epochs, int batchSize, double learningRate, bool includeTestData)
        {
            numericUpDown_epochs_ValueChanged(numericUpDown_epochs, null);
            numericUpDown_batchSize_ValueChanged(numericUpDown_batchSize, null);
            numericUpDown_learningRate_ValueChanged(numericUpDown_learningRate, null);
            checkBox_TestEachEpoch_CheckedChanged(checkBox_IncludeTestData, null);
            numericUpDown_OutputNeuronCount_ValueChanged(numericUpDown_OutputNeuronCount, null);
            numericUpDown_HiddenNeuronCount_ValueChanged(numericUpDown_HiddenNeuronCount, null);
            numericUpDown_HiddenLayerCount_ValueChanged(numericUpDown_HiddenLayerCount, null);
        }

        public Action<int> UpdateCurrentImage { get; set; }
        private void numericUpDown_currentImage_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentImage?.Invoke((int)numericUpDown_currentImage.Value);
        }

        private void trackBar_zoomLevel_Scroll(object sender, EventArgs e)
        {
            label_zoomLevel.Text = trackBar_zoomLevel.Value.ToString();
            zoomPicBox1.Zoom = (float)trackBar_zoomLevel.Value / 100;
        }

        public void SetMaxImageCount( int count )
        {
            numericUpDown_currentImage.SafeInvoke(() => 
            {
                numericUpDown_currentImage.Maximum = count;
            });
        }

        public void ShowInputNeuronCount( int count )
        {
            textBox_inputNeuronCount.SafeInvoke(() => 
            {
                textBox_inputNeuronCount.Text = count.ToString();
            });
        }

        public Action<int> SetHiddenLayerCount;
        private void numericUpDown_HiddenLayerCount_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetHiddenLayerCount?.Invoke((int)n.Value);
        }
        public void ShowHiddenLayerCount( int count )
        {
            numericUpDown_HiddenLayerCount.SafeInvoke(() => 
            {
                numericUpDown_HiddenLayerCount.Value = count;
            });
        }

        public Action<int> SetHiddenNeuronCount;
        private void numericUpDown_HiddenNeuronCount_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetHiddenNeuronCount?.Invoke((int)n.Value);
        }
        public void ShowHiddenNeuronCount( int count )
        {
            numericUpDown_HiddenNeuronCount.SafeInvoke(() => 
            {
                numericUpDown_HiddenNeuronCount.Value = count;
            });
        }

        public Action<int> SetOutputNeuronCount;
        private void numericUpDown_OutputNeuronCount_ValueChanged(object sender, EventArgs e)
        {
            var n = sender as NumericUpDown;
            SetOutputNeuronCount?.Invoke((int)n.Value);
        }
        public void ShowOutputNeuronCount( int count )
        {
            numericUpDown_OutputNeuronCount.SafeInvoke(() => 
            {
                numericUpDown_OutputNeuronCount.Value = count;
            });
        }

        public Action<bool> Stop;
        private void button_Stop_Click(object sender, EventArgs e)
        {
            Stop?.Invoke(true);
        }
    }
}
