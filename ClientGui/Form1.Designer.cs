namespace ClientGui;

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
        lblPort.Click += label1_Click;
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
        btnConnect.Location = new Point(21, 119);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(330, 40);
        btnConnect.TabIndex = 4;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Enabled = false;
        btnDisconnect.Location = new Point(357, 119);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(330, 40);
        btnDisconnect.TabIndex = 5;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.ForeColor = Color.DimGray;
        lblStatus.Location = new Point(21, 186);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(117, 20);
        lblStatus.TabIndex = 6;
        lblStatus.Text = "⚫ Chưa kết nối";
        lblStatus.Click += label1_Click_1;
        // 
        // lblCommand
        // 
        lblCommand.AutoSize = true;
        lblCommand.Location = new Point(21, 234);
        lblCommand.Name = "lblCommand";
        lblCommand.Size = new Size(78, 20);
        lblCommand.TabIndex = 7;
        lblCommand.Text = "Command";
        lblCommand.Click += label1_Click_2;
        // 
        // cmbCommand
        // 
        cmbCommand.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCommand.FormattingEnabled = true;
        cmbCommand.Items.AddRange(new object[] { "hostname", "dir", "ipconfig" });
        cmbCommand.Location = new Point(21, 274);
        cmbCommand.Name = "cmbCommand";
        cmbCommand.Size = new Size(666, 28);
        cmbCommand.TabIndex = 8;
        // 
        // btnSend
        // 
        btnSend.Enabled = false;
        btnSend.Location = new Point(287, 323);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(136, 40);
        btnSend.TabIndex = 9;
        btnSend.Text = "Send Command";
        btnSend.UseVisualStyleBackColor = true;
        // 
        // lblResult
        // 
        lblResult.AutoSize = true;
        lblResult.Location = new Point(21, 388);
        lblResult.Name = "lblResult";
        lblResult.Size = new Size(49, 20);
        lblResult.TabIndex = 10;
        lblResult.Text = "Result";
        // 
        // txtResult
        // 
        txtResult.BackColor = SystemColors.Window;
        txtResult.ForeColor = Color.DimGray;
        txtResult.Location = new Point(21, 425);
        txtResult.Name = "txtResult";
        txtResult.ReadOnly = true;
        txtResult.ScrollBars = RichTextBoxScrollBars.Vertical;
        txtResult.Size = new Size(666, 120);
        txtResult.TabIndex = 12;
        txtResult.Text = "";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(709, 574);
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
}
