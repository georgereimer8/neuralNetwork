using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnistViewer
{
    public class NetworkPresenter
    {
        public NetworkPresenter( Form1 view, TrainingForm console, NetworkModel model )
        {
            console.Show();

            model.SetConsoleVisible = console.SetVisiblity;
            model.Log = console.Log;
            model.ShowImage = view.ShowImage;
            model.InitView = view.Init;
            model.SetMaxImageCount = view.SetMaxImageCount;

            view.UpdateCurrentImage = model.UpdateCurrentImage;
            view.ReadImages = model.ReadImages;
#if TEST_NETWORK_MATH
            view.CreateNetwork = model.CreateTestNetwork;
            view.TrainNetwork = model.TrainTestNetwork;
#else
            view.CreateNetwork = model.CreateNetwork;
            view.TrainNetwork = model.TrainNetwork;
#endif
            view.SetIfsImagesPath = (path) => model.IfsImagesPath = path;
            view.SetIfsLabelsPath = (path) => model.IfsLabelsPath = path;
            view.Epochs = (count) => model.Epochs = count;
            view.BatchSize = (count) => model.BatchSize = count;
            view.LearningRate = (value) => model.LearningRate = value;
            view.IncludeTestData = (setting) => model.IncludeTestData = setting;

            model.Init();
        }
    }
}
