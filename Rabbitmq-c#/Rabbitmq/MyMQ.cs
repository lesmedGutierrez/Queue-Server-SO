using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbitmq
{
    class MyMQ
    {
        
        public void Producir(int ciclos)
        {
            string server = "127.0.0.1";
            string message = "";

            for (int i = 0; i < ciclos; i++)
            {
                 try
                {
                    Int32 port = 13000;
                    TcpClient client = new TcpClient(server, port);

                    DefaultMensaje msg = new DefaultMensaje("IronMQ_C#", "Persona " + i, "ID" + i);
                    String jsonified = JsonConvert.SerializeObject(msg);
                    var data = Encoding.UTF8.GetBytes(jsonified);
                    NetworkStream stream = client.GetStream();
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0} ,{1}", data ,i);
                    stream.Close();
                    client.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }

                Console.WriteLine("\n Press Enter to continue...");
                Console.Read();

            }
        }
        public void recibir()
        {
            string server = "127.0.0.1";
            //string message = "Las colas se crean para proporcionar un recurso con el que puedan interactuar los componentes de mensajería. Por ejemplo, suponga que está generando un sistema de entrada de pedidos que coloca los pedidos en colas a medida que se reciben de los vendedores o de la interacción directa con los clientes en un sitio Web. Puede empezar creando una cola OrderEntry en la empresa de Message Queue Server. Todos los componentes que cree para procesar pedidos interactuarán con esta cola.Hay dos formas posibles de crear una cola: mediante la ventana del Explorador de servidores o utilizando el constructor Create del código. Puede utilizar el Explorador de servidores o la ventana Administración de equipos de Windows 2000 para comprobar si la cola se ha creado correctamente.Puede crear una cola pública en el equipo propio o en cualquier equipo de Message Queue Server para el que tenga derechos de acceso administrativo de dominio o de empresa. También puede crear colas privadas sólo en el equipo local. Para obtener más inforión sobre derechos de acceso, vea Seguridad de la cola de mensajes o vea Control de acceso para Message Queue Server en la documentación de la ventana Administración de equipos.";
            string message = "";
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                data = new Byte[2048];
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);


                Console.WriteLine("Received: {0}", responseData);
                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
            Random rnd = new Random();
            int numrnd = rnd.Next(500, 3000);
            //Thread.Sleep(numrnd);
            DefaultMensaje def_message = JsonConvert.DeserializeObject<DefaultMensaje>(message);
            def_message.insertarMsj();            
        }
        


    }
}
