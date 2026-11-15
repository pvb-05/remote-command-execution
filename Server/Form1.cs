using System.Data.Common;
using System.Net.Sockets;
using System.Text.Json;
using Message = Shared.Message;

namespace Server;

public partial class Form1 : Form
{
    private TcpServer server;
    public Form1()
    {
        InitializeComponent();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        //Start
        try
        {
            // Máy Bắc IPV4: 26.206.95.190
            string ip = txtServerIP.Text;
            int port = int.Parse(txtPort.Text);
            string password = txtPassword.Text;

            if (password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu Server!");
                return;
            }

            server = new TcpServer(ip, port, password, AddLog);

            Thread thread = new Thread(() =>
            {
                server.Start();
            });

            thread.IsBackground = true;
            thread.Start();

            lblStatus.Text = "⬤ Server đang hoạt động";
            lblStatus.ForeColor = Color.LimeGreen;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }
        catch (Exception ex)
        {
            server.Stop();
            MessageBox.Show("Lỗi: " + ex.Message);
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        // Stop
        server.Stop();
        lblStatus.Text = "⬤ Server chưa hoạt động";
        lblStatus.ForeColor = Color.DimGray;

        btnStart.Enabled = true;
        btnStop.Enabled = false;
    }

    private void AddLog(string message)
    {
        // Logs
        if (txtLogs.InvokeRequired)
        {
            txtLogs.Invoke(new Action(() => AddLog(message)));
            return;
        }

        string time = DateTime.Now.ToString("HH:mm:ss");

        txtLogs.AppendText(
            "[" + time + "] " + message + Environment.NewLine);
    }
}
