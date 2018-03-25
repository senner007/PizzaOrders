using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

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

        private void pizzaCheckBoxGlobal_CheckedChanged(object sender, EventArgs e) 
        {
            var send = ((CheckBox)sender);
            send.Parent.Controls.OfType<TextBox>()
                .FirstOrDefault(t => t.Tag.ToString()== send.Tag.ToString()).Enabled = send.Checked;
        }

        private int ValidateTBox (string tBoxText) => int.TryParse(tBoxText, out int parsed) ? parsed : 0;     
    
        void GetPizza(Panel panel, ref List<OrderLine> order)
        {
            
            GroupBox pizzaGrp1 = panel.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString() == "PizzaGrp1").FirstOrDefault();
            GroupBox panelGrpBox2 = panel.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString() == "EkstrasGrp2").FirstOrDefault();
            foreach (TextBox tBox in pizzaGrp1.Controls.OfType<TextBox>())
            {
                OrderLine orderline = new OrderLine(); // new orderline(n)(max 4)
                // add pizzas from groupbox 1
                int antalValidated = ValidateTBox(tBox.Text);
                if (tBox.Enabled && antalValidated < 1)
                {
                    System.Windows.Forms.MessageBox
                        .Show("Indtast 1 eller flere antal pizzaer eller fravælg pågældende pizza");
                    return;
                }
                orderline.id = panel.Tag.ToString();
                orderline.name = pizzaGrp1.Text;
                orderline.size = tBox.Tag.ToString().StartsWith("fam") ? "family(pris x 1,5)" : "almindelig";
                orderline.antal = antalValidated;
    
                Type type = Type.GetType("PizzaOrders." + panel.Tag.ToString());  // Get from PIZZA1 or PIZZA2 Constants      
                orderline.price = (int)type.GetField("PRICE").GetValue(null);

                // add added from groupbox 2
                int index = 1;
                foreach (CheckBox added in panelGrpBox2.Controls.OfType<CheckBox>())
                {
                   if(added.Checked) orderline.added.Add(new AddedLine(added.Text, (int)type.GetField("ADDED" + index).GetValue(null)));
                    index++;
                }

                if (tBox.Enabled && orderline.antal > 0) order.Add(orderline);
            }
        }
        public int GetKcalSlices (string ToValidate)
        {
            return (int.TryParse(ToValidate, out int value) && value > 1 && value < 11) ? value : 1;
        }
        public string SetKcal(int ToValidate, string tBoxName, string panelTag)
        {
            // Get from PIZZA1 or PIZZA2 Constants
            decimal i = (int)Type.GetType("PizzaOrders." + panelTag).GetField("KCAL").GetValue(null);
            return (i / ToValidate).ToString("##.#") + "KCal\n" +
                    " Kalorier (family): " + ((i / ToValidate) * 1.5M).ToString("##.#") + "KCal";
        }
        private void BeregnButton1_Click(object sender, EventArgs e)        // beregn knap
        {

            List<OrderLine> order = new List<OrderLine>();
            var panels = this.Controls.OfType<Panel>();
           
            foreach (Panel panel in panels)
            {
                GetPizza(panel, ref order); // get Pizza

                GroupBox kcalGrp3 = panel.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString() == "KcalGrp3").FirstOrDefault();
                TextBox kcaltBox = kcalGrp3.Controls.OfType<TextBox>().FirstOrDefault();

                int slices = GetKcalSlices(kcaltBox.Text);
                if (slices == 1) kcaltBox.Text = "1";

                kcalGrp3.Controls.OfType<Label>().FirstOrDefault().Text =   // Get/Set Kcal
                    "Skær i 2-10 skiver: \n Kalorier pr skive = " + SetKcal(slices, kcaltBox.Tag.ToString() , panel.Tag.ToString());
            }

            PizzaOrder pizzaOrder = new PizzaOrder(order);  // New pizza order

            foreach (Panel panel in panels) // add to subtotal
            {
                panel.Controls.OfType<Label>().Where(x => x.Tag.ToString() == panel.Tag + "SubTotal").FirstOrDefault()
                    .Text = "SubTotal: " + pizzaOrder.GetSubtotal(panel.Tag.ToString()).ToString("#.00", CultureInfo.InvariantCulture);  // Sub total
            }

            this.totalLabel.Text = "Total: " + pizzaOrder.Total.ToString("#.00", CultureInfo.InvariantCulture);  // Total

            if (pizzaOrder.Total > 0)
            {
                PendingOrder pizzaCounter = new PendingOrder(pizzaOrder.GetInfo()); 
                // Add new pizza order to pending order
                this.bestillingsNummerLabel.Text = "Dit bestillingsnummer er: " + pizzaCounter.GetCounter();
                this.bestilButton.Enabled = true;
            }
            this.forventetLabel.Text = "Forventet færdig: " + DateTime.Now.AddMinutes(4).ToString("T"); // klokkeslet
        }

        private void bestilButton_Click(object sender, EventArgs e) // Bestil knap
        {
            PendingOrder pizzaCounter = new PendingOrder();          
            System.Windows.Forms.MessageBox
                .Show(pizzaCounter.GetOrder() + "\nDit Bestillingsnummer er " + pizzaCounter.GetCounter());
            pizzaCounter.IncrementCounter();
            Clear(this);
            this.bestilButton.Enabled = false;
        }
     
        private void cancelButton_Click(object sender, EventArgs e) => Clear(this);

        void Clear(Control ctrl) // clear controls
        {
            ctrl.Controls.OfType<CheckBox>().ToList().ForEach(c => c.Checked = false);
        
            if (ctrl is TextBox) ctrl.Text = "";
            if (ctrl is Label) ctrl.Text = ctrl.Text.Split(':')[0];
            foreach (Control childCtrl in ctrl.Controls) Clear(childCtrl);
        }
    }
    public class OrderLine 
    {      
        public string id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public int price { get; set; }
        public int antal { get; set; }
        public List<AddedLine> added = new List<AddedLine>();

    }
    public class AddedLine
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public AddedLine(string n, int p)
        {
            Name = n;
            Price = p;
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
}
      
    

