using IronSharp.IronMQ;
using IronSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IronSharp.IronWorker;

namespace Rabbitmq
{
    class IronMQClass
    {
        public string token = "D4YXJjgT6sldvBcpOvwcCuybmuY";
        public string projectID = "5505e6df2d0412000600001c";
        IronMqRestClient ironMq = IronSharp.IronMQ.Client.New();

        public void Producir(int ciclos)
        {
            // =========================================================
            // Iron.io MQ
            // =========================================================

            IronMqRestClient ironMq = IronSharp.IronMQ.Client.New();

            ironMq.Config.Token = this.token;
            ironMq.Config.ProjectId = this.projectID;

            // Get a Queue object
            QueueClient queue = ironMq.Queue("test-queue-lesmed");
            string messageId;
            for (int i = 0; i < ciclos; i++)
            {

                DefaultMensaje message = new DefaultMensaje("IronMQ_C#", "Persona " + i, "ID" + i);
                String jsonified = JsonConvert.SerializeObject(message);
                var Cuerpo = Encoding.UTF8.GetBytes(jsonified);



                int lencuerpo = Cuerpo.Length;
                int lenjson = jsonified.Length;


                messageId = queue.Post(jsonified);
                
            }
            
        }
        public void recibir()

        {
            
            IronMqRestClient ironMq = IronSharp.IronMQ.Client.New();

            ironMq.Config.Token = this.token;
            ironMq.Config.ProjectId = this.projectID;
            QueueClient queue = ironMq.Queue("test-queue-lesmed");
            MessageCollection msgs = queue.Get(n: 1, timeout: 60, wait: 15);
            foreach (var msg in msgs.Messages)
            {
                string body = msg.Body;
                Console.WriteLine(msg.Inspect());
                DefaultMensaje message = JsonConvert.DeserializeObject<DefaultMensaje>(body);
                message.insertarMsj();
                bool deleted = msg.Delete();
                Console.WriteLine("Deleted = {0}", deleted);                
            }
            
            

           


        }

    }
    class workerMQ : IronWorkerRestClient
    {

    }
}
