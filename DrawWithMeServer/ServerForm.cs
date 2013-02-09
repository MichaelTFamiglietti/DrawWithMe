using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Alta.Net;
using DrawWithMe;

namespace DrawWithMeServer
{
    public partial class ServerForm : Form
    {
        public ServerHandler Server;

        public ServerForm()
        {
            InitializeComponent();
        }

        #region Events
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Server = new ServerHandler();
            Server.PreventDuplicate = Dupe.Nothing;
            Server.SynchronizingObject = this;
            Server.ReceivedTcp += Server_ReceivedTcp;
            Server.NewConnection += Server_NewConnection;
            Server.LostConnection += Server_LostConnection;
            Server.AuthValidation = Server_AuthValidation;
            Server.Start(IPAddress.Any, (int)Port.Value, -1, 50); //3rd is the max amount of connects, 4th is the amount of queued logins
            WriteLine("Server Started");
        }

        private bool Server_AuthValidation(NetHandler handler, PacketEventArgs e)
        {
            //Check username and password
            return true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(textMessage.Text != "")
                SendToAll(ASCIIEncoding.ASCII.GetBytes(textMessage.Text), true);
            textMessage.Clear();
        }
        #endregion

        #region Server Events
        private void Server_LostConnection(object sender, NetEventArgs e)
        {
            Write("Lost user: " + e.Client.ToString());
        }

        private void Server_NewConnection(object sender, NetEventArgs e)
        {
            Write("New user: " + e.Client.IP.ToString());
        }

        private void Server_ReceivedTcp(object sender, PacketEventArgs e)
        {

        }
        #endregion

        #region Write
        public void Write(string msg)
        {
            new MethodInvoker(() =>
            {
                textConsole.Text += msg;
            }).Invoke();
        }

        public void WriteLine(string msg)
        {
            Write(msg + "\r\n");
        }
        #endregion

        private void SendToAll(byte[] data, bool write)
        {
            foreach (ClientData c in Server.Clients)
                Server.SendTcp(c, data);
            if (write)
                WriteLine(ASCIIEncoding.ASCII.GetString(data));
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }
    }
}
