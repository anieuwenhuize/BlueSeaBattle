using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSeaBattle
{
    class GameEngine
    {
        private IUpdateable Form;

        public GameEngine(IUpdateable form)
        {
            Form = form;
        }

        public void Start()
        {

        }
    }
}
