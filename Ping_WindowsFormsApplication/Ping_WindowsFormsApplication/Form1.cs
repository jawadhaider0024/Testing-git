using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace Ping_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            string args = textBox2.Text;
            string output1 = "";
            PingReply reply = pingSender.Send(args, timeout, buffer, options);

            if (reply.Status == IPStatus.Success)
            {
                textBox1.Text = "Success";


                output1= "Address: "+ reply.Address.ToString();
                output1= output1 +"\r\n"+"RoundTrip time: "+ reply.RoundtripTime;
                output1 = output1 + "\r\n" + "Time to live: " + reply.Options.Ttl;
                output1 = output1 + "\r\n" + "Don't fragment: " + reply.Options.DontFragment;
                output1 = output1 + "\r\n" + "Buffer size: " + reply.Buffer.Length;
                textBox3.Text = output1;


            }

            else

            {
                textBox1.Text = "No Success";
            
            }




        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
