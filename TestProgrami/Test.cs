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
    public partial class Test : Form
    {
        String[] portlistesi;
        bool baglanti_durumu = false;
        string Gelen_data = "0.00";

        public Test()
        {
            InitializeComponent();
        }
        void portlisteleme()
        {
            comboBox1.Items.Clear();
            portlistesi = SerialPort.GetPortNames();
            foreach(string portadi in portlistesi)
            {
                comboBox1.Items.Add(portadi);
                if (portlistesi[0] != null)
                {
                    comboBox1.SelectedItem = portlistesi[0];
                }
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            portlisteleme();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            portlisteleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti_durumu == false)
            {
                serialPort1.PortName = comboBox1.GetItemText(comboBox1.SelectedItem);
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                button2.Enabled = false;
                button1.Text = "Kopar";
                button1.BackColor = Color.Red;
                baglanti_durumu = true;
                button5.Enabled = false;
                button6.Enabled = false;
                label2.BackColor = Color.LightGreen;
                label4.BackColor = Color.Red;
                label6.BackColor = Color.Red;
                groupBox6.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
                MessageBox.Show("Cihaza Başarıyla Bağlanıldı...", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (deger < 25)
                //{
                //    pictureBox2.Visible = true;
                //    pictureBox1.Visible = false;

                //}
                //else if(deger >25 && deger<30)
                //{
                //    pictureBox1.Visible = true;
                //    pictureBox2.Visible = false;
                //    pictureBox3.Visible = false;
                //}
                //else if (deger > 30)
                //{
                //    pictureBox1.Visible = false;
                //    pictureBox2.Visible = false;
                //    pictureBox3.Visible = true;
                //}
            }
            else
            {
                serialPort1.Close();
                baglanti_durumu = false;
                button1.Text = "Bağlan";
                button1.BackColor = Color.Green;
                comboBox1.Enabled = true;
                button2.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox6.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
            button3.Enabled = false;
            button5.Enabled = true;
            label4.BackColor = Color.LightGreen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
            button5.Enabled = false;
            button3.Enabled = true;
            label4.BackColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("3");
            button4.Enabled = false;
            button6.Enabled = true;
            label6.BackColor = Color.LightGreen;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");
            button6.Enabled = false;
            button4.Enabled = true;
            label6.BackColor = Color.Red;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                label10.Text = Gelen_data;
                //string deger = serialPort1.ReadLine()
                // int Ydeger = Convert.ToInt32(deger);
                // label10.Text = Convert.ToString(Ydeger);
                // label9.Text = Convert.ToString(deger);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string cozum = Gelen_data.Substring(0, Gelen_data.Length - 4);
            int Isı = Convert.ToInt32(cozum);
            label10.Text = Convert.ToString(Isı) ;
            if(Isı <26)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
            else if(Isı < 30 && Isı > 25)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;

            }
            else if (Isı >= 30)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;

            }
            else
            {
                MessageBox.Show("Hatalı Ölçüm Yapıldı...");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           Gelen_data = serialPort1.ReadLine();
        }
    }
}
