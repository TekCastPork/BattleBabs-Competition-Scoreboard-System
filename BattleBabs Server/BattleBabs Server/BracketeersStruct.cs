using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleBabs_Server
{
    public partial class BracketeersStruct : Form
    {
        public static Boolean isShowing = false;
        public BracketeersStruct()
        {
            InitializeComponent();
        }

        private void BracketeersStruct_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShowing = false;
            e.Cancel = true;
            this.Hide();
        }
    }
}
