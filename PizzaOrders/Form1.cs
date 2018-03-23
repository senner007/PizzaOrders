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

            PIZZA1.Text = Constants.P1_TEXT;

            PIZZA2.Text = Constants.P2_TEXT;


            //PIZZA1KaloriLabel.Name = Constants.KCAL_SLICE_NAME;
            //PIZZA2KaloriLabel.Name = Constants.KCAL_SLICE_NAME;

            //PIZZA1KaloriLabel.Text = Constants.KCAL_SLICE_TEXT;
            //PIZZA2KaloriLabel.Text = Constants.KCAL_SLICE_TEXT;


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
            PendingOrder pizzaCounter = new PendingOrder();
            pizzaCounter.IncrementCounter();
            string bestilling = "Dit bestillingsnummer er: ";
            return bestilling + " " + pizzaCounter.GetCounter();
        }
        //public static T FindParent<T>(Control ctrl)
        //{
        //    var curParent = ctrl.Parent;
        //    while (curParent != null && !(curParent is T))
        //    {
        //        curParent = curParent.Parent;
        //    }
        //    return (T)(object)curParent;
        //}
        public static T Findall<T>(Control ctrl, string name)
        {

            return (T)(object)ctrl.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(name));
        }


        private void BeregnButton1_Click(object sender, EventArgs e)
        {

            ArrayList order = new ArrayList();
            var panels = this.Controls.OfType<Panel>();

            foreach (Panel panel in panels)
            {
             

              //  GroupBox panelGrpBox1 =  panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "GroupBox1"));
                //GroupBox panelGrpBox2 = panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "GroupBox2"));
                //GroupBox panelGrpBox3 = panel.Controls.OfType<GroupBox>().FirstOrDefault(l => l.Name.EndsWith(panel.Name + "GroupBox3"));

              //  Tbox d = FindParent<Panel>(panelGrpBox3);
                GroupBox panelGrpBox1 = Findall<GroupBox>(panel, panel.Name + "GroupBox1");
                GroupBox panelGrpBox2 = Findall<GroupBox>(panel, panel.Name + "GroupBox2");
                GroupBox panelGrpBox3 = Findall<GroupBox>(panel, panel.Name + "GroupBox3");

                //  Console.WriteLine(ds.Name);

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


                        if (int.TryParse(tBox.Text, out int value) && value > 1 && value  < 11)
                        {
                            decimal i = GetFieldValue.Get(tBox.Name);            
                            if (value != 0)
                            {

                                 label.Text = Constants.KCAL_SLICE_TEXT + (i / value).ToString("##.#") + "KCal\n" +
                                 " Kalorier (family): " + ((i / value) * 1.5M).ToString("##.#") + "KCal";
                            }
                        }
                        else if (tBox.Text != "")
                        {
                            System.Windows.Forms.MessageBox.Show("Indtast 2 til 10 antal skiver");
                            return;
                        }

                    }
                }
            }

            PizzaOrder pizzaOrder = new PizzaOrder(order);  // Get pizza order

            foreach (Panel panel in panels) // add to subtotal
            {
                panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.EndsWith("SubTotal")).Text = "SubTotal: " + pizzaOrder.GetSubtotal(panel.Name); // Sub total
            }

            this.Controls["totalLabel"].Text = "Total: " + pizzaOrder.Total.ToString();  // Total

            if (pizzaOrder.Total > 0)
            {
                PendingOrder pizzaCounter = new PendingOrder(pizzaOrder.GetInfo());
                this.Controls["bestillingsNummerLabel"].Text = "Dit bestillingsnummer er: " + pizzaCounter.GetCounter();
                this.Controls["bestilButton"].Enabled = true;
            }

            this.Controls["forventetLabel"].Text = "Forventet færdig: " + DateTime.Now.AddMinutes(4).ToString("T"); // klokkeslet
 

        }


        private void bestilButton_Click(object sender, EventArgs e)
        {
            PendingOrder pizzaCounter = new PendingOrder();          
            System.Windows.Forms.MessageBox.Show(pizzaCounter.GetOrder() + "\nDit Bestillingsnummer er " + pizzaCounter.GetCounter());
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
            if (ctrl is Label && ctrl.Name.EndsWith("forventetLabel")) ctrl.Text = "Forventet færdig: ";

            foreach (Control childCtrl in ctrl.Controls) Clear(childCtrl);
        }
    }
    class PendingOrder
    {
        public static int Counter { get; private set; } = 1;
        public static string Pending { get; private set; }
        public PendingOrder() {}
        public PendingOrder(string pending) { Pending = pending; }
        public void IncrementCounter() => Counter++;    
        public string GetCounter() => Counter.ToString();
        public string GetOrder() => Pending.ToString();
    }
    static class GetFieldValue
    {
        public static int Get (string name)
        {
            var prop = typeof(Constants).GetField(name).GetValue(null);
            return (int)prop;
        } 
    }
   
    


}
      
    

