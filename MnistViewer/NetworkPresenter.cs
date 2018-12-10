using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnistViewer
{
    public class NetworkPresenter
    {
        public NetworkPresenter( NetworkView view, NetworkModel model )
        {
            model.Log = view.Log;
            model.ShowImage = view.ShowImage;
            model.InitView = view.Init;
            model.SetMaxImageCount = view.SetMaxImageCount;
            model.ShowCurrentEpoch = view.SetCurrentEpoch;
            model.ShowAccuracy = view.ShowAccuracy;
            model.SetEpochsMax = view.SetEpochMax;
            model.SetBatchMax = view.SetBatchMax;
            model.ShowCurrentBatch = view.ShowCurrentBatch;
            model.DisplayLayers = view.DisplayLayers;
            model.ShowInputNeuronCount = view.ShowInputNeuronCount;
            model.ShowHiddenLayerCount = view.ShowHiddenLayerCount;
            model.ShowHiddenNeuronCount = view.ShowHiddenNeuronCount;
            model.ShowOutputNeuronCount = view.ShowOutputNeuronCount;

            view.UpdateCurrentImage = model.UpdateCurrentImage;
            view.ReadImages = model.ReadImages;
            view.CreateNetwork = model.CreateNetwork;
            view.TrainNetwork = model.TrainNetwork;
            view.SetIfsImagesPath = (path) => model.TrainingImagesPath = path;
            view.SetIfsLabelsPath = (path) => model.TrainingLablesPath = path;
            view.Epochs = (count) => model.Epochs = count;
            view.BatchSize = (count) => model.BatchSize = count;
            view.LearningRate = (value) => model.LearningRate = value;
            view.TestEachEpoch = (setting) => model.TestEachEpoch = setting;
            view.SetHiddenLayerCount = (count) => model.HiddenLayerCount = count;
            view.SetHiddenNeuronCount = (count) => model.HiddenNeuronCount = count;
            view.SetOutputNeuronCount = (count) => model.OutputNeuronCount = count;
            view.Stop = model.Stop;
            view.Verbose = (setting) => model.Verbose = setting;
            view.Shuffle = (setting) => model.Shuffle = setting;

            model.Init();
        }
    }
}
