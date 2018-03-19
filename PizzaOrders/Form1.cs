using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PizzaOrders
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (almPizzaCheckBox1.Checked == true)
            {

                RejerTunAntalLabel.Text = "Checked";
                almPizzaTextbox1.Enabled = true;

            }
            else
            {
                RejerTunAntalLabel.Text = "Unchecked";
                almPizzaTextbox1.Enabled = false;

            }

        }

        private void beregnButton1_Click(object sender, EventArgs e)
        {
            Calculate calculate = new Calculate("hello");
            Console.WriteLine("Hello from beregn event");
        }
    }
    class Calculate
    {
        public Calculate(string s)
        {
            Console.WriteLine(s);
        }

    }
}
