using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPEndPoint ip = new IPEndPoint(IPAddress.Any,6789);
            server.Bind(ip);

            byte[] nhan = new byte[1024];
            EndPoint ep = ip;
            server.ReceiveFrom(nhan,ref ep);
            string r = Encoding.ASCII.GetString(nhan);
            Console.WriteLine("Client: {0}", r);

            string s = "Hello Client!";
            byte[] gui = Encoding.ASCII.GetBytes(s);
            server.SendTo(gui, ep);

            server.Close();
        }
    }
}
