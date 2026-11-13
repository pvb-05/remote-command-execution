using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using Shared;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            try
            {
                // Kết nối tới Server
                client.Connect("127.0.0.1", 5000);
                Console.WriteLine("Đã kết nối Server!");

                // Tạo luồng gửi và nhận dữ liệu
                NetworkStream stream = client.GetStream();

                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                // Cho phép nhập nhiều yêu cầu
                while (true)
                {
                    Console.Write("\nNhập yêu cầu (exit để thoát): ");
                    string command = Console.ReadLine();
                    command = command.Trim().ToLower();

                    // Kiểm tra lệnh thoát
                    if (command == null || command == "exit")
                    {
                        break;
                    }

                    // Tạo thông điệp gửi đến Server
                    Message request = new Message();
                    if (command == "ping")
                    {
                        request.Type = "PING";
                    }
                    else
                    {
                        request.Type = "COMMAND";
                        request.Command = command;
                    }

                    // Chuyển đối tượng sang JSON
                    string json = JsonSerializer.Serialize(request);

                    // Gửi yêu cầu
                    writer.WriteLine(json);

                    Console.WriteLine("Đã gửi: " + json);

                    // Nhận phản hồi
                    string result = reader.ReadLine();

                    if (result == null)
                    {
                        Console.WriteLine("Server đã ngắt kết nối.");
                        break;
                    }

                    // Chuyển JSON thành đối tượng Message
                    Message response =
                        JsonSerializer.Deserialize<Message>(result);

                    if (response != null)
                    {
                        Console.WriteLine("Server trả về: " + response.Output);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine("Đã ngắt kết nối Server.");
            }
        }
    }
}
