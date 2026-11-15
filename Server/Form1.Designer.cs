namespace Server;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        lbServerIP = new Label();
        txtServerIP = new TextBox();
        lblPort = new Label();
        txtPort = new TextBox();
        btnStart = new Button();
        btnStop = new Button();
        lblStatus = new Label();
        lblLogs = new Label();
        txtLogs = new RichTextBox();
        lblUsername = new Label();
        lblPassword = new Label();
        txtPassword = new TextBox();
        txtUsername = new TextBox();
        SuspendLayout();
        // 
        // lbServerIP
        // 
        lbServerIP.AutoSize = true;
        lbServerIP.Location = new Point(21, 26);
        lbServerIP.Name = "lbServerIP";
        lbServerIP.Size = new Size(66, 20);
        lbServerIP.TabIndex = 0;
        lbServerIP.Text = "Server IP";
        // 
        // txtServerIP
        // 
        txtServerIP.Location = new Point(21, 65);
        txtServerIP.Name = "txtServerIP";
        txtServerIP.Size = new Size(330, 27);
        txtServerIP.TabIndex = 1;
        txtServerIP.Text = "127.0.0.1";
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new Point(357, 26);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(35, 20);
        lblPort.TabIndex = 2;
        lblPort.Text = "Port";
        // 
        // txtPort
        // 
        txtPort.Location = new Point(357, 65);
        txtPort.Name = "txtPort";
        txtPort.Size = new Size(330, 27);
        txtPort.TabIndex = 3;
        txtPort.Text = "5000";
        // 
        // btnStart
        // 
        btnStart.Location = new Point(21, 216);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(330, 40);
        btnStart.TabIndex = 4;
        btnStart.Text = "Start";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += btnStart_Click;
        // 
        // btnStop
        // 
        btnStop.Enabled = false;
        btnStop.Location = new Point(357, 216);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(330, 40);
        btnStop.TabIndex = 5;
        btnStop.Text = "Stop";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.ForeColor = Color.DimGray;
        lblStatus.Location = new Point(21, 287);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(176, 20);
        lblStatus.TabIndex = 6;
        lblStatus.Text = "⬤ Server chưa hoạt động";
        // 
        // lblLogs
        // 
        lblLogs.AutoSize = true;
        lblLogs.Location = new Point(21, 345);
        lblLogs.Name = "lblLogs";
        lblLogs.Size = new Size(85, 20);
        lblLogs.TabIndex = 10;
        lblLogs.Text = "Server Logs";
        // 
        // txtLogs
        // 
        txtLogs.BackColor = SystemColors.Window;
        txtLogs.ForeColor = Color.DimGray;
        txtLogs.Location = new Point(21, 396);
        txtLogs.Name = "txtLogs";
        txtLogs.ReadOnly = true;
        txtLogs.Size = new Size(666, 138);
        txtLogs.TabIndex = 12;
        txtLogs.Text = "";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(21, 122);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(75, 20);
        lblUsername.TabIndex = 13;
        lblUsername.Text = "Username";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(357, 122);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.TabIndex = 14;
        lblPassword.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(357, 158);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(330, 27);
        txtPassword.TabIndex = 16;
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(21, 158);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(330, 27);
        txtUsername.TabIndex = 15;
        txtUsername.Text = "admin";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(709, 563);
        Controls.Add(txtPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(lblUsername);
        Controls.Add(txtLogs);
        Controls.Add(lblLogs);
        Controls.Add(lblStatus);
        Controls.Add(btnStop);
        Controls.Add(btnStart);
        Controls.Add(txtPort);
        Controls.Add(lblPort);
        Controls.Add(txtServerIP);
        Controls.Add(lbServerIP);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        Text = " Remote Command Server";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbServerIP;
    private TextBox txtServerIP;
    private Label lblPort;
    private TextBox txtPort;
    private Button btnStart;
    private Button btnStop;
    private Label lblStatus;
    private Label lblCommand;
    private ComboBox cmbCommand;
    private Button btnSend;
    private Label lblLogs;
    private RichTextBox txtLogs;
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private TextBox txtUsername;
}
