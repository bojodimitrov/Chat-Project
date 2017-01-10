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
            FormClosed += ClientForm_FormClosed;
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //receiverThread.Abort();
            //heartbeatThread.Abort();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Client clientListener = new Client(this.ipaddress.Text, usernameField.Text);
            try
            {
                clientListener.ConnectToServer();
                Form chatroom = new Chatroom(clientListener, this);
                receiverThread = new Thread(new ParameterizedThreadStart(clientListener.ReceiveMessage));
                heartbeatThread = new Thread(new ThreadStart(clientListener.TickHeartbeat));
                receiverThread.IsBackground = true;
                heartbeatThread.IsBackground = true;
                receiverThread.Start(chatroom);
                heartbeatThread.Start();
                chatroom.Show();
            }
            catch (BadConnectionToServerException exc)
            {
                notifactionBox.Text = "";
                notifactionBox.AppendText(exc.Message, Color.Coral);
            }

            Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
