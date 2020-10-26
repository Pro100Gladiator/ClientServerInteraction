using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8082;

            #region TCP

            //var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            //var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Console.WriteLine("Write down your message:");
            //var message = Console.ReadLine();

            //var data = Encoding.UTF8.GetBytes(message);

            //tcpSocket.Connect(tcpEndPoint);
            //tcpSocket.Send(data);

            //var buffer = new byte[256];
            //var size = 0;
            //var answer = new StringBuilder();

            //do
            //{
            //    size = tcpSocket.Receive(buffer);
            //    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            //}
            //while (tcpSocket.Available > 0);

            //Console.WriteLine(answer.ToString());

            //tcpSocket.Shutdown(SocketShutdown.Both);
            //tcpSocket.Close();

            //Console.ReadKey();
            #endregion

            #region UDP
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                Console.WriteLine("Write your message: ");
                var message = Console.ReadLine();

                EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);

                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = udpSocket.ReceiveFrom(buffer, ref serverEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (udpSocket.Available > 0);

                Console.WriteLine(data);
                //Console.ReadLine();
            }

            #endregion
        }
    }
}
