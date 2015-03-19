using IronSharp.IronMQ;
using IronSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq
{
    class IronMQClass
    {



        public void Producir()
        {
            // =========================================================
            // Iron.io MQ
            // =========================================================

            IronMqRestClient ironMq = IronSharp.IronMQ.Client.New();
            


            // Get a Queue object
            QueueClient queue = ironMq.Queue("test-queue-lesmed");

            QueueInfo info = queue.Info();

            Console.WriteLine(info.Inspect());

            // Put a message on the queue
            string messageId = queue.Post("hello world!");

            Console.WriteLine(messageId);

            // Get a message
            MessageCollection msg = queue.Get(n:30, timeout: 60, wait: 100);

            //Console.WriteLine(msg.Inspect());

            ////# Delete the message
            //bool deleted = msg.Delete();

            //Console.WriteLine("Deleted = {0}", deleted);

            // Post several messages
            queue.Post(new[] { "Hello", "world" });

            MessageCollection messages = queue.Get(n: 2, timeout: 60, wait: 30);
            // You can specify only parameters you need:
            // MessageCollection messages = queue.Get(wait: 15);

            // Post several messages
            var payload1 = new
            {
                message = "hello, my name is Iron.io 1"
            };

            var payload2 = new
            {
                message = "hello, my name is Iron.io 2"
            };

            var payload3 = new
            {
                message = "hello, my name is Iron.io 3"
            };

            MessageIdCollection queuedUp = queue.Post(new[] {payload1, payload2, payload3});

            Console.WriteLine(queuedUp.Inspect());

            QueueMessage next;

            while (queue.Read(out next))
            {
                Console.WriteLine(next.Inspect());
                Console.WriteLine(next.Delete());
            }
        }


    }
}
