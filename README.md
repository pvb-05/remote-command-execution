# 🖥️ Remote Command Execution

## 📖 Giới thiệu

Dự án mô phỏng mô hình **Client–Server** cho phép client gửi một số lệnh hệ thống được hỗ trợ đến server qua TCP và nhận kết quả. Đây là dự án học tập nhằm tìm hiểu lập trình mạng, giao tiếp giữa các tiến trình và xây dựng giao diện Windows Forms.

> ⚠️ **Chỉ sử dụng trên máy tính của bạn hoặc trong môi trường lab được cho phép.** Chương trình có khả năng thực thi lệnh trên máy chạy server. Không mở cổng server ra Internet hoặc sử dụng để truy cập, điều khiển thiết bị khi chưa được chủ sở hữu cho phép. Giao tiếp hiện chưa được mã hóa; không gửi thông tin nhạy cảm qua kết nối này.

## ✨ Tính năng

- Giao diện Windows Forms riêng cho server và client.
- Server lắng nghe kết nối TCP trên địa chỉ IP và cổng do người dùng cấu hình.
- Client đăng nhập bằng tài khoản `admin` và mật khẩu do server đặt.
- Gửi lệnh và hiển thị kết quả trả về.
- Server ghi log kết nối và có thể dừng các client đang kết nối.
- Các lệnh được hỗ trợ trong phiên bản hiện tại:
  - `hostname` — tên máy đang chạy server.
  - `dir` — liệt kê nội dung thư mục chạy ứng dụng server.
  - `ipconfig` — thông tin cấu hình mạng trên Windows.

Lệnh khác sẽ nhận thông báo không được hỗ trợ.

## 🧰 Công nghệ

- C# và .NET 10 (`net10.0-windows`).
- Windows Forms.
- TCP (`TcpListener`, `TcpClient`) cho kết nối mạng.
- `System.Text.Json` để tuần tự hóa thông điệp JSON.

## 🗂️ Cấu trúc dự án

```text
.
├── Client/                         # Ứng dụng Windows Forms phía client
├── Server/                         # Ứng dụng Windows Forms phía server
├── Shared/                         # Kiểu thông điệp dùng chung
├── Test/                           # Mã kiểm tra/thử nghiệm
├── Reports/                        # Tài liệu báo cáo
├── RemoteCommandExecution.slnx     # Solution
└── README.md
```

## ⚙️ Cài đặt

### Yêu cầu

- Windows.
- .NET 10 SDK có hỗ trợ Windows Desktop/Windows Forms.
- Git (nếu muốn clone repository).

### Clone và build

```bash
git clone https://github.com/pvb-05/remote-command-execution.git
cd remote-command-execution
dotnet build RemoteCommandExecution.slnx
```

## 🚀 Cách sử dụng

1. Chạy project `Server` trên máy bạn sở hữu hoặc máy lab được cấp phép:

   ```bash
   dotnet run --project Server/Server.csproj
   ```

2. Trong ứng dụng server, nhập địa chỉ IP, cổng và mật khẩu; nhấn **Start**. Để thử nghiệm trên cùng một máy, dùng địa chỉ loopback `127.0.0.1`.
3. Chạy client:

   ```bash
   dotnet run --project Client/Client.csproj
   ```

4. Nhập địa chỉ IP và cổng giống cấu hình server, tài khoản `admin` cùng mật khẩu đã đặt ở server, sau đó kết nối.
5. Chọn một lệnh được hỗ trợ và gửi để xem kết quả. Ngắt kết nối client và dừng server sau khi hoàn tất.

> Khi thử nghiệm qua mạng nội bộ, chỉ kết nối các thiết bị bạn được phép quản lý. Không cấu hình port forwarding hay phơi bày server trực tiếp ra Internet.

## 🏗️ Kiến trúc và luồng hoạt động

1. Server tạo TCP listener theo địa chỉ IP/cổng cấu hình và chấp nhận kết nối client.
2. Client gửi thông điệp JSON theo từng dòng. Thông điệp đăng nhập có `Type: "LOGIN"`; yêu cầu lệnh có `Type: "COMMAND"`.
3. Server kiểm tra thông tin đăng nhập (`admin` và mật khẩu server đang chạy).
4. Với phiên đã đăng nhập, server xử lý lệnh trong danh sách cho phép và gửi thông điệp JSON chứa kết quả về client.
5. Client hiển thị kết quả trên giao diện.

`Shared/Message.cs` định nghĩa cấu trúc thông điệp dùng chung giữa client và server.

## 🔌 Giao thức thông điệp

Giao tiếp sử dụng TCP với mỗi thông điệp JSON trên một dòng. Các trường của thông điệp gồm `Type`, `Command`, `Success`, `Output`, `Username` và `Password`.

- Đăng nhập: `Type` là `LOGIN`; thông tin phản hồi có `Type` là `LOGIN_RESULT`.
- Thực thi lệnh giới hạn: `Type` là `COMMAND`; phản hồi chứa trạng thái thành công và nội dung trong `Output`.

Đây là giao thức nội bộ của ứng dụng, không phải API HTTP công khai. Kết nối hiện không mã hóa dữ liệu.

## 🧪 Kiểm thử

Thư mục `Test` chứa mã kiểm tra/thử nghiệm. Có thể chạy project bằng lệnh:

```bash
dotnet run --project Test/Test.csproj
```

Project kiểm thử hiện được cấu hình như một ứng dụng console; nếu cần chạy trong môi trường khác, hãy kiểm tra cấu hình .NET và Windows Desktop SDK tương ứng.

## 👤 Tác giả

**Phan Văn Bắc**  
Email: [phanvanbac15112005@gmail.com](mailto:phanvanbac15112005@gmail.com)

## 📚 Tài liệu tham khảo và giấy phép

- [Tài liệu .NET](https://learn.microsoft.com/dotnet/)
- [Tài liệu Windows Forms](https://learn.microsoft.com/dotnet/desktop/winforms/)
- Repository chưa nêu giấy phép. Vui lòng liên hệ tác giả trước khi sử dụng hoặc phân phối lại ngoài phạm vi học tập.
