using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniNetwork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model model = new Model();
            View view = new View();

            model.Init();

            model.Log = view.Log;
            model.Network.Log = view.Log;
            model.Network.DisplayLayers = view.DisplayLayers;
            view.SetInput = (value) => model.Network.Input = value;
            view.SetTarget = (value) => model.Network.Target = value;
            view.SetLearningRate = (value) => model.Network.LearningRate = value;
            view.SetEpochs = (value) => model.Network.Epochs = value;
            view.Start = model.Network.Train;

            Application.Run(view);
        }
    }
}
