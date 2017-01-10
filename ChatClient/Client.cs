using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;

namespace ChatClient
{
    public class Client
    {
        IPEndPoint remoteEP;
        Socket sender;
        string username;
        const string heartbeat = "#H";
        const int heartbeatSec = 1;
        System.Timers.Timer timer;

        public Client(string ipString, string usernameParam)
        {
            IPAddress ipAddress = IPAddress.Parse(ipString);
            remoteEP = new IPEndPoint(ipAddress, 11000);
            username = usernameParam;

            try
            {
                sender = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);
            }
            catch (SocketException exc)
            {
                throw new SocketNotInitializedException("Error: Unsuccessful socket initialisation.", exc);
            }
        }

        public void ConnectToServer()
        {
            try
            {
                sender.Connect(remoteEP);
                SendCredentials();
            }
            catch (SocketException exc)
            {
                throw new BadConnectionToServerException("Error: server is not started.", exc);
            }
        }

        public void TickHeartbeat()
        {
            timer = new System.Timers.Timer(1000 * heartbeatSec);
            timer.Elapsed += Heartbeat;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        public void Heartbeat(Object source, System.Timers.ElapsedEventArgs e)
        {
            byte[] heartbeatMsg = Encoding.ASCII.GetBytes(heartbeat);
            sender.Send(heartbeatMsg);
        }

        public void SendMessage(string message)
        {
            byte[] bytes = new byte[1024];
            message = addCredentials(message);

            try
            {
                //Send the Мessage to server
                byte[] msg = Encoding.ASCII.GetBytes(message);
                if (sender.Connected)
                {
                    int bytesSent = sender.Send(msg);
                }
            }
            catch
            {

            }
        }

        public void ReceiveMessage(object chatroomObj)
        {
            Chatroom chatroom = (Chatroom)chatroomObj;

            string response;
            byte[] bytes = new byte[1024];
            int bytesRec = 0;
            while (true)
            {
                try
                {
                    bytesRec = sender.Receive(bytes);
                }
                catch (SocketException exc)
                {
                    throw new BadConnectionToServerException("Error: server is not started.", exc);
                }
                response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (response.IndexOf("@disconnect") > -1)
                {
                    break;
                }
                List<string> messages = new List<string>();

                ParseResponse(response, messages);
                chatroom.ChangeMessageField("");
                chatroom.AppendTextInResponseField(messages[0], Color.Crimson);
                chatroom.AppendTextInResponseField(": ", Color.Crimson);
                chatroom.AppendTextInResponseField(messages[1], Color.Black);
            }
            StopClient();
        }


        //Utility functions
        public void ParseResponse(string response, List<string> messages)
        {
            messages.Clear();
            int userNamePos = response.IndexOf('$');
            messages.Add(response.Substring(0, userNamePos));
            messages.Add(response.Remove(0, userNamePos + 1));
        }

        public string addCredentials(string message)
        {
            string crMessage = username + "$" + message;
            return crMessage;
        }

        public void StopClient()
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            timer.Enabled = false;
        }

        public void SendCredentials()
        {
            byte[] msg = Encoding.ASCII.GetBytes(username);
            int bytesSent = sender.Send(msg);
        }
    }
}
