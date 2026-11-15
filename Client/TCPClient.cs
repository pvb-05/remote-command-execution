using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using Message = Shared.Message;

namespace Client
{
    public class TCPClient
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public void Connect(string ip, int port)
        {
            client = new TcpClient();
            client.Connect(ip, port);

            NetworkStream stream = client.GetStream();

            stream.ReadTimeout = 5000;
            stream.WriteTimeout = 5000;

            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }

        public Message SendCommand(string command)
        {
            Message request = new Message();
            request.Type = "COMMAND";
            request.Command = command;

            string json = JsonSerializer.Serialize(request);

            writer.WriteLine(json);

            string result = reader.ReadLine();

            if (result == null)
            {
                throw new Exception("Server đã ngắt kết nối");
            }

            Message response = JsonSerializer.Deserialize<Message>(result);

            if (response == null)
            {
                throw new Exception("Phản hồi không hợp lệ");
            }

            return response;
        }

        public void Disconnect()
        {
            if (client != null)
            {
                client.Close();
            }
        }

        public Message Login(string username, string password)
        {
            // Tạo yêu cầu đăng nhập
            Message request = new Message();
            request.Type = "LOGIN";
            request.Username = username;
            request.Password = password;

            // Chuyển thành JSON
            string json = JsonSerializer.Serialize(request);

            // Gửi đến Server
            writer.WriteLine(json);

            // Nhận phản hồi
            string result = reader.ReadLine();

            if (result == null)
            {
                throw new Exception("Server đã ngắt kết nối");
            }

            // Chuyển JSON thành Message
            Message response =
                JsonSerializer.Deserialize<Message>(result);

            if (response == null || response.Type != "LOGIN_RESULT")
            {
                throw new Exception("Phản hồi đăng nhập không hợp lệ");
            }

            return response;
        }
    }
}
