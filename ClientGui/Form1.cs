using System.Data.Common;
using System.Net.Sockets;
using System.Text.Json;

namespace ClientGui;

public partial class Form1 : Form
{
    TcpClient client = new TcpClient();
    StreamReader reader;
    StreamWriter writer;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {
        //Connect
        try
        {
            string ip = txtServerIP.Text;
            int port = int.Parse(txtPort.Text);

            client = new TcpClient();
            client.Connect(ip, port);

            NetworkStream stream = client.GetStream();

            // Giới hạn thời gian chờ
            stream.ReadTimeout = 5000;
            stream.WriteTimeout = 5000;

            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            lblStatus.Text = "Đã kết nối";

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnSend.Enabled = true;
        }
        catch (Exception ex)
        {
            client.Close();
            MessageBox.Show("Lỗi kết nối: " + ex.Message);
        }

    }

    private void label1_Click_1(object sender, EventArgs e)
    {
        // Disconnect
        Disconnect();
    }

    private void label1_Click_2(object sender, EventArgs e)
    {
        // Send Command
        try
        {
            string command = cmbCommand.Text;

            Shared.Message request = new Shared.Message();
            request.Type = "COMMAND";
            request.Command = command;

            // Chuyển đối tượng thành JSON
            string json = JsonSerializer.Serialize(request);

            // Gửi dữ liệu
            writer.WriteLine(json);

            // Nhận kết quả
            string result = reader.ReadLine();

            if (result == null)
            {
                MessageBox.Show("Server đã ngắt kết nối");
                Disconnect();
                return;
            }

            // Chuyển JSON thành đối tượng
            Shared.Message response =
                JsonSerializer.Deserialize<Shared.Message>(result);

            if (response != null)
            {
                txtResult.Text = response.Output;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
            Disconnect();
        }
    }

    private void Disconnect()
    {
        client.Close();

        lblStatus.Text = "Chưa kết nối";

        btnConnect.Enabled = true;
        btnDisconnect.Enabled = false;
        btnSend.Enabled = false;
    }
}
