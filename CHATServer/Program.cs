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
            Socket socket = new Socket(AddressFamily.InterNetwork,
              SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(
                IPAddress.Any, 2345
                );
            try
            {
                socket.Bind(endPoint);
                socket.Listen(10);
            }
            catch
            {
                System.Console.WriteLine("Impossible de démarrer le serveur");
                Environment.Exit(-1);
            }

            try
            {
                var clientSocket = socket.Accept();
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
                Console.WriteLine("La communication avec le client n'est pas possible");
            }
            finally
            {
                if (socket.Connected)
                {     
                    socket.Shutdown(SocketShutdown.Both);
                }
                socket.Close();
            }
        }
    }
}
