using System;
using System.Windows.Forms;

namespace BattleBabs_Client
{
    public partial class RefFormSettings : Form
    {
        public static Boolean isShowing = false;
        public RefFormSettings()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            isShowing = false;
        }

        private void RefFormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
