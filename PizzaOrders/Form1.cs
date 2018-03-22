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

            // TODO : Name groupBox text + tag

            PIZZA1.Name = Constants.P1_NAME;
            PIZZA1.Text = Constants.P1_TEXT;


            PIZZA2.Name = Constants.P2_NAME;
            PIZZA2.Text = Constants.P2_TEXT;

            PIZZA1AddCheckBox1.Name = Constants.P1_CHK1_NAME;
            PIZZA1AddCheckBox2.Name = Constants.P1_CHK2_NAME;
            PIZZA1AddCheckBox3.Name = Constants.P1_CHK3_NAME;

            PIZZA1AddCheckBox1.Text = Constants.P1_CHK1_TEXT + " " + Constants.P1_CHK1_TAG + " kr.";
            PIZZA1AddCheckBox2.Text = Constants.P1_CHK2_TEXT + " " + Constants.P1_CHK2_TAG + " kr.";
            PIZZA1AddCheckBox3.Text = Constants.P1_CHK3_TEXT + " " + Constants.P1_CHK3_TAG + " kr.";

            PIZZA2AddCheckBox1.Name = Constants.P2_CHK1_NAME;
            PIZZA2AddCheckBox2.Name = Constants.P2_CHK2_NAME;
            PIZZA2AddCheckBox3.Name = Constants.P2_CHK3_NAME;

            PIZZA2AddCheckBox1.Text = Constants.P2_CHK1_TEXT + " " + Constants.P2_CHK1_TAG + " kr.";
            PIZZA2AddCheckBox2.Text = Constants.P2_CHK2_TEXT + " " + Constants.P2_CHK2_TAG + " kr.";
            PIZZA2AddCheckBox3.Text = Constants.P2_CHK3_TEXT + " " + Constants.P2_CHK3_TAG + " kr.";


            PIZZA1GroupBox1.Text = Constants.P1_GRP1_TEXT + " " + Constants.P1_GRP1_TAG + " kr.";
            PIZZA2GroupBox1.Text = Constants.P2_GRP1_TEXT + " " + Constants.P2_GRP1_TAG + " kr.";


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
            string s = tBox.Name.StartsWith("family") ? "family" : "almindelig";
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
        private string IncrementCounter ()
        {
            PizzaCounter pizzaCounter = new PizzaCounter();
            pizzaCounter.IncrementCounter();
            string bestilling = "Dit bestillingsnummer er: ";
            return bestilling + " " + pizzaCounter.GetCounter();
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
                        if (chkBox.Checked) added.Add(chkBox.Name + "-" + chkBox.Text);
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

            this.Controls["totalLabel"].Text = pizzaOrder.total.ToString();

            if (pizzaOrder.total > 0)
            {
                PizzaCounter pizzaCounter = new PizzaCounter();
                this.Controls["bestillingsNummerLabel"].Text = "Dit bestillingsnummer er: " + pizzaCounter.GetCounter();
                this.Controls["bestilButton"].Enabled = true;
            }
            

        }

        private void bestilButton_Click(object sender, EventArgs e)
        {
            this.Controls["bestillingsNummerLabel"].Text = "Dit bestillingsnummer er: ";

            PizzaCounter pizzaCounter = new PizzaCounter();
            pizzaCounter.IncrementCounter();
            ClearThem(this);
            this.Controls["bestilButton"].Enabled = false;

        }
        void ClearThem(Control ctrl)
        {
            if (ctrl is GroupBox) {
                foreach (CheckBox chkBox in ctrl.Controls.OfType<CheckBox>())
                {
                    chkBox.Checked = false;
                }
            }
            if (ctrl is TextBox) ctrl.Text = "";
            foreach (Control childCtrl in ctrl.Controls) ClearThem(childCtrl);
        }

    }
    class PizzaCounter
    {
        public static int Counter { get; private set; } = 1;
        public PizzaCounter()
        {

        }
        public void IncrementCounter ()
        {
            Counter++;
        }
        public string GetCounter ()
        {
            return Counter.ToString();
        }
    }
    class PizzaOrder
    {
        public PizzaOrder(ArrayList arr)
        {
            foreach (ArrayList orderline in arr)
            {
               //  Console.WriteLine("[{0}]", string.Join(", ", orderline.ToArray()));

            //    string added = (string)orderline[3] + (string)orderline[4] + (string)orderline[5];
             //   var props = typeof(Constants).GetField((string)orderline[3]).GetValue(null);
              

                CollectPizzas((string)orderline[0], (string)orderline[1], (string)orderline[2], (int)orderline[3], CollectAdded((ArrayList)orderline[4]));

                CalculatePizzas((string)orderline[0], (string)orderline[1], (string)orderline[2], (int)orderline[3], CalculateAdded((ArrayList)orderline[4]));
            }
        }
        public Dictionary<string, int> PizzaList = new Dictionary<string,int>();
        public Dictionary<string, decimal> PizzaSum = new Dictionary<string, decimal>();
        public decimal total { get; private set; } = 0;

        public string CollectAdded(ArrayList arr)
        {
            string s = "";
            foreach (string added in arr)
            {
                string[] tokens = added.Split('-');              
                s += tokens[1] + " ";
            }
            
            return s.Trim();
        }
        public int CalculateAdded(ArrayList arr)
        {
           
            List<int> list = new List<int>();
            foreach (string added in arr)
            {
               
                string[] tokens = added.Split('-');
                int addPrice = PriceCatalog.GetValue(tokens[0]);

                list.Add(addPrice);
            }
            Console.WriteLine(list.Sum());
            return list.Sum();
        }
        public void CalculatePizzas(string id, string navn, string size, int antal, int added)
        {
            int idPrice = PriceCatalog.GetValue(id);           
            decimal sizeModifier = (size == "family") ? 1.5M : 1;
            string key = id;
            decimal subtotal = (idPrice * antal * sizeModifier ) + (added * antal); 
            if (PizzaSum.ContainsKey(key))
            {
                PizzaSum[key] += subtotal;
                total += subtotal;
            } else
            {
                PizzaSum.Add( key, subtotal);
            }
            total += subtotal;
           
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
            return (PizzaSum.ContainsKey(s)) ? PizzaSum[s].ToString() : "";
        }
    }
   
    static class Constants_old
    {
        public const string PIZZA_LARGE = "family";
        public const string PIZZA_SMALL = "almindelig";

        public const string PIZZA1_NAME = "REJER MED OST";
        public const int PIZZA1_PRICE = 64;
        //public const string PIZZA1AddCheckBox1 = "LØG";
        //public const string PIZZA1AddCheckBox2 = "REJER";
        //public const string PIZZA1AddCheckBox3 = "TUN";
        public const int PIZZA1AddCheckBox1 = 5,
                         PIZZA1AddCheckBox2 = 10,
                         PIZZA1AddCheckBox3 = 7;

        public const float PIZZA1_KCAL = 42.2F;

        public const string PIZZA2_NAME = "PEPPERONI";
        public const int PIZZA2_PRICE = 59;
        //public const string PIZZA2AddCheckBox1 = "PEPPERONI";
        //public const string PIZZA2AddCheckBox2 = "CHAMPIGNON";
        //public const string PIZZA2AddCheckBox3 = "OST";
        public const int PIZZA2AddCheckBox1 = 8,
                         PIZZA2AddCheckBox2 = 11,
                         PIZZA2AddCheckBox3 = 6;
        public const float PIZZA1_KCA2 = 31.6F;

    }
    


}
      
    

