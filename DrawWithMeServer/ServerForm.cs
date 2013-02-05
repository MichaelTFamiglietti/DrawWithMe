using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace DrawWithMeServer
{
    public partial class ServerForm : Form
    {

        public ServerForm()
        {
            InitializeComponent();
        }

        #region Events
        private void buttonStart_Click(object sender, EventArgs e)
        {

            StartServer();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(textMessage.Text != "")
                WriteLine(textMessage.Text);
            textMessage.Clear();
        }
        #endregion

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }
    }
}
