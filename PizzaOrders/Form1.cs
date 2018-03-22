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

            PIZZA1.Name = Constants.P1_NAME; // pizza 1
            PIZZA1.Text = Constants.P1_TEXT;


            PIZZA2.Name = Constants.P2_NAME; // pizza 2
            PIZZA2.Text = Constants.P2_TEXT;

            PIZZA1AddCheckBox1.Name = Constants.P1_CHK1_NAME; //pizza 1 checkboxes 1-3
            PIZZA1AddCheckBox2.Name = Constants.P1_CHK2_NAME;
            PIZZA1AddCheckBox3.Name = Constants.P1_CHK3_NAME;

            PIZZA1AddCheckBox1.Text = Constants.P1_CHK1_TEXT + " " + Constants.P1_CHK1_TAG + " kr."; 
            PIZZA1AddCheckBox2.Text = Constants.P1_CHK2_TEXT + " " + Constants.P1_CHK2_TAG + " kr.";
            PIZZA1AddCheckBox3.Text = Constants.P1_CHK3_TEXT + " " + Constants.P1_CHK3_TAG + " kr.";

            PIZZA2AddCheckBox1.Name = Constants.P2_CHK1_NAME;    //pizza 2 checkboxes 1-3
            PIZZA2AddCheckBox2.Name = Constants.P2_CHK2_NAME;
            PIZZA2AddCheckBox3.Name = Constants.P2_CHK3_NAME;

            PIZZA2AddCheckBox1.Text = Constants.P2_CHK1_TEXT + " " + Constants.P2_CHK1_TAG + " kr."; 
            PIZZA2AddCheckBox2.Text = Constants.P2_CHK2_TEXT + " " + Constants.P2_CHK2_TAG + " kr.";
            PIZZA2AddCheckBox3.Text = Constants.P2_CHK3_TEXT + " " + Constants.P2_CHK3_TAG + " kr.";


            PIZZA1GroupBox1.Text = Constants.P1_GRP1_TEXT + " " + Constants.P1_GRP1_TAG + " kr.";
            PIZZA2GroupBox1.Text = Constants.P2_GRP1_TEXT + " " + Constants.P2_GRP1_TAG + " kr.";

            P1_KCAL.Name = Constants.P1_KCAL_NAME; // kalorietekstbox 1 -2
            P2_KCAL.Name = Constants.P2_KCAL_NAME;

            PIZZA1KaloriLabel.Name = Constants.P1_KCAL_SLICE_NAME;
            PIZZA2KaloriLabel.Name = Constants.P2_KCAL_SLICE_NAME;


            PIZZA1KaloriLabel.Text = Constants.KCAL_SLICE_TEXT;
            PIZZA2KaloriLabel.Text = Constants.KCAL_SLICE_TEXT;


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
                GroupBox panelGrpBox3 = panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "GroupBox3"));

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
                foreach (TextBox tBox in panelGrpBox3.Controls.OfType<TextBox>())
                {


                    foreach (Label label in panelGrpBox3.Controls.OfType<Label>())
                    {
                        label.Text = Constants.KCAL_SLICE_TEXT;
                        Console.WriteLine((string)tBox.Text);
                        int value;

                        if (int.TryParse(tBox.Text, out value) && value > 1 && value  < 11)
                        {
                            decimal i = PriceCatalog.GetValue(tBox.Name);
                            Console.WriteLine(i);
                            decimal value2 = 0;
                            if (value != 0)
                            {
                                if (label.Text == Constants.KCAL_SLICE_TEXT) 
                                 label.Text = Constants.KCAL_SLICE_TEXT + (i / value).ToString("##.##") + "KCal\n" +
                                 " Kalorier (family): " + ((i / value) * 1.5M).ToString("##.##") + "KCal";


                            }
                            else if (tBox.Text != "")
                            {
                                System.Windows.Forms.MessageBox.Show("Indtast 2 til 10 antal skiver");
                                return;
                            }
                            Console.WriteLine(value2);
                        }
                        else if (tBox.Text != "")
                        {
                            System.Windows.Forms.MessageBox.Show("Indtast 2 til 10 antal skiver");
                            return;
                        }


                    }
                }
            }

            PizzaOrder pizzaOrder = new PizzaOrder(order);
            Console.WriteLine(  pizzaOrder.DisplayPizzaOrder() );

            foreach (Panel panel in panels) // add to subtotal
            {
                panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "SubLabel")).Text = "Sub total: " + pizzaOrder.DisplayPizzaSubTotal(panel.Name);
            }

            this.Controls["totalLabel"].Text = "Total: " + pizzaOrder.total.ToString();

            if (pizzaOrder.total > 0)
            {
                PizzaCounter pizzaCounter = new PizzaCounter();
                this.Controls["bestillingsNummerLabel"].Text = "Dit bestillingsnummer er: " + pizzaCounter.GetCounter();
                this.Controls["bestilButton"].Enabled = true;
            }
            
        }

        private void bestilButton_Click(object sender, EventArgs e)
        {
          

            PizzaCounter pizzaCounter = new PizzaCounter();
            pizzaCounter.IncrementCounter();
            Clear(this);
            this.Controls["bestilButton"].Enabled = false;

        }
       

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Clear(this);
        }
        void Clear(Control ctrl)
        {
            if (ctrl is GroupBox)
            {
                foreach (CheckBox chkBox in ctrl.Controls.OfType<CheckBox>())
                {
                    chkBox.Checked = false;
                }
            }
            if (ctrl is TextBox) ctrl.Text = "";
            if (ctrl is Label && ctrl.Name.EndsWith("SubLabel")) ctrl.Text = "Sub Total:";
            if (ctrl is Label && ctrl.Name.EndsWith("totalLabel")) ctrl.Text = "Total: ";
            if (ctrl is Label && ctrl.Name.EndsWith("bestillingsNummerLabel")) ctrl.Text = "Dit bestillingsnummer er: ";
            if (ctrl is Label && ctrl.Text.StartsWith("Skær i skiver")) ctrl.Text = Constants.KCAL_SLICE_TEXT;

            foreach (Control childCtrl in ctrl.Controls) Clear(childCtrl);
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
      
    

