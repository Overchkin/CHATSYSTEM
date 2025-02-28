using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
        }
        Socket.Connect(EndPoint);

        while(true)
            {
                string message = Console.ReadLine();
                If(message == "q")
                {
                    break;
                }
                var buffer = Encoding.UTF8.GetBytes(message);
                Socket.Send(buffer);
            }
    }
}
