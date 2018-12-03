using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Neurons are a conceptual helper class
    /// they don't really do anything except hold a count
    /// </summary>
    public class Neuron
    {
        public Layer Parent { get; set; }
        public int NeuronID { get; set; }
        public Neuron(int myNeuronID, Layer myParent)
        {
            NeuronID = myNeuronID;
            Parent = myParent;
        }

        public double Activation
        {
            get
            {
                return Parent.Activations[NeuronID];
            }
            set
            {
                Parent.Activations[NeuronID] = value;
            }
        }
    }
}
