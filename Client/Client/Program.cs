using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6789);
                EndPoint ep = ip;
                string s = "Hello server!";
                byte[] gui = Encoding.ASCII.GetBytes(s);
                client.SendTo(gui, ep);

                byte[] nhan = new byte[1024];

                client.ReceiveFrom(nhan, ref ep);

                string r = Encoding.ASCII.GetString(nhan);

                Console.WriteLine("Server: {0}", r);

                client.Close();
            }
            catch (SocketException)
            {
                Console.WriteLine("Server khong hop le.");
            }
        }
    }
}
