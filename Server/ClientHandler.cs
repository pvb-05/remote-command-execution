// Đây là mã tạm thời để thử nghiệm kết nối
using System;
using System.Net.Sockets;

namespace Server
{
	public class ClientHandler
	{
		// Chữ ký hàm tĩnh (static) khớp với lệnh gọi của bạn
		public static void Handle(TcpClient client)
		{
			Console.WriteLine("ClientHandler tạm thời đã tiếp nhận kết nối!");

			// Đóng kết nối tạm thời để giải phóng tài nguyên
			client.Close();
		}
	}
}