using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class TcpServer
    {
        private TcpListener listener;
        private Authentication auth;
        private Action<string> log;
        private volatile bool isRunning = false;

        private List<TcpClient> clients = new List<TcpClient>();

        public TcpServer(string ip, int port, string password, Action<string> log)
        {
            // 192.168.100.90
            listener = new TcpListener(IPAddress.Parse(ip), port);
            auth = new Authentication(password);
            this.log = log;
        }

        // Khởi động Server
        public void Start()
        {
            try
            {
                listener.Start();
                isRunning = true;
                log("Server đang chạy tại 127.0.0.1:5000");

                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    // Lưu Client vừa kết nối
                    lock (clients) { clients.Add(client); }

                    Thread thread = new Thread(() => {
                        ClientHandler.Handle(client, log, auth);

                        // Xóa client khi ngắt kết nối
                        lock (clients) { clients.Remove(client); }

                    });

                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            catch (SocketException)
            {
                // Khi Stop() đóng listener, AcceptTcpClient sẽ kết thúc
            }
            finally
            {
                isRunning = false;
                listener.Stop();
            }
        }

        // Dừng Server
        public void Stop()
        {
            isRunning = false;
            listener.Stop();

            // Ngắt tất cả Client đang kết nối
            lock (clients)
            {
                foreach (TcpClient client in clients)
                {
                    client.Close();
                }

                clients.Clear();
            }

            log("Server đã dừng hoạt động");
        }
    }
}
