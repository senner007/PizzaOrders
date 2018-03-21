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
        private ArrayList OrderLine(TextBox tBox, string pizzaId, string pizzaText, out bool abort)
        {
            ArrayList _temp = new ArrayList();
            string s = tBox.Name.StartsWith(Constants.PIZZA_LARGE) ? Constants.PIZZA_LARGE : Constants.PIZZA_SMALL;
            abort = false;
            int validation = ValidateTBox(tBox.Text);
            if (validation > 0)
            {
                _temp.Add(pizzaId);
                _temp.Add(pizzaText);
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

        private void BeregnButton1_Click(object sender, EventArgs e)
        {

            ArrayList order = new ArrayList();
            var panels = this.Controls.OfType<Panel>();


            foreach (Panel panel in panels)
            {
                    GroupBox panelGrpBox1 =  panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "GroupBox1"));
                    GroupBox panelGrpBox2 = panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "GroupBox2"));

                foreach (TextBox tBox in panelGrpBox1.Controls.OfType<TextBox>())
                {
                     ArrayList orderline = OrderLine(tBox, (string)panel.Name, panelGrpBox1.Text, out bool abort );
                     if (abort) return;
                     ArrayList added = new ArrayList();

                     foreach (CheckBox chkBox in panelGrpBox2.Controls.OfType<CheckBox>())
                     { 
                        if (chkBox.Checked) added.Add(chkBox.Name);
                     }
                     orderline.Add(added);

                     if (tBox.Enabled && orderline.Count > 0) order.Add(orderline);

                }

            }

            PizzaOrder pizzaOrder = new PizzaOrder(order);
            Console.WriteLine(  pizzaOrder.DisplayPizzaOrder() );

            foreach (Panel panel in panels) // add to subtotal
            {
                panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "SubLabel")).Text = pizzaOrder.DisplayPizzaSubTotal(panel.Name);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    class PizzaOrder
    {
        public PizzaOrder(ArrayList arr)
        {
            foreach (ArrayList orderline in arr)
            {
                 Console.WriteLine("[{0}]", string.Join(", ", orderline.ToArray()));

            //    string added = (string)orderline[3] + (string)orderline[4] + (string)orderline[5];
             //   var props = typeof(Constants).GetField((string)orderline[3]).GetValue(null);
              

                CollectPizzas((string)orderline[0], (string)orderline[1], (string)orderline[2], (int)orderline[3], CollectAdded((ArrayList)orderline[4]));

                CalculatePizzas((string)orderline[0], (string)orderline[1], (string)orderline[2], (int)orderline[3]);
            }
        }
        public Dictionary<string, int> PizzaList = new Dictionary<string,int>();
        public Dictionary<string, decimal> PizzaSum = new Dictionary<string, decimal>();

        public string CollectAdded(ArrayList arr)
        {
            string s = "";
            foreach (string added in arr)
            {
                string[] tokens = added.Split('_');
                s += tokens[1] + " ";
            }
            
            return s.Trim();
        }
        public void CalculatePizzas(string id, string navn, string size, int antal)
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
        public void CollectPizzas (string id, string navn, string size, int antal, string added)
        {
                string key = navn + " " + size + " " + added;
                if (PizzaList.ContainsKey(key))
                {
                    PizzaList[key] =  antal;
                } else
                {
                    PizzaList.Add(key, antal);
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
    static class Constants
    {
        public const string PIZZA_LARGE = "family";
        public const string PIZZA_SMALL = "almindelig";

        public const string PIZZA1_NAME = "REJER MED OST";
        public const int PIZZA1_PRICE = 64;
        public const string PIZZA1AddCheckBox1 = "LØG";
        public const string PIZZA1AddCheckBox2 = "REJER";
        public const string PIZZA1AddCheckBox3 = "TUN";
        public const int PIZZA1_ADD1_PRICE = 5,
                         PIZZA1_ADD2_PRICE = 10,
                         PIZZA1_ADD3_PRICE = 7;
        public const float PIZZA1_KCAL = 42.2F;

        public const string PIZZA2_NAME = "PEPPERONI";
        public const int PIZZA2_PRICE = 59;
        public const string PIZZA2AddCheckBox1 = "PEPPERONI";
        public const string PIZZA2AddCheckBox2 = "CHAMPIGNON";
        public const string PIZZA2AddCheckBox3 = "OST";
        public const int PIZZA2_ADD1_PRICE = 8,
                         PIZZA2_ADD2_PRICE = 11,
                         PIZZA2_ADD3_PRICE = 6;
        public const float PIZZA1_KCA2 = 31.6F;

    }


}
      
    

