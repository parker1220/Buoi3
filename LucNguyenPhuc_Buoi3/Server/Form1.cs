using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class Server : Form
    {
        Socket server;
        Socket client;
        byte[] data;

        private bool btn0clicked = false;
        private bool btn1clicked = false;
        private bool btn2clicked = false;
        int num;
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            server.Bind(ipep);
            server.Listen(10);
            client = server.Accept();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Kéo";
            btn0clicked = true;
            btn1clicked = false;
            btn2clicked = false;
            send();
            receive();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Búa";
            btn0clicked = false;
            btn1clicked = false;
            btn2clicked = true;
            send();
            receive();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            btn0clicked = false;
            btn1clicked = true;
            btn2clicked = false;
            send();
            receive();
        }
        public void send()
        {
            if (btn0clicked == true)
            {
                num = 0;
                data = Encoding.ASCII.GetBytes(num.ToString());
                client.Send(data);
            }
            if (btn1clicked == true)
            {
                num = 1;
                data = Encoding.ASCII.GetBytes(num.ToString());
                client.Send(data);
            }
            if (btn2clicked == true)
            {
                num = 2;
                data = Encoding.ASCII.GetBytes(num.ToString());
                client.Send(data);
            }
        }
        public void receive()
        {
            data = new byte[1024];

            if (data != null)
            {
                client.Receive(data);
                int data1 = Convert.ToInt32(Encoding.ASCII.GetString(data));
                if (btn0clicked)
                {
                    if (data1 == 0)
                        textBox2.Text = "Hòa";
                    if (data1 == 1)
                        textBox2.Text = "Thắng";
                    if (data1 == 2)
                        textBox2.Text = "Thua";

                }
                if (btn1clicked)
                {
                    if (data1 == 0)
                        textBox2.Text = "Thua";
                    if (data1 == 1)
                        textBox2.Text = "Hòa";
                    if (data1 == 2)
                        textBox2.Text = "Thắng";
                }
                if (btn2clicked)
                {
                    if (data1 == 0)
                        textBox2.Text = "Thắng";
                    if (data1 == 1)
                        textBox2.Text = "Thua";
                    if (data1 == 2)
                        textBox2.Text = "Hòa";
                }
            }

        }
    }
}
