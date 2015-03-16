using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;


using Newtonsoft.Json;namespace Rabbitmq
{
    public class Producir
    {
        static public void ProducirInfo(int num)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    for (int i = 0; i < num; i++)
                    {
                        channel.QueueDeclare("RabbitMQ_C#", false, false, false, null);

                        DefaultMensaje message = new DefaultMensaje("RabbitMQ_C#", "Persona " + i, "ID" + i);

                        String jsonified = JsonConvert.SerializeObject(message);
                        var Cuerpo = Encoding.UTF8.GetBytes(jsonified);
                        var Propiedades = channel.CreateBasicProperties();
                        Propiedades.DeliveryMode = 2;

                        channel.BasicPublish("", "RabbitMQ_C#", Propiedades, Cuerpo);
                        Console.WriteLine(" [x] Sent {0}", message);
                    }
                }
            }
        }
    }
}
