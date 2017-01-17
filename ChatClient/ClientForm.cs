using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        Thread receiverThread;
        Thread heartbeatThread;

        public ClientForm()
        {
            InitializeComponent();
        }


        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                Client clientListener = new Client(this.ipaddress.Text, usernameField.Text, passwordField.Text);
                clientListener.ConnectToServer();
                Form chatroom = new Chatroom(clientListener, this);
                receiverThread = new Thread(new ParameterizedThreadStart(clientListener.ReceiveMessage));
                heartbeatThread = new Thread(new ThreadStart(clientListener.TickHeartbeat));
                receiverThread.IsBackground = true;
                heartbeatThread.IsBackground = true;
                receiverThread.Start(chatroom);
                heartbeatThread.Start();
                chatroom.Show();
                Hide();

            }
            catch (BadConnectionToServerException exc)
            {
                notifactionBox.Text = "";
                notifactionBox.AppendText(exc.Notification, Color.Crimson);
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
