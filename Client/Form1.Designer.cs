namespace Client;

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
        btnConnect = new Button();
        btnDisconnect = new Button();
        lblStatus = new Label();
        lblCommand = new Label();
        cmbCommand = new ComboBox();
        btnSend = new Button();
        lblResult = new Label();
        txtResult = new RichTextBox();
        txtPassword = new TextBox();
        lblPassword = new Label();
        txtUsername = new TextBox();
        lblUsername = new Label();
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
        // btnConnect
        // 
        btnConnect.Location = new Point(21, 200);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(330, 40);
        btnConnect.TabIndex = 4;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Enabled = false;
        btnDisconnect.Location = new Point(357, 200);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(330, 40);
        btnDisconnect.TabIndex = 5;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.ForeColor = Color.DimGray;
        lblStatus.Location = new Point(21, 266);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(109, 20);
        lblStatus.TabIndex = 6;
        lblStatus.Text = "⬤ Chưa kết nối";
        // 
        // lblCommand
        // 
        lblCommand.AutoSize = true;
        lblCommand.Location = new Point(21, 319);
        lblCommand.Name = "lblCommand";
        lblCommand.Size = new Size(78, 20);
        lblCommand.TabIndex = 7;
        lblCommand.Text = "Command";
        // 
        // cmbCommand
        // 
        cmbCommand.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCommand.FormattingEnabled = true;
        cmbCommand.Items.AddRange(new object[] { "hostname", "dir", "ipconfig" });
        cmbCommand.Location = new Point(21, 354);
        cmbCommand.Name = "cmbCommand";
        cmbCommand.Size = new Size(666, 28);
        cmbCommand.TabIndex = 8;
        // 
        // btnSend
        // 
        btnSend.Enabled = false;
        btnSend.Location = new Point(287, 403);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(136, 40);
        btnSend.TabIndex = 9;
        btnSend.Text = "Send Command";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // lblResult
        // 
        lblResult.AutoSize = true;
        lblResult.Location = new Point(21, 468);
        lblResult.Name = "lblResult";
        lblResult.Size = new Size(49, 20);
        lblResult.TabIndex = 10;
        lblResult.Text = "Result";
        // 
        // txtResult
        // 
        txtResult.BackColor = SystemColors.Window;
        txtResult.ForeColor = Color.DimGray;
        txtResult.Location = new Point(21, 505);
        txtResult.Name = "txtResult";
        txtResult.ReadOnly = true;
        txtResult.Size = new Size(666, 132);
        txtResult.TabIndex = 12;
        txtResult.Text = "";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(357, 145);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(330, 27);
        txtPassword.TabIndex = 16;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(357, 113);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.TabIndex = 15;
        lblPassword.Text = "Password";
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(21, 145);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(330, 27);
        txtUsername.TabIndex = 14;
        txtUsername.Text = "admin";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(21, 113);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(75, 20);
        lblUsername.TabIndex = 13;
        lblUsername.Text = "Username";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(709, 663);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblUsername);
        Controls.Add(txtResult);
        Controls.Add(lblResult);
        Controls.Add(btnSend);
        Controls.Add(cmbCommand);
        Controls.Add(lblCommand);
        Controls.Add(lblStatus);
        Controls.Add(btnDisconnect);
        Controls.Add(btnConnect);
        Controls.Add(txtPort);
        Controls.Add(lblPort);
        Controls.Add(txtServerIP);
        Controls.Add(lbServerIP);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        Text = " Remote Command Client";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbServerIP;
    private TextBox txtServerIP;
    private Label lblPort;
    private TextBox txtPort;
    private Button btnConnect;
    private Button btnDisconnect;
    private Label lblStatus;
    private Label lblCommand;
    private ComboBox cmbCommand;
    private Button btnSend;
    private Label lblResult;
    private RichTextBox txtResult;
    private TextBox txtPassword;
    private Label lblPassword;
    private TextBox txtUsername;
    private Label lblUsername;
}
