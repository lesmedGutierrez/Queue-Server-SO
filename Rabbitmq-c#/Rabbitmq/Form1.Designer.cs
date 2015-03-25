namespace Rabbitmq
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RabbitMQ = new System.Windows.Forms.RadioButton();
            this.IronMQ = new System.Windows.Forms.RadioButton();
            this.MyMQ = new System.Windows.Forms.RadioButton();
            this.JSON = new System.Windows.Forms.RadioButton();
            this.XML = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sending";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "N° de transacciones a generar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Receiving";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RabbitMQ
            // 
            this.RabbitMQ.AutoSize = true;
            this.RabbitMQ.Location = new System.Drawing.Point(15, 13);
            this.RabbitMQ.Name = "RabbitMQ";
            this.RabbitMQ.Size = new System.Drawing.Size(73, 17);
            this.RabbitMQ.TabIndex = 4;
            this.RabbitMQ.TabStop = true;
            this.RabbitMQ.Text = "RabbitMQ";
            this.RabbitMQ.UseVisualStyleBackColor = true;
            // 
            // IronMQ
            // 
            this.IronMQ.AutoSize = true;
            this.IronMQ.Location = new System.Drawing.Point(15, 36);
            this.IronMQ.Name = "IronMQ";
            this.IronMQ.Size = new System.Drawing.Size(60, 17);
            this.IronMQ.TabIndex = 5;
            this.IronMQ.TabStop = true;
            this.IronMQ.Text = "IronMQ";
            this.IronMQ.UseVisualStyleBackColor = true;
            // 
            // MyMQ
            // 
            this.MyMQ.AutoSize = true;
            this.MyMQ.Location = new System.Drawing.Point(15, 60);
            this.MyMQ.Name = "MyMQ";
            this.MyMQ.Size = new System.Drawing.Size(56, 17);
            this.MyMQ.TabIndex = 6;
            this.MyMQ.TabStop = true;
            this.MyMQ.Text = "MyMQ";
            this.MyMQ.UseVisualStyleBackColor = true;
            this.MyMQ.CheckedChanged += new System.EventHandler(this.MyMQ_CheckedChanged);
            // 
            // JSON
            // 
            this.JSON.AutoSize = true;
            this.JSON.Location = new System.Drawing.Point(11, 14);
            this.JSON.Name = "JSON";
            this.JSON.Size = new System.Drawing.Size(53, 17);
            this.JSON.TabIndex = 7;
            this.JSON.TabStop = true;
            this.JSON.Text = "JSON";
            this.JSON.UseVisualStyleBackColor = true;
            // 
            // XML
            // 
            this.XML.AutoSize = true;
            this.XML.Location = new System.Drawing.Point(80, 14);
            this.XML.Name = "XML";
            this.XML.Size = new System.Drawing.Size(47, 17);
            this.XML.TabIndex = 8;
            this.XML.TabStop = true;
            this.XML.Text = "XML";
            this.XML.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.XML);
            this.panel1.Controls.Add(this.JSON);
            this.panel1.Location = new System.Drawing.Point(77, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 41);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 213);
            this.Controls.Add(this.MyMQ);
            this.Controls.Add(this.IronMQ);
            this.Controls.Add(this.RabbitMQ);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "RabbitMQ con C#";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton RabbitMQ;
        private System.Windows.Forms.RadioButton IronMQ;
        private System.Windows.Forms.RadioButton MyMQ;
        private System.Windows.Forms.RadioButton JSON;
        private System.Windows.Forms.RadioButton XML;
        private System.Windows.Forms.Panel panel1;
    }
}

