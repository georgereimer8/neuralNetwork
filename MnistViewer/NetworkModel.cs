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

        public Action<bool> ShowTrainingInProgress;
        public Action<int> ShowResult;
        public Action<int> SetBatchMax;
        public Action<int> ShowCurrentBatch;
        public Action<int> SetEpochsMax;
        public Action<double > ShowAccuracy;
        public Action<int> ShowCurrentEpoch;
        public Action<List<Layer>> DisplayLayers { get; set; }
        public Action<bool> SetConsoleVisible;
        public Action<string> Log { get; set; }
        public Action<int, int, double, bool> InitView { get; set; }
        public Action<Bitmap> ShowImages { get; set; }
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

        public void LoadNetwork(string folderPath)
        {
            Network = new Network.NeuralNetwork();
            HookEvents();
            LoadLayers(folderPath);
            Log?.Invoke(String.Format("Network Loaded({0})", folderPath));
        }

        public void SaveNetwork( string folderPath )
        {
            if (Network != null)
            {
                Network.Save(folderPath);
                Log?.Invoke(String.Format("Network Saved({0})", folderPath));
            }
            else Log?.Invoke("Cannot save Network. Network not yet created");
        }

        void LoadLayers(string folderPath)
        {
            var folders = Directory.EnumerateDirectories(folderPath);
            List<string> l = folders.ToList();
            l.Sort();
            string inputLayerPath = "";
            string outputLayerPath = "";
            List<string> hiddenLayerPaths = new List<string>();
            foreach (var folder in l)
            {
                if (Path.GetFileName(folder) == "Input")
                {
                    inputLayerPath = folder;
                }
                else if (Path.GetFileName(folder).Contains("Hidden"))
                {
                    hiddenLayerPaths.Add(folder);
                }
                else if (Path.GetFileName(folder) == "Output")
                {
                    outputLayerPath = folder;
                }
            }
            Network.LoadLayer(inputLayerPath, "Input");
            foreach( var path in hiddenLayerPaths )
            {
                Network.LoadLayer(path, Path.GetFileName(path));
            }
            Network.LoadLayer(outputLayerPath, "Output");
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
        bool verbose;
        public  bool Verbose
        {
            get { return verbose; }
            set
            {
                verbose = value;
                if (Network != null)
                {
                    Network.Verbose = verbose;
                }
            }
        }
        bool shuffle;
        public bool Shuffle
        {
            get { return shuffle; }
            set
            {
                shuffle = value;
                if (Network != null)
                {
                    Network.Shuffle = shuffle;
                }
            }
        }

        public void EvaluateImage( Bitmap image )
        {
            if( Network != null)
            {
                if( TrainingImages != null  )
                {

                    var x = TrainingImages.ImageList.First().Width;
                    var y = TrainingImages.ImageList.First().Height;
                    MnistImage mnistImage = new MnistImage(x, y);
                    mnistImage.GetPixels(image, x, y);

                    //var data = mnistImage.Pixels.Normalize(Byte.MaxValue + 1);
                    var data = mnistImage.Pixels.ToArray();
                    var result = Network.EvaluateData(data);
                    ShowResult?.Invoke(result);
                    DisplayLayers(Network.Layers);
                    //ShowImage(mnistImage.Bitmap);
                    Log?.Invoke(String.Format("Image Evaluates to:{0}", result));
                }
            }
        }
        /// <summary>
        /// Create a new network
        /// </summary>
        public void CreateNetwork()
        {
            Network = new Network.NeuralNetwork();
            HookEvents();
            AddLayers();
        }

        public void HookEvents()
        {
            Network.Log = Log;
            Network.ShowTrainingInProgress = ShowTrainingInProgress;
            Network.ShowCurrentEpoch = ShowCurrentEpoch;
            Network.ShowCurrentBatch = ShowCurrentBatch;
            Network.ShowAccuracy = ShowAccuracy;
            Network.DisplayLayers = DisplayLayers;
            Network.TestEachEpoch = TestEachEpoch;
            Network.Verbose = Verbose;
            Network.Shuffle = Shuffle;
        } 

        public void AddLayers()
        { 
            Network.AddLayer(InputNeuronCount, "Input"); // input layer
            for (int i = 0; i < HiddenLayerCount; ++i)
            {
                Network.AddLayer(HiddenNeuronCount, String.Format("Hidden{0}", i ));// hidden layers
            }
            Network.AddLayer(OutputNeuronCount, "Output"); // output layer
        }

        /// <summary>
        /// highlight the "current" image, whatever that means
        /// </summary>
        /// <param name="index"></param>
        public void UpdateCurrentImage(int index)
        {
            DisplayImage.Highlight(index);
            ShowImages?.Invoke(DisplayImage.Composite);
            UpdateDrawingImage(index);
        }

        public void UpdateDrawingImage( int index )
        {
            ShowImage?.Invoke(TrainingImages.ImageList[index].Bitmap);
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
                SetBatchMax?.Invoke(TrainingImages.ImageList.Count/BatchSize);
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
