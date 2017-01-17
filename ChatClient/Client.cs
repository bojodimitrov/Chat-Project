using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatClient
{
    public class Client
    {
        IPEndPoint remoteEP;
        System.Timers.Timer timer;
        Socket sender;
        string username;
        string password;
        const string heartbeat = "@H";
        const int heartbeatSec = 1;


        public Client(string ipString, string usernameParam, string passwordParam)
        {

            IPAddress ipAddress = IPAddress.Parse(ipString);
            remoteEP = new IPEndPoint(ipAddress, 11000);
            username = usernameParam;
            password = passwordParam;
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
                byte[] bytes = new byte[255];
                int bytesRec = 0;

                try
                {
                    bytesRec = sender.Receive(bytes);
                }
                catch (SocketException exc)
                {
                    throw new BadConnectionToServerException("Error: server is not started.", exc);
                }
                string response = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                if (response.IndexOf("@incorrect") > -1)
                {
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    throw new BadConnectionToServerException("Incorrect password.");
                }
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
            byte[] heartbeatMsg = Encoding.UTF8.GetBytes(heartbeat);
            sender.Send(heartbeatMsg);
        }

        public void SendMessage(string message)
        {
            byte[] bytes = new byte[255];
            message = addCredentials(message);

            try
            {
                //Send the Мessage to server
                byte[] msg = Encoding.UTF8.GetBytes(message);
                if (sender.Connected)
                {
                    int bytesSent = sender.Send(msg);
                }
            }
            catch { }
        }

        public void ReceiveMessage(object chatroomObj)
        {
            Chatroom chatroom = (Chatroom)chatroomObj;

            string response;
            byte[] bytes = new byte[255];
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
                response = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                if (response.IndexOf("@disconnect") > -1)
                {
                    chatroom.AppendTextInResponseField("Server stopped!", Color.Crimson);
                    break;
                }
                List<string> messages = new List<string>();

                ParseResponse(response, messages, chatroom);
                chatroom.ChangeMessageField("");
                chatroom.AppendTextInResponseField(messages[0], Color.Crimson);
                chatroom.AppendTextInResponseField(": ", Color.Crimson);
                chatroom.AppendTextInResponseField(messages[1], Color.Black);
            }
            StopClient();
        }


        //Utility functions
        public void ParseResponse(string response, List<string> messages, Chatroom chatroom)
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
            byte[] msg = Encoding.ASCII.GetBytes(username + '%' + password);
            int bytesSent = sender.Send(msg);
        }
    }
}
