using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSideApplication
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {

        }

        private void startServer_Click(object sender, EventArgs e)
        {
            Server.Start(this);
        }

        private void stopServer_Click(object sender, EventArgs e)
        {
            Server.Stop(this);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        delegate void SetTextFieldInvoker(string text);

        public void SetTextField(string text)
        {
            if (this.notificationBox.InvokeRequired)
            {
                notificationBox.Invoke(new SetTextFieldInvoker(AddNotification), text);
            }
            else
            {
                notificationBox.AppendText(text);
            }
        }

        public void AddNotification(string text)
        {
            SetTextField(text);
        }
    }
}
