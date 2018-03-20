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
            //rejerTunPizzaGroupBox.Tag = "PIZZA1";
            //pepperoniPizzaGroupBox.Tag = "PIZZA2";

            // TODO : name ui elements according to constants

            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
              

            }


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
        private ArrayList OrderLine(TextBox tBox, string grpBoxTag, out bool abort)
        {
            ArrayList _temp = new ArrayList();
            string s = tBox.Name.StartsWith(Constants.PIZZA_LARGE) ? Constants.PIZZA_LARGE : Constants.PIZZA_SMALL;
            abort = false;
            int validation = ValidateTBox(tBox.Text);
            if (validation > 0)
            {
                _temp.Add(grpBoxTag);
                _temp.Add(s);
                _temp.Add(validation);
            } else if (tBox.Enabled)
            {
                abort = true;
                System.Windows.Forms.MessageBox.Show("Indtast 1 eller flere antal pizzaer eller fravælg pågældende pizza");
            }            
            return _temp;

        }
        private int ValidateTBox (string tBoxText)
        {
            return int.TryParse(tBoxText, out int parsed) ? parsed : 0;     
        }
        private void SetSubTotalLabel (PizzaOrder pizzaOrder)
        {
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                Label subtotal = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.EndsWith("SubTotalLabel"));
             //   Console.WriteLine(panel.Name);
                subtotal.Text = pizzaOrder.DisplayPizzaSubTotal(panel.Name);
            }
        }

        private void BeregnButton1_Click(object sender, EventArgs e)
        {

            ArrayList order = new ArrayList();

            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                    GroupBox pizza =  panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith("PizzaGroupBox"));

                    foreach (TextBox tBox in pizza.Controls.OfType<TextBox>())
                    {
                        ArrayList newTemp = OrderLine(tBox, (string)panel.Name, out bool abort);
                        if (abort) return;
                        if (tBox.Enabled && newTemp.Count > 0) order.Add(newTemp);
                    }
              
            }

          //  order.ToList().ForEach(n => Console.WriteLine("order key: " + n.Key + " order antal: " + n.Value));

            PizzaOrder pizzaOrder = new PizzaOrder(order);
            Console.WriteLine(  pizzaOrder.DisplayPizzaOrder() );

            SetSubTotalLabel(pizzaOrder); // TODO : improve me!

        }

    }
    static class Constants
    {
        public const string PIZZA_LARGE= "family";
        public const string PIZZA_SMALL = "almindelig";

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
        public PizzaOrder(ArrayList arr)
        {
            foreach (ArrayList orderline in arr)
            {
                //   Console.WriteLine("[{0}]", string.Join(", ", orderline.ToArray()));
         
                CollectPizzas((string)orderline[0], (string)orderline[1], (int)orderline[2]);
                CalculatePizzas((string)orderline[0], (string)orderline[1], (int)orderline[2]);

            }

        }
        public Dictionary<string, int> PizzaList = new Dictionary<string,int>();
        public Dictionary<string, decimal> PizzaSum = new Dictionary<string, decimal>();
      
        public void CalculatePizzas(string navn, string size, int antal)
        {
            foreach (FieldInfo field in typeof(Constants).GetFields().Where(f => f.Name.StartsWith(navn + "_PRICE")))
            {
                decimal sizeModifier = (size == Constants.PIZZA_LARGE) ? 1.5M : 1;
               // Console.WriteLine((int)field.GetRawConstantValue());
                if (PizzaSum.ContainsKey(navn))
                {
                    PizzaSum[navn] += (int)field.GetRawConstantValue() * antal * sizeModifier;
                 //   Console.WriteLine(value);
                } else
                {
                    PizzaSum.Add(navn, (int)field.GetRawConstantValue() * antal * sizeModifier);
                }         
            }
            // PizzaSum.ToList().ForEach(Console.WriteLine);          
        }
        public void CollectPizzas (string navn, string size, int antal)
        {
           // Console.WriteLine(s);
            foreach (FieldInfo field in typeof(Constants).GetFields().Where(f => f.Name.StartsWith(navn + "_NAME")))
            {
                if (PizzaList.ContainsKey(navn + " " + size))
                {
                    PizzaList[navn + " " + size] =  antal;
                } else
                {
                   // Console.WriteLine(size);
                    PizzaList.Add(field.GetRawConstantValue().ToString() + " " + size, antal);
                }
               
            }        
        }
        public string DisplayPizzaOrder ()
        {
            string s = "";
            foreach (KeyValuePair<string, int> kvp in PizzaList)
            {
            
               s += kvp.Key + " " + kvp.Value + "\n";
            }
            return s;
        }
        public string DisplayPizzaSubTotal(string s )
        {
            if (PizzaSum.ContainsKey(s))
            {
                return PizzaSum[s].ToString();
            
            } else { return ""; }
            
        }
        public string GetInfo ()
        {
            return this.ToString();
        }
    }
    

}
      
    

