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
        public Action<int> SetEpochsMax;
        public Action<int> ShowCurrentEpoch;
        public Action<List<Layer>> DisplayLayers { get; set; }
        public Action<bool> SetConsoleVisible;
        public Action<string> Log { get; set; }
        public Action<int, int, double, bool> InitView { get; set; }
        public Action<Bitmap> ShowImage { get; set; }
        public Action<int> SetMaxImageCount { get; set; }
        public string IfsLabelsPath { get; set; }
        public string IfsImagesPath { get; set; }
        public NeuralNetwork Network { get; set; }
        public DisplayImage DisplayImage { get; set; }
        public const int MaxImages = 10000;
       
        const int DefaultEpochs = 30;
        const int DefaultBatchSize = 10;
        const double DefaultLearningRate = 3.0;
        const bool DefaultIncludeTestData = false;

        int epochs;
        public int Epochs
        {
            get { return epochs; }
            set
            {
                epochs = value;
                SetEpochsMax?.Invoke(epochs);
            }
        }
        int currentEpoch;
        public int CurrentEpoch
        {
            get { return currentEpoch; }
            set
            {
                currentEpoch = value;
                SetEpochsMax?.Invoke(currentEpoch);
            }
        }

        public int BatchSize { get; set; }
        public double LearningRate { get; set; }
        public bool IncludeTestData { get; set; }

        public FileStream ifsLabels;
        public FileStream ifsImages;
        MnistImageReader MnistImageReader = new MnistImageReader();

        public void Init()
        {
            if (File.Exists(@"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\t10k-labels.idx1-ubyte"))
            {
                IfsLabelsPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\train-labels.idx1-ubyte";
                IfsImagesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\train-images.idx3-ubyte";
            }
            else
            {
                IfsLabelsPath = @"C:\Users\georgereimer\Source\Repos\neuralNetwork\mnist\train-labels.idx1-ubyte";
                IfsImagesPath = @"C:\Users\georgereimer\Source\Repos\neuralNetwork\mnist\train-images.idx3-ubyte";
            }

            InitView(DefaultEpochs, DefaultBatchSize, DefaultLearningRate, DefaultIncludeTestData);
        }
        public void TrainNetwork()
        {
            SetConsoleVisible?.Invoke(true);
            List<TrainingData> trainingData = new List<TrainingData>();
            foreach (var i in MnistImageReader.ImageList)
            {
                trainingData.Add(new TrainingData(i.Index, i.Pixels, i.Label, Network.Layers.Last().Neurons.Count()));
            }
            Network.Train(trainingData, Epochs, BatchSize, LearningRate, includeTestData: false);
        }

        public void CreateTestNetwork()
        {
            Network = new Network.NeuralNetwork();
            Network.Log = Log;
            Network.UpdateCurrentImage = UpdateCurrentImage;
            Network.ShowCurrentEpoch = ShowCurrentEpoch;


            //Network.AddLayer(10);
            //Network.AddLayer(4);
            //Network.AddLayer(10);

            Network.AddLayer(784);
            Network.AddLayer(30);
            Network.AddLayer(10);
        }

        double[] TestData = new double[5] {1, 2, 3, 4, 5};
            
        public void TrainTestNetwork()
        {
            SetConsoleVisible?.Invoke(true);
            List<TrainingData> trainingData = new List<TrainingData>();
            trainingData.Add(new TrainingData(0, TestData, "0", Network.Layers.Last().Neurons.Count()  ));
            Network.TrainingTest(trainingData);
        }

        public void CreateNetwork()
        {
            Network = new Network.NeuralNetwork();
            Network.Log = Log;
            Network.ShowCurrentEpoch = ShowCurrentEpoch;
            Network.DisplayLayers = DisplayLayers;

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
