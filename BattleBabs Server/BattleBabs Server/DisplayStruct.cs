using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BattleBabs_Server
{
    public partial class DisplayStruct : Form
    {
        Thread guiUpdate;
        public DisplayStruct()
        {
            InitializeComponent();
            guiUpdate = new Thread(new ThreadStart(updateComponents))
            {
                Name = "DisplayUpdate",
                IsBackground = true
            };
        }

        private static void updateComponents()
        {
            Thread.Sleep(200);

        }

        private void updateLabel(Label label, string message)
        {

        }
    }
}
