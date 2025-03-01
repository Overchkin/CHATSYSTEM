using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CHATClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            var endpoint = new IPEndPoint(
                IPAddress.Loopback,
                2345);


            try
            {
                Socket.Connect(EndPoint);

                Thread t = new Thread(LireMessages);
                t.IsBackground = true;
                t.Start(socket);

                while (true)
                {
                    string? message = Console.ReadLine();
                    if(message == "q")
                    {
                        break;
                    }
                    if(!string.IsNullOrEmpty(message))
                    { 
                        var buffer = Encoding.UTF8.GetBytes(message);
                        Socket.Send(buffer);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Le serveur est injoignable");
            }
            finally
            {
                if(socket.Connected)
                { 
                    Socket.Shutdown(SocketShutdown.Both);
                }
                Socket.Close();
            }

            void LireMessages(object? obj)
            {
                if(obj is Socket socket)
                {
                    while(true)
                    {
                        byte[] buffer = new byte[4096];
                        int read = socket.Receive(buffer);
                        if(read > 0)
                        {
                            var message = Encoding.UTF8.GetString(buffer, 0, read);
                            System.Console.WriteLine(message);
                        }
                    }
                }
            }
        }
    }
}
