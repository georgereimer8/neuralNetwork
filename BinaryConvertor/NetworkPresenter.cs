using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConvertor
{
    public class NetworkPresenter
    {
        public NetworkPresenter( NetworkView view, NetworkModel model )
        {
            model.SetInputLayerSize = view.ShowInputLayerSize;
            model.SetHiddenLayerSize = view.ShowHiddenLayerSize;
            model.SetOutputLayerSize = view.ShowOutputLayerSize;

            model.Log = view.Log;

            view.SetInputLayerSize = (size) => model.InputLayerSize = size;
            view.SetHiddenLayerSize = (size) => model.HiddenLayerSize = size;
            view.SetOutputLayerSize = (size) => model.OutputLayerSize = size;
            view.SetLearningRate = (size) => model.LearningRate = size;
            view.CreateNetwork = model.CreateNetwork;
            view.TrainNetwork = model.TrainFixed;

            model.Initialize();
        }
    }
}
