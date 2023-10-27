using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sigzen3
{
    public partial class Form1 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;

        bool isConnect = false;
        String[] ports;
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
            OffControls();
            getAvailComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel[index].BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (index < listPanel.Count - 1)
                listPanel[++index].BringToFront();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (index > 0)
                listPanel[--index].BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validateform1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Validateform2();
        }
                
        private void Validateform1()
        {
            bool Validi1 = Validatei1();
            bool Validi2 = Validatei2();

            string waveStat = " ";
            if (radioButton1.Checked == true)
            {
                waveStat = "1";
            }
            else if (radioButton2.Checked == true)
            {
                waveStat = "2";
            }
            else if (radioButton3.Checked == true)
            {
                waveStat = "3";

                if (Validi1 && Validi2 == true)
                {
                    port.Write("<" + "f" + "," + waveStat + "," + textBox2.Text + "," + textBox1.Text + "," + ">");
                }
                else
                    MessageBox.Show("Isi dengan Benar !!");
            }
        }

            private void Validateform2()
            {
                bool Validi3 = Validatei3();
                bool Validi4 = Validatei4();
                bool Validi5 = Validatei5();
                bool Validi6 = Validatei6();

                if (Validi3 && Validi4 && Validi5 && Validi6 == true)
                {
                    port.Write("<" + "2" + "," + textBox6.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + ">");
                }
                else
                    MessageBox.Show("Isi dengan Benar !!");
            }

            private bool Validatei1()
            {
                bool bStatus = true;
                float temp1 = float.Parse(textBox1.Text);
                errorProvider1.SetError(textBox1, "");
                if (temp1 < 0.009 || temp1 > 200000)
                {
                    errorProvider1.SetError(textBox1, "input diluar range frekuensi!!");
                    bStatus = false;
                }
                else
                {
                    errorProvider1.SetError(textBox1, "");
                }
                return bStatus;
            }

            private bool Validatei2()
            {
                bool bStatus = true;
                float temp2 = float.Parse(textBox2.Text);
                errorProvider1.SetError(textBox2, "");
                if (temp2 < 9 || temp2 > 101)
                {
                    errorProvider1.SetError(textBox2, "input diluar range amplitudo!!");
                    bStatus = false;
                }
                else
                {
                    errorProvider1.SetError(textBox2, "");
                }
                return bStatus;
            }

            private bool Validatei3()
            {
                bool bStatus = true;
                float temp3 = float.Parse(textBox3.Text);
                errorProvider1.SetError(textBox3, "");
                if (temp3 < 0.009 || temp3 > 100000)
                {
                    errorProvider1.SetError(textBox4, "input diluar range frekuensi!!");
                    bStatus = false;
                }
                else
                {
                    errorProvider1.SetError(textBox3, "");
                }
                return bStatus;
            }

            private bool Validatei4()
            {
                bool bStatus = true;
                float temp4 = float.Parse(textBox4.Text);
                errorProvider1.SetError(textBox4, "");
                if (temp4 < 0.009 || temp4 > 100000)
                {
                    errorProvider1.SetError(textBox4, "input diluar range frekuensi!!");
                    bStatus = false;
                }
                else
                {
                    errorProvider1.SetError(textBox4, "");
                }
                return bStatus;
            }

            private bool Validatei5()
            {
                bool bStatus = true;
                float temp5 = float.Parse(textBox5.Text);
                errorProvider1.SetError(textBox5, "");
                if (temp5 < 1 || temp5 > 1000)
                {
                    errorProvider1.SetError(textBox5, "input diluar range durasi!!");
                    bStatus = false;
                }
                else
                {
                    errorProvider1.SetError(textBox5, "");
                }
                return bStatus;
            }

            private bool Validatei6()
            {
                bool bStatus = true;
                float temp6 = float.Parse(textBox6.Text);
                errorProvider1.SetError(textBox6, "");
                if (temp6 < 9 || temp6 > 101)
                {
                    errorProvider1.SetError(textBox6, "input diluar range amplitudo!!");
                    bStatus = false;
                }
                else
                {
                    errorProvider1.SetError(textBox6, "");
                }
                return bStatus;
            }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }

            private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }

            private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }

            private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }

            private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }

            private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }

            private void button3_Click(object sender, EventArgs e)
            {
                if (!isConnect)
                {
                    connect();
                }
                else
                {
                    disconnect();
                }
            }

            void getAvailComPorts()
            {
                ports = SerialPort.GetPortNames();
            }

            private void connect()
            {
                isConnect = true;
                string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
                port = new SerialPort(selectedPort, 9600);
                port.Open();
                button3.Text = "ON";
                onControls();
            }

            private void disconnect()
            {
                isConnect = false;
                port.Close();
                button3.Text = "OFF";
                OffControls();
                resetDefault();
            }

            private void onControls()
            {
                panel1.Enabled = true;
                panel2.Enabled = true;
                //button1.Enabled = true;
                //button2.Enabled = true;
                //linkLabel1.Enabled = true;
                //linkLabel2.Enabled = true;
                //textBox1.Enabled = true;
                //textBox3.Enabled = true;
                //textBox4.Enabled = true;
                //textBox5.Enabled = true;
            }

        private void OffControls()
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                //button1.Enabled = false;
                //button2.Enabled = false;
                //linkLabel1.Enabled = false;
                //linkLabel2.Enabled = false;
                //textBox1.Enabled = false;
                //textBox3.Enabled = false;
                //textBox4.Enabled = false;
                //textBox5.Enabled = false;
            }

            private void resetDefault()
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }
    }

