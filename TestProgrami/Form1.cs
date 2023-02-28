using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace TestProgrami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM5";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            serialPort1.Write("1");
            label1.Text = "Led Kapalı";
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
            label1.Text = "Led Açıldı";
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
            label1.Text = "Led Kapatıldı";
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Show();
            this.Hide();
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }

        }
    }
}
