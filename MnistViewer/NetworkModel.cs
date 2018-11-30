using Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
        public string TrainingLablesPath { get; set; }
        public string TrainingImagesPath { get; set; }
        public string TestingLablesPath { get; set; }
        public string TestingImagesPath { get; set; }
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

        MnistImages TrainingImages;
        MnistImages TestingImages;

        public void Init()
        {
            if (File.Exists(@"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\t10k-labels.idx1-ubyte"))
            {
                TrainingLablesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\train-labels.idx1-ubyte";
                TrainingImagesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\train-images.idx3-ubyte";
                TestingLablesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\t10k-labels.idx1-ubyte";
                TestingImagesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\t10k-images.idx3-ubyte";
            }
            else
            {
                TrainingLablesPath = @"C:\Users\georgereimer\Source\Repos\neuralNetwork\mnist\train-labels.idx1-ubyte";
                TrainingImagesPath = @"C:\Users\georgereimer\Source\Repos\neuralNetwork\mnist\train-images.idx3-ubyte";
                TestingLablesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\t10k-labels.idx1-ubyte";
                TestingImagesPath = @"C:\Users\GeorgeR\source\repos\neuralNetwork\mnist\t10k-images.idx3-ubyte";
            }

            InitView(DefaultEpochs, DefaultBatchSize, DefaultLearningRate, DefaultIncludeTestData);
        }
        public void TrainNetwork()
        {
            CreateNetwork();
            SetConsoleVisible?.Invoke(true);

            //List<NetworkData> trainingData = new List<NetworkData>();
            //foreach (var i in TrainingImages.ImageList)
            //{
            //    trainingData.Add(new NetworkData(i.Index, i.Pixels.ToArray(), i.Label, Network.Layers.Last().Neurons.Count()));
            //}

            //List<NetworkData> testingData = new List<NetworkData>();
            //foreach (var i in TestingImages.ImageList)
            //{
            //    testingData.Add(new NetworkData(i.Index, i.Pixels.ToArray(), i.Label, Network.Layers.Last().Neurons.Count()));
            //}

            var trainingData = CreateData(TrainingImages.ImageList);
            var testingData = CreateData(TestingImages.ImageList);
            Network.Train( trainingData, testingData, Epochs, BatchSize, LearningRate);
        }

        List<NetworkData> CreateData(List<MnistImage> images)
        {
            List<NetworkData> data = new List<NetworkData>();
            foreach (var i in images)
            {
                data.Add(new NetworkData(i.Index, i.Pixels.ToArray(), i.Label, Network.Layers.Last().Neurons.Count()));
            }
            return data;
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

        double[] TestData = new double[5] { 1, 2, 3, 4, 5 };

        public void TrainTestNetwork()
        {
            SetConsoleVisible?.Invoke(true);
            List<NetworkData> trainingData = new List<NetworkData>();
            trainingData.Add(new NetworkData(0, TestData, "0", Network.Layers.Last().Neurons.Count()));
            Network.TrainingTest(trainingData);
        }

        public void CreateNetwork()
        {
            Network = new Network.NeuralNetwork();
            Network.Log = Log;
            Network.ShowCurrentEpoch = ShowCurrentEpoch;
            Network.DisplayLayers = DisplayLayers;

            Network.AddLayer(TrainingImages.ImageList.First().Pixels.Count); // input layer
            Network.AddLayer(30);// hidden layer
            Network.AddLayer(10); // output layer
        }

        public void UpdateCurrentImage(int index)
        {
            DisplayImage.Highlight(index);
            ShowImage?.Invoke(DisplayImage.Composite);
        }

        public void ReadImages()
        {
            try
            {
                TrainingImages = new MnistImages(TrainingLablesPath, TrainingImagesPath);
                TestingImages = new MnistImages(TestingLablesPath, TestingImagesPath);
                DisplayImage = new DisplayImage(TrainingImages.ImageList);
                DisplayImage.GenerateComposite();
                UpdateCurrentImage(0);
                SetMaxImageCount?.Invoke(TrainingImages.ImageList.Count);
            }
            catch (System.Exception ex)
            {
                Log?.Invoke(String.Format("Failed to read images:{0}", ex.Message));
            }
        }
    }
}
