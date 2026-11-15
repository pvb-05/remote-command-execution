using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using Message = Shared.Message;

namespace Server
{
    public class ClientHandler
    {
        public static void Handle(TcpClient client, Action<string> log, Authentication auth)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            log("Thread " + threadId + " bắt đầu xử lý Client.");
            //Console.WriteLine("Thread " + threadId + " bắt đầu xử lý Client.");

            bool isAuthenticated = false;

            try
            {
                NetworkStream stream = client.GetStream();
                stream.ReadTimeout = 300000; //(ms)

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

                    log("Client tại Thread " + threadId + " gửi: " + data);
                    // Console.WriteLine("Client tại Thread" + threadId + " gửi: " + data);

                    Message response = new Message();

                    try
                    {
                        // Chuyển JSON thành đối tượng Message
                        Message request = JsonSerializer.Deserialize<Message>(data);

                        if (request == null)
                        {
                            response.Type = "RESULT";
                            response.Success = false;
                            response.Output = "Yêu cầu không hợp lệ";
                        }
                        else if (request.Type == "LOGIN")
                        {
                            bool result = auth.Login(request.Username, request.Password);

                            response.Type = "LOGIN_RESULT";
                            response.Success = result;

                            if (result)
                            {
                                isAuthenticated = true;
                                response.Output = "Đăng nhập thành công";
                                log("Thread " + threadId + ": Đăng nhập thành công");
                            }
                            else
                            {
                                isAuthenticated = false;
                                response.Output = "Sai tài khoản hoặc mật khẩu";
                                log("Thread " + threadId + ": Đăng nhập thất bại");
                            }
                        }
                        else if (request.Type == "COMMAND")
                        {
                            if (!isAuthenticated)
                            {
                                response.Type = "RESULT";
                                response.Success = false;
                                response.Output = "Vui lòng đăng nhập trước!";
                                log("Thread " + threadId + ": Từ chối lệnh do chưa đăng nhập");
                            }
                            else
                            {
                                string command = request.Command;

                                if (command == "hostname" ||
                                    command == "dir" ||
                                    command == "ipconfig")
                                {
                                    response.Type = "RESULT";
                                    response.Output = Command.Execute(command);
                                    response.Success = true;
                                    log("Thread " + threadId + " đã xử lý lệnh: " + command);
                                }
                                else
                                {
                                    response.Type = "RESULT";
                                    response.Output = "Lệnh không được hỗ trợ";
                                    response.Success = false;
                                }
                            }
                        }
                        else
                        {
                            response.Type = "RESULT";
                            response.Success = false;
                            response.Output = "Loại yêu cầu không hợp lệ";
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
                log("Lỗi Thread " + threadId + ": " + ex.Message);
                // Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                client.Close();
                log("Client tại Thread " + threadId + " đã ngắt kết nối");
                //Console.WriteLine("Client đã ngắt kết nối");
            }
        }
    }
}
