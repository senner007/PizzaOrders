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
using System.Reflection;
using System.Collections;

namespace PizzaOrders
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            rejerMedTunGroupBox.Tag = "PIZZA1";
            pepperoniGroupBox.Tag = "PIZZA2";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void pizzaCheckBoxGlobal_CheckedChanged(object sender, EventArgs e) // global
        {
            almPizzaTextbox1.Enabled = almPizzaCheckBox1.Checked == true ? true : false;
            almPizzaTextbox2.Enabled = almPizzaCheckBox2.Checked == true ? true : false;
            familyPizzaTextbox1.Enabled = familyPizzaCheckBox1.Checked == true ? true : false;
            familyPizzaTextbox2.Enabled = familyPizzaCheckBox2.Checked == true ? true : false;
        }

        private void BeregnButton1_Click(object sender, EventArgs e)
        {

            ArrayList order = new ArrayList();

            var myGrpBoxes = pizzasPanel.Controls
                        .OfType<GroupBox>()
                        .Where(x => x.Name.ToLower().EndsWith("groupbox"));

            
            foreach (GroupBox grpBox in myGrpBoxes)
            {
                var myTextBoxes = grpBox.Controls
                        .OfType<TextBox>();

               
                foreach (TextBox tBox in myTextBoxes)
                {
                    int value;
                    ArrayList _temp = new ArrayList();

                    string s = tBox.Name.StartsWith("family") ? "family" : "almindelig";
                   

                    if (int.TryParse(tBox.Text, out value))
                    {
                       
                      //  Console.WriteLine(tBox.Text);
                        _temp.Add(grpBox.Tag + s);
                        _temp.Add(value);

                    }
                    else
                    {
                        Console.WriteLine(tBox.Name);
                        Console.WriteLine(tBox.Enabled);
                        Console.WriteLine("You must enter a number");
                    }
                    order.Add(_temp);

                }

                //( Console.WriteLine(grpBox.Tag);
            }

            //  order.ToList().ForEach(n => Console.WriteLine("order key: " + n.Key + " order antal: " + n.Value));

            foreach (ArrayList orderline in order)
            {
                if (orderline.Count > 0)
                {
                    Console.WriteLine("[{0}]", string.Join(", ", orderline.ToArray()));
                }

             }



            }
    }
    static class Constants
    {
        public const string PIZZA1_NAME = "REJER MED OST";
        public const int PIZZA1_PRICE = 64;
        public const string PIZZA1_ADD1_NAME = "LØG";
        public const string PIZZA1_ADD2_NAME = "REJER";
        public const string PIZZA1_ADD3_NAME = "TUN";
        public const int PIZZA1_ADD1_PRICE = 5,
                         PIZZA1_ADD2_PRICE = 10,
                         PIZZA1_ADD3_PRICE = 7;
        public const float PIZZA1_KCAL = 42.2F;

        public const string PIZZA2_NAME = "PEPPERONI";
        public const int PIZZA2_PRICE = 59;
        public const string PIZZA2_ADD1_NAME = "PEPPERONI";
        public const string PIZZA2_ADD2_NAME = "CHAMPIGNON";
        public const string PIZZA2_ADD3_NAME = "OST";
        public const int PIZZA2_ADD1_PRICE = 8,
                         PIZZA2_ADD2_PRICE = 11,
                         PIZZA2_ADD3_PRICE = 6;
        public const float PIZZA1_KCA2 = 31.6F;

    }
    class PizzaOrder
    {
        public PizzaOrder(string navn, int antal)
        {
           
        }
        public string GetInfo ()
        {
            return this.ToString();
        }
    }
   
   

}
      
    

