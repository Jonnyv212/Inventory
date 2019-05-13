using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
namespace Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Textbox cannot be empty.");
                }
                else
                {
                    richTextBox1.Clear();
                    // string machineName = textBox1.Text;
                    // machineName = System.Environment.
                    //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    //string blah = Environment.OSVersion.ToString();

                    IPHostEntry hostname = Dns.GetHostEntry(textBox1.Text);
                    System.Environment.GetEnvironmentVariable(textBox1.Text);

                    richTextBox1.Text = ("Host name : " + hostname.HostName + "\n\nCurrent User: " + "\n\nIP address List : \n");
                    label1.ForeColor = Color.Green;
                    label1.Text = "ONLINE";
                    for (int index = 0; index < hostname.AddressList.Length; index++)
                    {
                        richTextBox1.AppendText(hostname.AddressList[index].ToString() + "\n");
                    }
                }
            }
            catch(SocketException)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "OFFLINE";
                richTextBox1.Text = ("Hostname: Offline or does not exist.");
            }

        }

        private static void GetComponent(string hwclass, string syntax)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                Console.WriteLine(Convert.ToString(mj[syntax]));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetComponent("Win32_VideoController", "Name");
            Console.Read();
        }
    }
}
