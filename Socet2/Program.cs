using System.Net.Sockets;
using System.Net;

namespace Socet2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("207.46.197.32");
            IPEndPoint ep = new IPEndPoint(ip, 80);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                s.Connect(ep);
                if (s.Connected)
                {
                    String strSend = "GET\r\n\r\n";
                    s.Send(System.Text.Encoding.ASCII.GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int l;

                    do
                    {
                        l = s.Receive(buffer);
                        Console.WriteLine(System.Text.Encoding.ASCII.GetString(buffer, 0, l));
                    } while (l > 0);
                }


                Console.ReadLine();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}