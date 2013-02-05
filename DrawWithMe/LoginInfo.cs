using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DrawWithMe
{
    public class LoginInfo
    {
        public string Username;
        public string Password;
        public IPAddress IP;
        public int Port;

        public LoginInfo(string username, string passowrd, string ip, int port)
        {
            Username = username;
            Password = passowrd;
            IP = IPAddress.Parse(ip);
            Port = port;
        }
    }
}
