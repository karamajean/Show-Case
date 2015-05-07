using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_Control
{   

    public partial class Pantek_Demo : Form
    {   
        byte[] name = new byte[9];
        byte[] oled = new byte[32];
     
        public struct s_msg_temp_report {
	        public byte id0;
            public byte id1;
            public byte[] name;
            public byte[] oled;
            public byte led;           
	        public byte heatbeat;
            public byte tempature;
            public byte kionix;            
        };
        
        s_msg_temp_report t_msg_temp_report = new s_msg_temp_report();
        
        
        public Pantek_Demo()
        {
            InitializeComponent();
            init_packet();
           
        }

        private void init_packet()
        {            
            //int i;
            t_msg_temp_report.id0 = 0;
            t_msg_temp_report.id1 = 0;
            t_msg_temp_report.led = 0;

            //for ( i = 0; i < t_msg_temp_report.name.Length; i++)
            //{
            //    t_msg_temp_report.name[i] = 0x00;
          //  }
           // for ( i = 0; i < t_msg_temp_report.oled.Length; i++)
          //  {
//t_msg_temp_report.oled[i] = 0x00;
          //  }
            t_msg_temp_report.heatbeat = 0;
            t_msg_temp_report.kionix = 0;
            t_msg_temp_report.tempature = 0;

        }

        private void Pantek_Demo_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            tbxCount.Text = "100";
            tbxHeatbeat.Text = "130";
           
            tbxTemp.Text = "25";          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbxCount.Text = string.Empty;
            tbxHeatbeat.Text = string.Empty;
            tbxTemp.Text = string.Empty;
            listBox1.Text = string.Empty;
            listBox1.Items.Clear();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
              ReceiveBroadcastMessage((EndPoint ep, string data) =>
            {
               this.Invoke((MethodInvoker)delegate()
                {
                   //listBox1.Items.Add(string.Format("received: {0} from: {1}", data, ep.ToString()));
                    listBox1.Items.Add(string.Format("received Data from: {0}", ep.ToString()));
                   listBox1.SelectedIndex = listBox1.Items.Count - 1;

                   int i;
                   Random num = new Random();//亂數種子            
                   i = num.Next(100, 110);
                   tbxHeatbeat.Text = i.ToString();

                   //tbxHeatbeat.Text = t_msg_temp_report.heatbeat.ToString();

                   tbxTemp.Text = t_msg_temp_report.tempature.ToString();
                   tbxCount.Text = t_msg_temp_report.kionix.ToString();
                   //MessageBox.Show("ReceiveBroadcastMessage = ");
                });

            }, 6666 );
        }

        private static void BroadcastMessage(string message, int port)
        {
            BroadcastMessage(Encoding.ASCII.GetBytes(message), port);
        }

         private static void BroadcastMessage(byte[] message, int port)

        {

            using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp))
            {
                sock.EnableBroadcast = true;
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                var iep = new IPEndPoint(IPAddress.Broadcast, port);
                sock.SendTo(message, iep);
            }

        }

        private void ReceiveBroadcastMessage(Action<EndPoint, string> receivedAction, int port)
        {
            ReceiveBroadcastMessage((ep, data) =>
           {
              var stringData = Encoding.ASCII.GetString(data);
              receivedAction(ep, stringData);
            }, port);

        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        private void write2Table(byte[] data)
        {
           
#if true
          if (data[0] == 0x80 && data[1] == 0x80)
          {
                t_msg_temp_report.id0 = data[0];
                t_msg_temp_report.id1 = data[1];
                t_msg_temp_report.led = data[43];

              
                t_msg_temp_report.heatbeat = data[44];

                t_msg_temp_report.tempature = data[45];  
                t_msg_temp_report.kionix = data[46];
                                 
                
#else
                MessageBox.Show("led = " + Convert.ToString(data[43], 10));
                MessageBox.Show("heatbeat = " + Convert.ToString(data[44], 10));
                MessageBox.Show("kionix = " + Convert.ToString(data[45], 10));
                MessageBox.Show("tempature = " + Convert.ToString(data[46], 10));
#endif
            }

        }
        
      

        private void ReceiveBroadcastMessage(Action<EndPoint, byte[]> receivedAction, int port)
        {
            using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                var ep = new IPEndPoint(IPAddress.Any, port) as EndPoint;
                sock.Bind(ep);

                while (true)
                {
                   // MessageBox.Show("171 = ");
                   var buffer = new byte[128];
                   var recv = sock.ReceiveFrom(buffer, ref ep);
                   var data = new byte[recv];
                   Array.Copy(buffer, 0, data, 0, recv);                  

                   write2Table(buffer);
                   //MessageBox.Show(ByteArrayToHexString(buffer));

                   receivedAction(ep, data);
                   Thread.Sleep(500);
                   Application.DoEvents();
                }

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }




    }
}
