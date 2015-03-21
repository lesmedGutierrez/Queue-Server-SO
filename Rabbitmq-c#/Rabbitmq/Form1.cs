using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Rabbitmq
{
    public partial class Form1 : Form
    {
        private int num = 1;
        private BackgroundWorker bw = new BackgroundWorker();
        private BackgroundWorker bw2 = new BackgroundWorker();
        IronMQClass ironmq = new IronMQClass();
        bool threads = false;
        public Form1()
        {
            InitializeComponent();
            RabbitMQ.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 1;
            if (!textBox1.Text.Equals(""))
                num  = int.Parse(textBox1.Text);

            if (RabbitMQ.Checked)
            {
                Thread newThread = new Thread(() => Producir.ProducirInfo(num));
                newThread.Start();
            }
            else
            {
                Thread newThread = new Thread(() => ironmq.Producir(num));
                newThread.Start();

            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RabbitMQ.Checked)
            {
                Receiving worker = new Receiving();
                worker.num = num;
                Thread newThread = new Thread(worker.Consumir);
                newThread.Start();
                num++;
            }
            else
            {

                while (true)
                {

                    if (!threads) break;

                    Thread newThread = new Thread(ironmq.recibir);
                    newThread.Start();

                }


                
                

            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (!(letter >= 48 && letter <= 57) && letter != 8)
            {
                e.KeyChar = new char();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
