﻿using Network;
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
        public Action<double > ShowAccuracy;
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
        public enum MessageScope { Info, Error, Verbose, Debug };

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

        public Action<int> ShowHiddenNeuronCount;
        int hiddenNeuronCount;
        public int HiddenNeuronCount
        {
            get { return hiddenNeuronCount; }
            set
            {
                hiddenNeuronCount = value;
                ShowHiddenNeuronCount?.Invoke(hiddenNeuronCount);
            }
        }
        public Action<int> ShowOutputNeuronCount;
        int outputNeuronCount;
        public int OutputNeuronCount
        {
            get { return outputNeuronCount; }
            set
            {
                outputNeuronCount = value;
                ShowHiddenNeuronCount?.Invoke(outputNeuronCount);
            }
        }

        public Action<int> ShowHiddenLayerCount;
        int hiddenLayerCount;
        public int HiddenLayerCount
        {
            get { return hiddenLayerCount; }
            set
            {
                hiddenLayerCount = value;
                ShowHiddenLayerCount?.Invoke(hiddenLayerCount);
            }
        }

        public Action<int> ShowInputNeuronCount;
        int inputNeuronCount;
        public int InputNeuronCount
        {
            get { return inputNeuronCount; }
            set
            {
                inputNeuronCount = value;
                ShowInputNeuronCount?.Invoke(inputNeuronCount);
            }
        }

        public int BatchSize { get; set; }
        public double LearningRate { get; set; }
        public bool TestEachEpoch { get; set; }

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
                TestingLablesPath = @"C:\Users\georgereimer\source\repos\neuralNetwork\mnist\t10k-labels.idx1-ubyte";
                TestingImagesPath = @"C:\Users\georgereimer\source\repos\neuralNetwork\mnist\t10k-images.idx3-ubyte";
            }

            InitView(DefaultEpochs, DefaultBatchSize, DefaultLearningRate, DefaultIncludeTestData);
        }

        /// <summary>
        /// Setup a new network and train using the current training data
        /// Test is performance using the given test data
        /// </summary>
        public void TrainNetwork()
        {
            CreateNetwork();
            SetConsoleVisible?.Invoke(true);
            var trainingData = CreateData(TrainingImages.ImageList);
            var testingData = CreateData(TestingImages.ImageList);
            Network.Train( trainingData, testingData, Epochs, BatchSize, LearningRate);
        }


        /// <summary>
        /// Create the training or testing data from the given Mnist image
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        List<NetworkData> CreateData(List<MnistImage> images)
        {
            List<NetworkData> data = new List<NetworkData>();
            foreach (var i in images)
            {
                data.Add(new NetworkData(i.Index, i.Pixels.Normalize( Byte.MaxValue+1), i.Label, Network.Layers.Last().Neurons.Count()));
            }
            return data;
        }

        public void Stop(bool setting)
        {
            if( Network != null )
            {
                Network.Stop = setting;
            }
        }

        /// <summary>
        /// Create a new network
        /// </summary>
        public void CreateNetwork()
        {
            Network = new Network.NeuralNetwork();
            Network.Log = Log;
            Network.ShowCurrentEpoch = ShowCurrentEpoch;
            Network.ShowAccuracy = ShowAccuracy;
            Network.DisplayLayers = DisplayLayers;
            Network.TestEachEpoch = TestEachEpoch;

            Network.AddLayer(InputNeuronCount); // input layer
            for (int i = 0; i < HiddenLayerCount; ++i)
            {
                Network.AddLayer(HiddenNeuronCount);// hidden layers
            }
            Network.AddLayer(OutputNeuronCount); // output layer
        }

        /// <summary>
        /// highlight the "current" image, whatever that means
        /// </summary>
        /// <param name="index"></param>
        public void UpdateCurrentImage(int index)
        {
            DisplayImage.Highlight(index);
            ShowImage?.Invoke(DisplayImage.Composite);
        }

        /// <summary>
        /// Read the Mnist images from the given paths
        /// </summary>
        public void ReadImages()
        {
            try
            {
                Log?.Invoke("Reading Images...");
                TrainingImages = new MnistImages(TrainingLablesPath, TrainingImagesPath);
                TestingImages = new MnistImages(TestingLablesPath, TestingImagesPath);
                DisplayImage = new DisplayImage(TrainingImages.ImageList);
                DisplayImage.GenerateComposite();
                UpdateCurrentImage(0);
                SetMaxImageCount?.Invoke(TrainingImages.ImageList.Count);
                InputNeuronCount = TrainingImages.ImageList.First().Pixels.Count;
                Log?.Invoke("Reading Images Complete");
            }
            catch (System.Exception ex)
            {
                Log?.Invoke(String.Format("Failed to read images:{0}", ex.Message));
            }
        }
    }
}
