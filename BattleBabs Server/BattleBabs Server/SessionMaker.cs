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
    public partial class SessionMaker : Form
    {
        public static Boolean isVisible = false;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SessionMaker()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //grab names and team count, create data structs and session stuff
            logger.Info("OK button pushed, checking state of session name before doing anything...");
            if (String.IsNullOrWhiteSpace(nameBox.Text))
            {
                logger.Error("Session name box was null, empty, or whitespace! Cannot create Session! Warning user...");
                MessageBox.Show("Session name was null, empty, or whitespace! Please enter a valid session name.");
                nameBox.Text = String.Empty;
            } else
            {
                logger.Info("Session name box has a valid text string, creating Session...");
                TextBox[] boxes = { team1, team2, team3, team4, team5, team6, team7, team8, team9, team10, team11, team12, team13, team14, team15, team16 };
                Session session = new Session();
                session.clearList();
                session.teamCount = 0;
                for(int i = 0; i < boxes.Length; i++)
                {
                    if (String.IsNullOrWhiteSpace(boxes[i].Text))
                    {

                    }
                    else
                    {
                        session.teamCount++;
                        session.insertNewTeam(boxes[i].Text, 0);
                    }                    
                }
                GameData.saveSessionByName(session, nameBox.Text);
                this.Hide();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            isVisible = false;
            logger.Warn("Session Creator was cancelled!");
        }
    }
}
