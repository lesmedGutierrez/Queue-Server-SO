using IronSharp.IronMQ;
using IronSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rabbitmq
{
    class IronMQClass
    {

        public void Producir(int cilos)
        {
            // =========================================================
            // Iron.io MQ
            // =========================================================

            IronMqRestClient ironMq = IronSharp.IronMQ.Client.New();

            IronClientConfig config = new IronClientConfig();
            config.Token = "D4YXJjgT6sldvBcpOvwcCuybmuY";
            config.ProjectId = "5505e6df2d0412000600001c";

            ironMq.Config.Token = config.Token;
            ironMq.Config.ProjectId = config.ProjectId;

            // Get a Queue object
            QueueClient queue = ironMq.Queue("test-queue-lesmed");
            string messageId;
            for (int i = 0; i < cilos; i++)
            {

                DefaultMensaje message = new DefaultMensaje("IronMQ_C#", "Persona " + i, "ID" + i);
                String jsonified = JsonConvert.SerializeObject(message);
                var Cuerpo = Encoding.UTF8.GetBytes(jsonified);

                messageId = @queue.Post(Cuerpo);
                
            }
            
            // Put a message on the queue
            

            //Console.WriteLine(messageId);

            //// Get a message
            //MessageCollection msg ;
            //msg= queue.Get(n:30, timeout: 60, wait: 100);


            //// Post several messages
            //queue.Post(new[] { "Hello", "world" });

            //MessageCollection messages = queue.Get(n: 2, timeout: 60, wait: 30);
            //// You can specify only parameters you need:
            // MessageCollection messages = queue.Get(wait: 15);

            //// Post several messages
            //var payload1 = new
            //{
            //    message = "hello, my name is Iron.io 1"
            //};

            //var payload2 = new
            //{
            //    message = "hello, my name is Iron.io 2"
            //};

            //var payload3 = new
            //{
            //    message = "hello, my name is Iron.io 3"
            //};

            //MessageIdCollection queuedUp = queue.Post(new[] {payload1, payload2, payload3});

            //Console.WriteLine(queuedUp.Inspect());

            //QueueMessage next;

            //while (queue.Read(out next))
            //{
            //    Console.WriteLine(next.Inspect());
            //    Console.WriteLine(next.Delete());
            //}
        }
        public void recibir()
        {



        }

    }
}
