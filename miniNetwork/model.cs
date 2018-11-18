using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniNetwork
{
    public class Model
    {
        public Action<string> Log;
        public MiniNetwork Network; 

        public Model()
        {

        }
        public void Init()
        {
            Network = new MiniNetwork();
        }
    }
}
