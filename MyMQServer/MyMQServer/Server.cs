using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMQServer
{
    class Server
    {
        bool threads = true;
        private static Semaphore _pool;

        MyQueue queue = new MyQueue();
        NetworkStream stream;

        public Server()
        {

            //queue.Add("Hola mundo");
            //queue.Add("Hola mundo");
            //queue.Add("Hola mundo");


        }


        public void run()
        {
            //this.Listen();
            this.createListener();

            //List<Thread> threadslis = new List<Thread>();
            //int numeroThreads = 1;
            //for (int i = 0; i < numeroThreads; i++)
            //{
            //    Thread newThread = new Thread(this.Listen);
            //    threadslis.Add(newThread);
            //}
            //for (int i = 0; i < threadslis.Count; i++)
            //{
            //    if (threads)
            //    {
            //        Thread t = threadslis[i];
            //        if (!t.IsAlive)
            //        {
            //            t = new Thread(this.Listen);
            //            t.Start();
            //        }
            //    }

            //    if (i == threadslis.Count - 1)
            //    {
            //        i = 0;
            //    }
            //}
        }


        public void Listen()
        {
            TcpListener server = null;
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            try
            {
                // Set the TcpListener on port 13000.
                
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                

                // Buffer for reading data
                Byte[] bytes = new Byte[2048];
                String data = null;
                // Enter the listening loop.
                while (true)
                {
                    server.Start();
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    data = null;
                    // Get a stream object for reading and writing
                    //NetworkStream stream = client.GetStream();
                    stream = client.GetStream();

                    int i = stream.Read(bytes, 0, bytes.Length) ;
                    string algo = "Hola mundo";
                    if (i == 0)
                    {
                        data = this.sendData();

                        // Send back a response.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        //Console.WriteLine("Sent: {0}", data);

                    }
                    else
                    {
                        // Loop to receive all the data sent by the client.
                        while (i != 0)
                        {
                            string msg = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", msg);

                            queue.Add(msg);
                            i = 0;

                        }
                    }
                    // Shutdown and end connection
                    //stream.Close();
                    client.Close();
                    server.Stop();
                    
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();

        }
        public bool writeData(string data)
        {
            queue.Add(data);        

            return true;
        }
        public string sendData()
        {
            _pool = new Semaphore(0, 1);
            string msg = queue.Get();
            _pool.Release(1);
            return msg;
        }

        public void createListener()
        {
            string output;
            int port = 13000;
            TcpListener tcpListener = null;
            //IPAddress ipAddress = IPAddress.Any;
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            try
            {
                tcpListener = new TcpListener(ipAddress, port);
                tcpListener.Start();
                output = "Waiting for a connection...";
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                output = "Error: " + e.ToString();
                Console.WriteLine(output);
            }
            while (true)
            {
                Thread.Sleep(10);
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                byte[] bytes = new byte[2048];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(bytes, 0, bytes.Length);
                SocketHelper helper = new SocketHelper();
                helper.processMsg(tcpClient, stream, bytes, this);
            }
        }

        class SocketHelper
        {
            TcpClient mscClient;
            string mstrMessage;
            string mstrResponse;
            byte[] bytesSent;

            public void processMsg(TcpClient client, NetworkStream stream, byte[] bytesReceived, Server server)
            {
                mstrMessage = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length);
                mscClient = client;
                if (mstrMessage.Length > 0)
                {
                    Console.WriteLine("Recibido: {0}", mstrMessage);
                    mstrResponse = mstrMessage;
                    char c = mstrMessage[0];
                    if (c == '1')
                    {
                        mstrResponse = server.sendData();
                    }
                    else
                    {
                        server.queue.Add(mstrMessage);
                    }
                }
                    
                
                else
                {
                    mstrResponse = "You have sent blank message";
                }
                if (mstrResponse!=null)
                {
                    bytesSent = Encoding.ASCII.GetBytes(mstrResponse);
                    stream.Write(bytesSent, 0, bytesSent.Length);
                }
                else
                {
                    bytesSent = Encoding.ASCII.GetBytes(string.Empty);
                    stream.Write(bytesSent, 0, bytesSent.Length);
                }
            }

        }
    }
}
