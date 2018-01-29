using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleBabs_Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Applying setting changes.");
            GameUtility.alterGameTime((int)timerCount.Value);
            GameUtility.useSeeded = seedBox.Checked;
            try // this try will keep the parsing of the SEED value from crashing the program incase the user enters a letter or symbol
            {
                GameUtility.SEED = int.Parse(seedText.Text);
            } catch (Exception e1)
            {
                Console.WriteLine("Exception! {0}", e1.ToString());
            }
            this.Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
