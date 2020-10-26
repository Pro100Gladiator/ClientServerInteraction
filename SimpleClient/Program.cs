using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleClient
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.WriteLine("Устанавливаем подключение...");
            socket.Connect("127.0.0.1", 909);
            Console.WriteLine("Подключение успешно установлено.");

            Console.WriteLine("Введите ваше сообщение:");
            string message = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            socket.Send(buffer);
            Console.ReadLine();

        }
    }
}
