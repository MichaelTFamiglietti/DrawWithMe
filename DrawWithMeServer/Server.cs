using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace DrawWithMeServer
{
    public class Server
    {
        public ServerForm Main;
        public Socket ServerSocket;

        public Server(ServerForm main)
        {
            Main = main;
        }

        public void StartServer()
        {
            try
            {
                WriteLine("Starting Server");
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Bind(new IPEndPoint(IPAddress.Any, (int)Main.Port.Value));
                ServerSocket.Listen(0);
                ServerSocket.BeginAccept(new AsyncCallback(AccepptCallback), null);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private void AccepptCallback(IAsyncResult ar)
        {
            try
            {
                WriteLine("Server Started");
                var c = new Client();
                c.Socket = ServerSocket.EndAccept(ar);
                c.Buffer = new byte[c.Socket.ReceiveBufferSize];
                c.Socket.BeginReceive(c.Buffer, 0, c.Buffer.Length, SocketFlags.None, new AsyncCallback(c.ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        #region Write to console
        public void WriteLine(string msg)
        {
            Write(msg + "\r\n");
        }

        public void Write(string msg)
        {
            new MethodInvoker(() =>
            {
                Main.textConsole.Text += msg;
            }).Invoke();
        }
        #endregion
    }
}
