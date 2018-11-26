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

        public Action<bool> IncludeTestData;
        private void checkBox_IncludeTestData_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            IncludeTestData?.Invoke(c.Checked);
        }

        public void Init(int epochs, int batchSize, double learningRate, bool includeTestData)
        {
            //numericUpDown_epochs.Value = epochs;
            //numericUpDown_batchSize.Value = batchSize;
            //numericUpDown_learningRate.Value = (decimal)learningRate;
            //checkBox_IncludeTestData.Checked = includeTestData;

            numericUpDown_epochs_ValueChanged(numericUpDown_epochs, null);
            numericUpDown_batchSize_ValueChanged(numericUpDown_batchSize, null);
            numericUpDown_learningRate_ValueChanged(numericUpDown_learningRate, null);
            checkBox_IncludeTestData_CheckedChanged(checkBox_IncludeTestData, null);
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
    }
}
