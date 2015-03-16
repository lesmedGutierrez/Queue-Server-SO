using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading;

namespace Rabbitmq
{
    public class Receiving
    {
        public int num;

        public void Consumir()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("RabbitMQ_C#", false, false, false, null);

                    channel.BasicQos(0, 1, false);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("RabbitMQ_C#", true, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        String jsonified = Encoding.UTF8.GetString(body);
                        DefaultMensaje message = JsonConvert.DeserializeObject<DefaultMensaje>(jsonified);
                        message.insertarMsj();
                    }
                }
            }
        }
    }
}
