using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SimpleServer
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, 909));
            socket.Listen(0);

            var clientSocket = socket.Accept();
            Console.WriteLine("Новое подключение.");
            byte[] buffer = new byte[1024];
            clientSocket.Receive(buffer);

            Console.WriteLine("Сервер получил следующее сообщение:");
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
            Console.ReadLine();

        }
    }
}
