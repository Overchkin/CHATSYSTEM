using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;
using NetMQ.Sockets;
using System.Text;

namespace CHATServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint endPoint = new IPEndPoint(
                    IPAddress.Any, 2345
                    );
                socket.Bind(endPoint);
                socket.Listen(10);
                socket.Accept();
                if (ClientSocket.RemoteEndPoint != null)
                {
                    while (true)
                    {
                        Console.WriteLine("Client connecté depuis" + ClientSocket.RemoteEndPoint.ToString());
                        byte[] buffer = new byte[128];
                        int nb = ClientSocket.Receive(buffer);
                        Console.WriteLine("Message reçu: " + Encoding.UTF8.GetString(buffer, 0, nb));
                    }
                }
            }
            catch
            {
                Console.WriteLine("Une erreur s'est produite sur le serveur");
            }
        }
    }
}
