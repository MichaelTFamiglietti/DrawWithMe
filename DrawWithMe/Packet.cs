using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DrawWithMe
{
    [Serializable]
    public class Packet
    {
        public string Message;
        public List<Point> Points;
        
        public Packet(string message)
        {
            Message = message;
        }

        public byte[] GetData()
        {
            byte[] bytes;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, this);
            bytes = ms.ToArray();
            return bytes;
        }
    }
}
