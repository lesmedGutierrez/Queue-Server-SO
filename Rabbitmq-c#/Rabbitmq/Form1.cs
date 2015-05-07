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
        MyMQ mymq = new MyMQ();
        bool threads = false;


        public Form1()
        {
            InitializeComponent();
            RabbitMQ.Checked = true;
            this.JSON.Checked = true;
            

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
            else if (IronMQ.Checked)
            {
                Thread newThread = new Thread(() => ironmq.Producir(num));
                newThread.Start();
            }
            else
            {
                Thread newThread = new Thread(() => mymq.Producir(num));
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
            else if (IronMQ.Checked)
            {
                if (threads)
                {
                    threads = false;
                }
                else
                {
                    threads = true;
                }
                List<Thread> threadslis = new List<Thread>();
                int numeroThreads = 1;
                for (int i = 0; i < numeroThreads; i++)
                {
                    Thread newThread = new Thread(ironmq.recibir);
                    threadslis.Add(newThread);
                }
                for (int i = 0; i < threadslis.Count; i++)
                {
                    if (threads)
                    {
                        Thread t = threadslis[i];
                        if (!t.IsAlive)
                        {
                            t = new Thread(ironmq.recibir);
                            t.Start();
                        }


                    }

                    if (i == threadslis.Count - 1)
                    {
                        i = 0;
                    }
                }
            }
            else
            {
                try
                {
                    //int num = 1;
                    //if (!textBox1.Text.Equals(""))
                    //    num = int.Parse(textBox1.Text);


                    //for (int i = 0; i < num; i++)
                    //{
                    //    mymq.recibir();

                    //}
                    if (threads)
                    {
                        threads = false;
                    }
                    else
                    {
                        threads = true;
                    }
                    List<Thread> threadslis = new List<Thread>();
                    int numeroThreads = 1;
                    for (int i = 0; i < numeroThreads; i++)
                    {
                        Thread newThread = new Thread(mymq.recibir);
                        threadslis.Add(newThread);
                    }
                    for (int i = 0; i < threadslis.Count; i++)
                    {
                        if (threads)
                        {
                            Thread t = threadslis[i];
                            if (!t.IsAlive)
                            {
                                t = new Thread(mymq.recibir);
                                t.Start();
                            }
                        }

                        if (i == threadslis.Count - 1)
                        {
                            i = 0;
                        }
                    }
                }
                catch (Exception e1) { }
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

        private void MyMQ_CheckedChanged(object sender, EventArgs e)
        {
            if (MyMQ.Checked)
            {
                this.panel1.Visible = false;
                
            }
            else
            {
                this.panel1.Visible = false;
            }
        }
    }
}
