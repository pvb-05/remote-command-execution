using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class TcpServer
    {
        private TcpListener listener;

        public TcpServer()
        {
            listener = new TcpListener(IPAddress.Loopback, 5000);  // IPAddress.Loopback: 127.0.0.1 (hằng số)
        }

        public void Start()
        {
            listener.Start();

            Console.WriteLine("Server đang chạy tại 127.0.0.1:5000");

            while (true)
            {
                // Chờ và chấp nhận Client kết nối
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Client đã kết nối!");

                // Giao cho ClientHandler xử lý 
                Thread thread = new Thread(() =>
                {
                    ClientHandler.Handle(client);
                });

                thread.IsBackground = true;
                thread.Start();
            }
        }
    }
}
