using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Chatroom : Form
    {
        Client clientListener;
        ClientForm clientForm;
        public Chatroom(Client clientListener, ClientForm clientForm)
        {
            InitializeComponent();
            this.clientListener = clientListener;
            this.clientForm = clientForm;
            FormClosed += Chatroom_FormClosed;
        }

        private void Chatroom_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientForm.Close();
        }

        private void responseField_TextChanged(object sender, EventArgs e)
        {

        }

        private void messageField_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string parsedMessage = this.messageField.Text + "\n";

            clientListener.SendMessage(parsedMessage);

        }

        //Methods for access of the elements in the Client class
        delegate void SetMessageFieldInvoker(string text);
        delegate void AppendTextInvoker(string text, Color color);

        public void SetMessageField(string text)
        {
            if (this.messageField.InvokeRequired)
            {
                messageField.Invoke(new SetMessageFieldInvoker(ChangeMessageField), text);
            }
            else
            {
                messageField.Text = text;
            }
        }

        public void ChangeMessageField(string text)
        {
            SetMessageField(text);
        }

        public void SetTextField(string text, Color color)
        {
            if (responseField.InvokeRequired)
            {
                responseField.Invoke(new AppendTextInvoker(AppendTextInResponseField), text, color);
            }
            else
            {
                responseField.AppendText(text, color);
                responseField.ScrollToCaret();
            }
        }

        public void AppendTextInResponseField(string text, Color color)
        {
            SetTextField( text, color);
        }
    }
}
