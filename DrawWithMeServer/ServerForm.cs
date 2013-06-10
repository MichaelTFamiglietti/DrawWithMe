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
        public int ClearCount = 0;
        public Point CanvasSize = new Point(469, 402);
        
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
            WriteLine("Lost user from: " + e.Client.IP.ToString());
        }

        private void Server_NewConnection(object sender, NetEventArgs e)
        {
            WriteLine("New user from: " + e.Client.IP.ToString());
            Server.SendTcp(e.Client, Encoding.ASCII.GetBytes("%r" + CanvasSize.X + "," + CanvasSize.Y));
        }

        private void Server_ReceivedTcp(object sender, PacketEventArgs e)
        {
            string message = Encoding.ASCII.GetString(e.Data);

            if (message.StartsWith("%d"))
            {
                //Draw
                SendToAll(e.Data, false);
            }
            else if (message.StartsWith("%m"))
            {
                //Message
                message = message.Replace("%m", "");
                SendToAll(Encoding.ASCII.GetBytes("%m" + e.Client.IP + ": " + message), true);
            }
            else if (message.StartsWith("%c"))
            {
                message = message.Replace("%c", "");
                WriteLine(e.Client.IP + ": has requested a clear.");
                ClearCount++;
                if (ClearCount >= 10)
                {
                    SendToAll(Encoding.ASCII.GetBytes("%c"), false);
                    WriteLine("Cleared Canvas");
                    ClearCount = 0;
                }
            }
            else if (message.StartsWith("%r"))
            {
                message = message.Replace("%r", "");
                string[] split = message.Split(',');
                CanvasSize.X = Int32.Parse(split[0]);
                CanvasSize.Y = Int32.Parse(split[1]);
                SendToAll(Encoding.ASCII.GetBytes("%r" + CanvasSize.X + "," + CanvasSize.Y), false);
            }

            textConsole.SelectionStart = textConsole.Text.Length;
            textConsole.ScrollToCaret();
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
