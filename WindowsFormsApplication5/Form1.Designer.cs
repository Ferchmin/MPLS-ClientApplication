namespace ClientApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReceiverSwitch = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSwitchReceiver = new System.Windows.Forms.ComboBox();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(5, 25);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(146, 20);
            this.tbFilePath.TabIndex = 0;
            this.tbFilePath.Text = "C:\\Users\\Piotrek\\Desktop\\Config Files\\clientsConfigFiles\\client1.xml";
            this.tbFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(157, 25);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnLoadConfig.TabIndex = 1;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ConfigPath:";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.Location = new System.Drawing.Point(5, 220);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(227, 42);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnEnableDataFlow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New receiver";
            // 
            // btnReceiverSwitch
            // 
            this.btnReceiverSwitch.Enabled = false;
            this.btnReceiverSwitch.Location = new System.Drawing.Point(157, 64);
            this.btnReceiverSwitch.Name = "btnReceiverSwitch";
            this.btnReceiverSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnReceiverSwitch.TabIndex = 6;
            this.btnReceiverSwitch.Text = "Switch";
            this.btnReceiverSwitch.UseVisualStyleBackColor = true;
            this.btnReceiverSwitch.Click += new System.EventHandler(this.btnLabelSwitch_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(5, 194);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(227, 20);
            this.tbMessage.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type here data, which you want to send";
            // 
            // cbSwitchReceiver
            // 
            this.cbSwitchReceiver.FormattingEnabled = true;
            this.cbSwitchReceiver.Location = new System.Drawing.Point(5, 63);
            this.cbSwitchReceiver.Name = "cbSwitchReceiver";
            this.cbSwitchReceiver.Size = new System.Drawing.Size(146, 21);
            this.cbSwitchReceiver.TabIndex = 12;
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.HorizontalScrollbar = true;
            this.lstMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lstMessage.Location = new System.Drawing.Point(5, 93);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(227, 82);
            this.lstMessage.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 266);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.cbSwitchReceiver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnReceiverSwitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.tbFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ClientNode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReceiverSwitch;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSwitchReceiver;
        private System.Windows.Forms.ListBox lstMessage;
    }
}

