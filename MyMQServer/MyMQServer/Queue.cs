using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMQServer
{
    class MyQueue
    {

        Queue<Message> queue = new Queue<Message>();

        public void Add(Message message)
        {
            queue.Enqueue(message);
        }
        public void Add(string message)
        {
            Message msg = new Message();
            msg.mensage = message;
            queue.Enqueue(msg);
        }
        public string Get()
        {
            if (queue.Count > 0)
            {
                Message message = queue.Dequeue();

                return message.mensage;
            }
            else
            {
                return null;
            }
        }

    }
}
