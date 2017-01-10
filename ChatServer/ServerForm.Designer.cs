namespace ServerSideApplication
{
    partial class ServerForm
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
            this.startServer = new System.Windows.Forms.Button();
            this.stopServer = new System.Windows.Forms.Button();
            this.notificationBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // startServer
            // 
            this.startServer.Location = new System.Drawing.Point(12, 12);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(225, 105);
            this.startServer.TabIndex = 0;
            this.startServer.Text = "Start server";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.startServer_Click);
            // 
            // stopServer
            // 
            this.stopServer.Location = new System.Drawing.Point(243, 12);
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(222, 105);
            this.stopServer.TabIndex = 1;
            this.stopServer.Text = "Stop server";
            this.stopServer.UseVisualStyleBackColor = true;
            this.stopServer.Click += new System.EventHandler(this.stopServer_Click);
            // 
            // notificationBox
            // 
            this.notificationBox.Location = new System.Drawing.Point(12, 123);
            this.notificationBox.Name = "notificationBox";
            this.notificationBox.ReadOnly = true;
            this.notificationBox.Size = new System.Drawing.Size(453, 300);
            this.notificationBox.TabIndex = 2;
            this.notificationBox.Text = "";
            this.notificationBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 435);
            this.Controls.Add(this.notificationBox);
            this.Controls.Add(this.startServer);
            this.Controls.Add(this.stopServer);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Button stopServer;
        private System.Windows.Forms.RichTextBox notificationBox;
    }
}

