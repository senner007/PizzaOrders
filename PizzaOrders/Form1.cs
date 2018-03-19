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

        private void AlmPizzaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {         
            almPizzaTextbox1.Enabled = almPizzaCheckBox1.Checked == true ? true : false;
        }
        private void familyPizzaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            familyPizzaTextbox1.Enabled = familyPizzaCheckBox1.Checked == true ? true : false;
        }
        private void almPizzaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            almPizzaTextbox2.Enabled = almPizzaCheckBox2.Checked == true ? true : false;

        }
        private void familyPizzaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            familyPizzaTextbox2.Enabled = familyPizzaCheckBox2.Checked == true ? true : false;
        }

        private void BeregnButton1_Click(object sender, EventArgs e)
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
