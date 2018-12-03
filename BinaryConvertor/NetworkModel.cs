using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network;

namespace BinaryConvertor
{

    public class NetworkModel
    {
        const int DefaultInputLayerSize = 10;
        const int DefaultHiddenLayerSize = 4;
        const int DefaultOutputLayerSize = 10;
        const decimal DefaultLearningRate = 0.05M;
        const int DefaultTrainingSampleCount = 10000;
        const int DefaultEpochCount = 100;
        const int DefaultBatchSize = 1;

        public Action<int> SetInputLayerSize;
        public Action<int> SetHiddenLayerSize;
        public Action<int> SetOutputLayerSize;
        public Action<decimal> SetLearningRate;
        public Action<string> Log;

        public int InputLayerSize { get { return inputLayerSize; } set { inputLayerSize = value;  SetInputLayerSize?.Invoke(value); } }
        public int HiddenLayerSize { get { return hiddenLayerSize; } set { hiddenLayerSize = value;  SetHiddenLayerSize?.Invoke(value); } }
        public int OutputLayerSize { get { return outputLayerSize; } set { outputLayerSize = value;  SetOutputLayerSize?.Invoke(value); } }
        public decimal LearningRate { get { return learningRate; } set { learningRate = value;  SetLearningRate?.Invoke(value); } }

        int inputLayerSize;
        int hiddenLayerSize;
        int outputLayerSize;
        decimal learningRate;


        public NeuralNetwork Network;
        public NetworkModel()
        {
        }

        public void Initialize()
        {
            InputLayerSize = DefaultInputLayerSize;
            HiddenLayerSize = DefaultHiddenLayerSize;
            OutputLayerSize = DefaultOutputLayerSize;
        }

        public void CreateNetwork()
        { 
            Network = new NeuralNetwork();
            Network.AddLayer(InputLayerSize);
            Network.AddLayer(HiddenLayerSize);
            Network.AddLayer(OutputLayerSize);

            Network.LogMessage = Log;

            Log?.Invoke("Network Created");
        }

        public void TrainFixed()
        {
            Log?.Invoke("Network Training Started");
            BinaryTrainingData binaryData = new BinaryTrainingData();
            var trainingData = binaryData.GenerateTrainingData(DefaultTrainingSampleCount, 0);
            Network.Train(trainingData, DefaultEpochCount, DefaultBatchSize, (double)LearningRate, includeTestData:false);
        }
    }
}
