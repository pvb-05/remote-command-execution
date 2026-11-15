using System.Data.Common;
using System.Net.Sockets;
using System.Text.Json;
using Message = Shared.Message;

namespace Client;

public partial class Form1 : Form
{
    TCPClient client = new TCPClient();

    public Form1()
    {
        InitializeComponent();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        //Connect
        try
        {
            string ip = txtServerIP.Text;
            int port = int.Parse(txtPort.Text);

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            // Kết nối 
            client.Connect(ip, port);

            // Đăng nhập
            Message response = client.Login(username, password);

            if (response.Success)
            {
                lblStatus.Text = "⬤ Đã kết nối";
                lblStatus.ForeColor = Color.LimeGreen;

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSend.Enabled = true;

                MessageBox.Show("Đăng nhập thành công!");
            }
            else
            {
                client.Disconnect();
                MessageBox.Show(response.Output);
            }

        }
        catch (Exception ex)
        {
            client.Disconnect();
            MessageBox.Show("Lỗi kết nối: " + ex.Message);
        }
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
        // Disconnect
        client.Disconnect();
        lblStatus.Text = "⬤ Chưa kết nối";
        lblStatus.ForeColor = Color.Gray;

        btnConnect.Enabled = true;
        btnDisconnect.Enabled = false;
        btnSend.Enabled = false;

        txtPassword.Clear();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        // Send Command
        try
        {
            string command = cmbCommand.Text;

            Message response = client.SendCommand(command);

            txtResult.Text = response.Output;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);

            lblStatus.Text = "⬤ Chưa kết nối";
            lblStatus.ForeColor = Color.Gray;

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;

            client.Disconnect();
        }
    }
}
