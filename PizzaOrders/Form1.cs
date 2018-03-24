using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        private void pizzaCheckBoxGlobal_CheckedChanged(object sender, EventArgs e) 
        {
            var send = ((CheckBox)sender);
            send.Parent.Controls.OfType<TextBox>()
                .FirstOrDefault(t => t.Tag.ToString()== send.Tag.ToString()).Enabled = send.Checked;
        }

        private int ValidateTBox (string tBoxText) => int.TryParse(tBoxText, out int parsed) ? parsed : 0;     
    
        void GetPizza(Panel panel, ref List<OrderLine> order)
        {
            GroupBox panelGrpBox1 = panel.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString() == panel.Tag + "GroupBox1").FirstOrDefault();
            GroupBox panelGrpBox2 = panel.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString() == panel.Tag + "GroupBox2").FirstOrDefault();
            foreach (TextBox tBox in panelGrpBox1.Controls.OfType<TextBox>())
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
                orderline.name = panelGrpBox1.Text;
                orderline.size = tBox.Tag.ToString().StartsWith("fam") ? "family" : "almindelig";
                orderline.antal = antalValidated;
                orderline.price = Constants.Get(panel.Tag.ToString());

                // add added from groupbox 2
                panelGrpBox2.Controls.OfType<CheckBox>().Where(c => c.Checked).ToList()
                    .ForEach(c => orderline.added.Add( new AddedLine(c.Text, Constants.Get(c.Tag.ToString()))));

                if (tBox.Enabled && orderline.antal > 0) order.Add(orderline);
            }
        }
        public int GetKcal (string ToValidate)
        {
            return (int.TryParse(ToValidate, out int value) && value > 1 && value < 11) ? value : 0;
        }
        public string SetKcal(int ToValidate, string tBoxName)
        {
            if (ToValidate != 0)
            {
              decimal i = Constants.Get(tBoxName);         
              return (i / ToValidate).ToString("##.#") + "KCal\n" +
                    " Kalorier (family): " + ((i / ToValidate) * 1.5M).ToString("##.#") + "KCal";
            }
            return "";
        }
        private void BeregnButton1_Click(object sender, EventArgs e)        // beregn knap
        {

            List<OrderLine> order = new List<OrderLine>();
            var panels = this.Controls.OfType<Panel>();
           
            foreach (Panel panel in panels)
            {
                GetPizza(panel, ref order); // get Pizza

                GroupBox grpBox3 = panel.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString() == panel.Tag + "GroupBox3").FirstOrDefault();
                TextBox tBox = grpBox3.Controls.OfType<TextBox>().FirstOrDefault();


                grpBox3.Controls.OfType<Label>().FirstOrDefault().Text =   // Get/Set Kcal
                    "Skær i 2-10 skiver: \n Kalorier pr skive = " + SetKcal( GetKcal(tBox.Text), tBox.Tag.ToString() );
            }

            PizzaOrder pizzaOrder = new PizzaOrder(order);  // New pizza order

            foreach (Panel panel in panels) // add to subtotal
            {
                panel.Controls.OfType<Label>().Where(x => x.Tag.ToString() == panel.Tag + "SubTotal").FirstOrDefault()
                    .Text = "SubTotal: " + pizzaOrder.GetSubtotal(panel.Tag.ToString()); // Sub total
            }

            this.totalLabel.Text = "Total: " + pizzaOrder.Total.ToString();  // Total

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
        public string Name { get; set; }
        public int Price { get; set; }
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
      
    

