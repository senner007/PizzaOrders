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
                .FirstOrDefault(t => t.Name.StartsWith(send.Name.Substring(0, 3))).Enabled = send.Checked;
        }

        private int ValidateTBox (string tBoxText) => int.TryParse(tBoxText, out int parsed) ? parsed : 0;     
    
        public static T FindGrp<T>(Control ctrl, string name) => (T)(object)ctrl.Controls.OfType<Control>().FirstOrDefault(l => l.Name.EndsWith(name));

        void GetPizza(Panel panel, ref List<OrderLine> order)
        {
            GroupBox panelGrpBox1 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox1");
            GroupBox panelGrpBox2 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox2");
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
                orderline.id = panel.Name;
                orderline.name = panelGrpBox1.Text;
                orderline.size = tBox.Name.StartsWith("family") ? "family" : "almindelig";
                orderline.antal = antalValidated;

                // add added from groupbox 2
                panelGrpBox2.Controls.OfType<CheckBox>().Where(c => c.Checked).ToList()
                    .ForEach(c => orderline.added.Add(c.Name + "-" + c.Text));

                if (tBox.Enabled && orderline.antal > 0) order.Add(orderline);
            }
        }
        //void GetSetKcal(Panel panel)
        //{
        //    GroupBox panelGrpBox3 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox3");

        //    TextBox tBoxGrp3 = panelGrpBox3.Controls.OfType<TextBox>().FirstOrDefault();
        //    Label labelGrp3 = panelGrpBox3.Controls.OfType<Label>().FirstOrDefault();

        //    if (int.TryParse(tBoxGrp3.Text, out int value) && value > 1 && value < 11) 
        //        // validate textbox in groupbox 3
        //    {
        //        decimal i = GetFieldValue.Get(tBoxGrp3.Name);            // write to KCAL label
        //        if (value != 0)
        //            labelGrp3.Text = Constants.KCAL_SLICE_TEXT + (i / value).ToString("##.#") + "KCal\n" +
        //            " Kalorier (family): " + ((i / value) * 1.5M).ToString("##.#") + "KCal";

        //    }
        //    else if (tBoxGrp3.Text != "")
        //    {
        //        System.Windows.Forms.MessageBox.Show("Indtast 2 til 10 antal skiver");
        //        return;
        //    }
        //}
        public int GetKcal (string ToValidate)
        {
            return (int.TryParse(ToValidate, out int value) && value > 1 && value < 11) ? value : 0;
        }
        public string SetKcal(int ToValidate, string tBoxName)
        {
            if (ToValidate != 0)
            {
              decimal i = GetFieldValue.Get(tBoxName);         
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
                GetPizza(panel, ref order);

                GroupBox grpBox3 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox3");
                TextBox tBox = grpBox3.Controls.OfType<TextBox>().FirstOrDefault();

                grpBox3.Controls.OfType<Label>().FirstOrDefault().Text =
                    "Skær i 2-10 skiver: \n Kalorier pr skive = " + SetKcal( GetKcal(tBox.Text), tBox.Name );

            }

            PizzaOrder pizzaOrder = new PizzaOrder(order);  // New pizza order

            foreach (Panel panel in panels) // add to subtotal
            {
                panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.EndsWith("SubTotal"))
                    .Text = "SubTotal: " + pizzaOrder.GetSubtotal(panel.Name); // Sub total
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
        public int antal { get; set; }
        public List<string> added = new List<string>();

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
        public static int Get (string name) => (int)typeof(Constants).GetField(name).GetValue(null);
    }
}
      
    

