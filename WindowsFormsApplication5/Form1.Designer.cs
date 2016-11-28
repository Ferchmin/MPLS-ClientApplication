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
            this.btnEnableDataFlow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNewLabel = new System.Windows.Forms.TextBox();
            this.btnLabelSwitch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDisableDataFlow = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(5, 25);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(146, 20);
            this.tbFilePath.TabIndex = 0;
            this.tbFilePath.Text = "C:\\Users\\Piotrek\\Desktop\\img\\XMLApp\\XMLApp\\bin\\Debug\\client1.xml";
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
            // btnEnableDataFlow
            // 
            this.btnEnableDataFlow.Location = new System.Drawing.Point(5, 315);
            this.btnEnableDataFlow.Name = "btnEnableDataFlow";
            this.btnEnableDataFlow.Size = new System.Drawing.Size(227, 42);
            this.btnEnableDataFlow.TabIndex = 3;
            this.btnEnableDataFlow.Text = "Enable data flow";
            this.btnEnableDataFlow.UseVisualStyleBackColor = true;
            this.btnEnableDataFlow.Click += new System.EventHandler(this.btnEnableDataFlow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New label:";
            // 
            // tbNewLabel
            // 
            this.tbNewLabel.Location = new System.Drawing.Point(5, 64);
            this.tbNewLabel.Name = "tbNewLabel";
            this.tbNewLabel.Size = new System.Drawing.Size(146, 20);
            this.tbNewLabel.TabIndex = 5;
            // 
            // btnLabelSwitch
            // 
            this.btnLabelSwitch.Location = new System.Drawing.Point(157, 64);
            this.btnLabelSwitch.Name = "btnLabelSwitch";
            this.btnLabelSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnLabelSwitch.TabIndex = 6;
            this.btnLabelSwitch.Text = "Switch label";
            this.btnLabelSwitch.UseVisualStyleBackColor = true;
            this.btnLabelSwitch.Click += new System.EventHandler(this.btnLabelSwitch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 180);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnDisableDataFlow
            // 
            this.btnDisableDataFlow.Location = new System.Drawing.Point(5, 363);
            this.btnDisableDataFlow.Name = "btnDisableDataFlow";
            this.btnDisableDataFlow.Size = new System.Drawing.Size(227, 42);
            this.btnDisableDataFlow.TabIndex = 8;
            this.btnDisableDataFlow.Text = "Disable data flow";
            this.btnDisableDataFlow.UseVisualStyleBackColor = true;
            this.btnDisableDataFlow.Click += new System.EventHandler(this.btnDisableDataFlow_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(5, 289);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(227, 20);
            this.tbMessage.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type here data, which you want to send";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 409);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnDisableDataFlow);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLabelSwitch);
            this.Controls.Add(this.tbNewLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnableDataFlow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.tbFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Form1";
            this.Text = "ClientNode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnableDataFlow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNewLabel;
        private System.Windows.Forms.Button btnLabelSwitch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDisableDataFlow;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label label3;
    }
}

