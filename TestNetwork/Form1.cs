using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network;

namespace TestNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Network.NeuralNetwork Network;
        private void button_create_Click(object sender, EventArgs e)
        {
            Network = new Network.NeuralNetwork();
            Network.AddLayer(20); // input layer
            Network.AddLayer(15);// hidden layer
            Network.AddLayer(10); // output layer
        }
    }
}
