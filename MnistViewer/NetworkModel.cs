using Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MnistViewer
{

    public class NetworkModel
    {
        public Action<bool> SetConsoleVisible;
        public Action<string> Log { get; set; }
        public Action<int, int, double, bool> InitView { get; set; }
        public Action<Bitmap> ShowImage { get; set; }
        public Action<int> SetMaxImageCount { get; set; }
        public string IfsLabelsPath { get; set; }
        public string IfsImagesPath { get; set; }
        public NeuralNetwork Network { get; set; }
        public DisplayImage DisplayImage { get; set; }

        const int DefaultEpochs = 10;
        const int DefaultBatchSize = 3;
        const double DefaultLearningRate = 0.5;
        const bool DefaultIncludeTestData = false;

        public int Epochs { get; set; }
        public int BatchSize { get; set; }
        public double LearningRate { get; set; }
        public bool IncludeTestData { get; set; }

        public FileStream ifsLabels;
        public FileStream ifsImages;
        MnistImageReader MnistImageReader = new MnistImageReader();

        public void Init()
        {
            //IfsLabelsPath = @"C:\Users\GeorgeR\source\repos\handwriting\mnist\t10k-labels.idx1-ubyte";
            //IfsImagesPath = @"C:\Users\GeorgeR\source\repos\handwriting\mnist\t10k-images.idx3-ubyte";

            IfsLabelsPath = @"C:\Users\georgereimer\Source\Repos\handwriting\mnist\t10k-labels.idx1-ubyte";
            IfsImagesPath = @"C:\Users\georgereimer\Source\Repos\handwriting\mnist\t10k-images.idx3-ubyte";

            InitView(DefaultEpochs, DefaultBatchSize, DefaultLearningRate, DefaultIncludeTestData);
        }
        public void TrainNetwork()
        {
            SetConsoleVisible?.Invoke(true);
            List<TrainingData> trainingData = new List<TrainingData>();
            foreach (var i in MnistImageReader.ImageList)
            {
                trainingData.Add(new TrainingData(i.Pixels, i.Label ));
            }
            Network.Train(trainingData, Epochs, BatchSize, LearningRate, includeTestData: false);
        }

        public void CreateTestNetwork()
        {
            Network = new NeuralNetwork();
            Network.Log = Log;

            Network.AddLayer(5);
            Network.AddLayer(1);
            Network.AddLayer(1);

            //Network.AddLayer(784);
            //Network.AddLayer(30);
            //Network.AddLayer(10);
        }

        double[] TestData = new double[5] {1, 2, 3, 4, 5};
            
        public void TrainTestNetwork()
        {
            SetConsoleVisible?.Invoke(true);
            List<TrainingData> trainingData = new List<TrainingData>();
            trainingData.Add(new TrainingData(TestData, "5" ));
            Network.TrainingTest(trainingData);
        }

        public void CreateNetwork()
        {
            Network = new NeuralNetwork();
            Network.Log = Log;

            Network.AddLayer(MnistImageReader.ImageList.First().Pixels.Length); // input layer
            Network.AddLayer(30);// hidden layer
            Network.AddLayer(10); // output layer
        }

        public void UpdateCurrentImage( int index )
        {
            DisplayImage.Highlight(index);
            ShowImage?.Invoke(DisplayImage.Composite);
        }

        public void ReadImages()
        {
            bool imagesRead = false;
            if (File.Exists(IfsImagesPath))
            {
                ifsImages = new FileStream(IfsImagesPath, FileMode.Open); // test labels
                if (File.Exists(IfsLabelsPath))
                {
                    ifsLabels = new FileStream(IfsLabelsPath, FileMode.Open); // test labels
                    MnistImageReader.ReadImages(ifsImages, ifsLabels);
                    DisplayImage = new DisplayImage(MnistImageReader.ImageList);
                    DisplayImage.GenerateComposite();
                    UpdateCurrentImage(0);
                    SetMaxImageCount?.Invoke(MnistImageReader.ImageList.Count);
                    imagesRead = true;
                }
            }

            if( imagesRead == false)
            {
                MessageBox.Show("Failed to read images");
            }
        }
    }
}
