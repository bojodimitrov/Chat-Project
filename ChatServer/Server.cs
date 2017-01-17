using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ServerSideApplication
{
    class Server
    {
        public static string data = null;
        static IPAddress ipAddress;
        static IPEndPoint endPoint;
        static Socket listener;
        static Dictionary<Socket, string> connectedUsers;
        static ServerForm serverForm;
        static Thread listenThread;
        static Socket handler;
        static XmlDocument xmlFile;

        public static void Start(ServerForm form)
        {
            serverForm = form;
            connectedUsers = new Dictionary<Socket, string>();
            //Setting up socket
            ipAddress = IPAddress.Any;
            endPoint = new IPEndPoint(ipAddress, 11000);
            xmlFile = new XmlDocument();
            xmlFile.Load("database.xml");
            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //Binding the socket
                listener.Bind(endPoint);
                listener.Listen(10);

                //Starting thread that will listen so that the programm wont be blocked
                listenThread = new Thread(new ThreadStart(Accept));
                listenThread.Start();
                serverForm.AddNotification("Server started successfully.\n");
            }
            catch { }

        }

        public static void Stop(ServerForm form)
        {
            try
            {
                listener.Shutdown(SocketShutdown.Both);
            }
            catch
            { }
            listener.Close();
            foreach (var user in connectedUsers)
            {
                var temp = user.Key;
                byte[] msg = Encoding.ASCII.GetBytes("@disconnect");

                temp.Send(msg);
                temp.Shutdown(SocketShutdown.Both);
                temp.Close();

            }
            form.AddNotification("Server stopped successfully.\n");
        }

        public static void Accept()
        {
            try
            {
                while (true)
                {

                    handler = listener.Accept();

                    string usernameAndPassword = ReceiveCredentials(handler);
                    string username = usernameAndPassword.Substring(0, usernameAndPassword.IndexOf('%'));
                    string password = usernameAndPassword.Substring(usernameAndPassword.IndexOf('%') + 1);
                    if (VerifyCredentials(usernameAndPassword, username, password))
                    {
                        Thread.Sleep(500);
                        handler.Send(Encoding.UTF8.GetBytes("@correct"));
                        connectedUsers.Add(handler, username);
                        serverForm.AddNotification(username + " connected.\n");
                        Thread handleThread = new Thread(new ParameterizedThreadStart(HandleMessage));
                        handleThread.Start(handler);
                    }
                    else
                    {
                        Thread.Sleep(500);
                        handler.Send(Encoding.UTF8.GetBytes("@incorrect"));
                    }
                }
            }
            catch
            { }
        }

        private static bool VerifyCredentials(string credentials, string username, string password)
        {

            XmlNodeList elemUsernamesList = xmlFile.GetElementsByTagName("Username");
            XmlNodeList elemPasswordsList = xmlFile.GetElementsByTagName("Password");
            for (int i = 0; i < elemUsernamesList.Count; i++)
            {
                if (elemUsernamesList[i].InnerText == username && elemPasswordsList[i].InnerText == password)
                {
                    return true;
                }
                if (elemUsernamesList[i].InnerText == username && elemPasswordsList[i].InnerText != password)
                {
                    return false;
                }
            }
            XmlNode userNode = xmlFile.CreateNode(XmlNodeType.Element, "User", null);
            XmlNode usernameNode = xmlFile.CreateElement("Username");
            usernameNode.InnerText = username;
            XmlNode passwordNode = xmlFile.CreateElement("Password");
            passwordNode.InnerText = password;
            userNode.AppendChild(usernameNode);
            userNode.AppendChild(passwordNode);
            xmlFile.DocumentElement.AppendChild(userNode);
            xmlFile.Save("database.xml");
            return true;
        }

        public static void HandleMessage(object handlerObj)
        {
            Socket handler = (Socket)handlerObj;
            handler.ReceiveTimeout = 3000;
            byte[] bytes = new Byte[1024];
            int bytesRec = 0;
            bool running = true;

            while (running)
            {
                data = null;
                bytes = new byte[1024];
                try
                {
                    bytesRec = handler.Receive(bytes);
                }
                catch (SocketException)
                {
                    break;
                }
                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                //Returning the message
                if (data.IndexOf("@H") <= -1)
                {
                    foreach (var user in connectedUsers)
                    {
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        user.Key.Send(msg);
                    }
                }
            }

            if (!serverForm.IsClosed)
            {
                serverForm.AddNotification(connectedUsers[handler] + " diconnected.\n");
            }
            connectedUsers.Remove(handler);

            try
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch { }
        }

        public static string ReceiveCredentials(Socket handler)
        {
            byte[] bytes = new Byte[1024];
            int bytesRec;
            bytesRec = handler.Receive(bytes);
            string message = null;
            message = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            return message;
        }

    }
}

//192.168.0.101