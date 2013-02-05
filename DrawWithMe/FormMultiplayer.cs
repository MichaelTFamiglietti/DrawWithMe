using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawWithMe
{
    public partial class FormMultiplayer : Form
    {
        FormDrawWithMe Main;

        public FormMultiplayer(FormDrawWithMe parent)
        {
            InitializeComponent();
            Main = parent;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (textIP.Text != "" && textUsername.Text != "")
            {
                Main.LoginInfo = new LoginInfo(textUsername.Text, textPassword.Text, textIP.Text, (int)Port.Value);
                Main.Online = true;
                this.Close();
            }
            else
                MessageBox.Show("Must fill out every except password.");
        }
    }
}
