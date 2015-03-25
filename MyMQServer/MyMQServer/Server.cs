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


        public void run()
        {

            List<Thread> threadslis = new List<Thread>();

            int numeroThreads = 1;
            for (int i = 0; i < numeroThreads; i++)
            {
                Thread newThread = new Thread(this.Listen);
                threadslis.Add(newThread);
            }


            for (int i = 0; i < threadslis.Count; i++)
            {
                if (threads)
                {

                    Thread t = threadslis[i];
                    if (!t.IsAlive)
                    {
                        t = new Thread(this.Listen);
                        t.Start();

                    }


                }

                if (i == threadslis.Count - 1)
                {
                    i = 0;
                }


            }

        }


        public void Listen()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[2048];
                String data = null;
                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    data = null;
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i = stream.Read(bytes, 0, bytes.Length) ;

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
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);

                            // Process the data sent by the client.
                            //data = data.ToUpper();

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);


                        }
                    }
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                //server.Stop();
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

    }
}
