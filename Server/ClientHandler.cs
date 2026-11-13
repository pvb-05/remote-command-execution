using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using Shared;
using System.Threading;

namespace Server
{
    public class ClientHandler
    {
        public static void Handle(TcpClient client)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread " + threadId + " bắt đầu xử lý Client.");

            try
            {
                NetworkStream stream = client.GetStream();
                stream.ReadTimeout = 30000; //(ms)

                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                // Nhận dữ liệu liên tục từ Client
                while (true)
                {
                    string data = reader.ReadLine();

                    // Client ngắt kết nối
                    if (data == null)
                    {
                        break;
                    }

                    Console.WriteLine("Client tại Thread" + threadId + " gửi: " + data);

                    Message response = new Message();

                    try
                    {
                        // Chuyển JSON thành đối tượng Message
                        Message request =
                            JsonSerializer.Deserialize<Message>(data);

                        if (request != null)
                        {
                            if (request.Type == "PING")
                            {
                                response.Type = "RESULT";
                                response.Success = true;
                                response.Output = "PONG";
                            }
                            else if (request.Type == "COMMAND")
                            {
                                string command = request.Command;

                                // Kiểm tra các lệnh được phép
                                if (command == "hostname" ||
                                    command == "dir" ||
                                    command == "ipconfig")
                                {
                                    string result = Command.Execute(command);

                                    response.Type = "RESULT";
                                    response.Success = true;
                                    response.Output = result;
                                }
                                else
                                {
                                    response.Type = "RESULT";
                                    response.Success = false;
                                    response.Output = "Lệnh không được hỗ trợ";
                                }
                            }
                            else
                            {
                                response.Type = "RESULT";
                                response.Success = false;
                                response.Output = "Loại yêu cầu không hợp lệ";
                            }
                        }
                        else
                        {
                            response.Type = "RESULT";
                            response.Success = false;
                            response.Output = "Yêu cầu rỗng";
                        }
                    }
                    catch (JsonException)
                    {
                        response.Type = "RESULT";
                        response.Success = false;
                        response.Output = "JSON không hợp lệ";
                    }

                    // Chuyển kết quả thành JSON
                    string json = JsonSerializer.Serialize(response);

                    // Gửi kết quả về Client
                    writer.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine("Client đã ngắt kết nối");
            }
        }
    }
}
