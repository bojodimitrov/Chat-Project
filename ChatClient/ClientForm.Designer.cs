namespace ChatClient
{
    partial class ClientForm
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
            this.ipaddress = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.usernameField = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.notifactionBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ipaddress
            // 
            this.ipaddress.Location = new System.Drawing.Point(217, 71);
            this.ipaddress.Name = "ipaddress";
            this.ipaddress.Size = new System.Drawing.Size(262, 20);
            this.ipaddress.TabIndex = 0;
            this.ipaddress.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(290, 124);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(115, 47);
            this.Connect.TabIndex = 1;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(153, 74);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(58, 13);
            this.ipAddressLabel.TabIndex = 2;
            this.ipAddressLabel.Text = "IP Address";
            // 
            // usernameField
            // 
            this.usernameField.Location = new System.Drawing.Point(217, 98);
            this.usernameField.Name = "usernameField";
            this.usernameField.Size = new System.Drawing.Size(262, 20);
            this.usernameField.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(156, 101);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Username";
            // 
            // notifactionBox
            // 
            this.notifactionBox.Location = new System.Drawing.Point(217, 234);
            this.notifactionBox.Name = "notifactionBox";
            this.notifactionBox.ReadOnly = true;
            this.notifactionBox.Size = new System.Drawing.Size(262, 100);
            this.notifactionBox.TabIndex = 5;
            this.notifactionBox.Text = "";
            this.notifactionBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.notifactionBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.ipAddressLabel);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.ipaddress);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipaddress;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.TextBox usernameField;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.RichTextBox notifactionBox;
    }
}

