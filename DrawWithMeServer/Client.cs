using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace DrawWithMeServer
{
    public class Client
    {
        public Socket Socket;
        public byte[] Buffer;

        public Client() { }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                string message = Encoding.ASCII.GetString(Buffer);
            }
            catch
            {

            }
        }
    }
}
