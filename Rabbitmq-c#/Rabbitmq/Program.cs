﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client;

namespace Rabbitmq
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyMQ myMQ = new MyMQ();

            
            

            //myMQ.listenTCP();

            Application.Run(new Form1());
        }
    }
}
