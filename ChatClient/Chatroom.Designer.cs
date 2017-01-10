namespace ChatClient
{
    partial class Chatroom
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
            this.messageField = new System.Windows.Forms.RichTextBox();
            this.responseField = new System.Windows.Forms.RichTextBox();
            this.send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageField
            // 
            this.messageField.Location = new System.Drawing.Point(12, 351);
            this.messageField.Name = "messageField";
            this.messageField.Size = new System.Drawing.Size(538, 78);
            this.messageField.TabIndex = 1;
            this.messageField.Text = "";
            this.messageField.TextChanged += new System.EventHandler(this.messageField_TextChanged);
            // 
            // responseField
            // 
            this.responseField.Location = new System.Drawing.Point(12, 12);
            this.responseField.Name = "responseField";
            this.responseField.ReadOnly = true;
            this.responseField.Size = new System.Drawing.Size(680, 333);
            this.responseField.TabIndex = 2;
            this.responseField.Text = "";
            this.responseField.TextChanged += new System.EventHandler(this.responseField_TextChanged);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(556, 351);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(136, 78);
            this.send.TabIndex = 3;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chatroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.send);
            this.Controls.Add(this.responseField);
            this.Controls.Add(this.messageField);
            this.Name = "Chatroom";
            this.Text = "Chatroom";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox messageField;
        private System.Windows.Forms.RichTextBox responseField;
        private System.Windows.Forms.Button send;
    }
}