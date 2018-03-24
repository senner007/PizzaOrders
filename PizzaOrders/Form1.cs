﻿using System;
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
        }
      
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void pizzaCheckBoxGlobal_CheckedChanged(object sender, EventArgs e) 
        {
            var send = ((CheckBox)sender);
            send.Parent.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.StartsWith(send.Name.Substring(0, 3))).Enabled = send.Checked;
        }

        private int ValidateTBox (string tBoxText)
        {
            return int.TryParse(tBoxText, out int parsed) ? parsed : 0;     
        }

        public static T FindGrp<T>(Control ctrl, string name)
        {
            return (T)(object)ctrl.Controls.OfType<Control>().FirstOrDefault(l => l.Name.EndsWith(name));
        }
        private void BeregnButton1_Click(object sender, EventArgs e)
        {

            List<OrderLine> order = new List<OrderLine>();
            var panels = this.Controls.OfType<Panel>();


            foreach (Panel panel in panels)
            {
                
                GroupBox panelGrpBox1 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox1");
                GroupBox panelGrpBox2 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox2");
                GroupBox panelGrpBox3 = FindGrp<GroupBox>(panel, panel.Name + "GroupBox3");

                foreach (TextBox tBox in panelGrpBox1.Controls.OfType<TextBox>())
                {
                    OrderLine orderline = new OrderLine();

                    int antalValidated = ValidateTBox(tBox.Text);
                    if (tBox.Enabled && antalValidated < 1)
                    {               
                        System.Windows.Forms.MessageBox.Show("Indtast 1 eller flere antal pizzaer eller fravælg pågældende pizza");
                        return;
                    }
                    orderline.id = (string)panel.Name;
                    orderline.name = panelGrpBox1.Text;
                    orderline.size = tBox.Name.StartsWith("family") ? "family" : "almindelig";
                    orderline.antal = antalValidated;

                    panelGrpBox2.Controls.OfType<CheckBox>().Where(x=> x.Checked).ToList().ForEach(x => orderline.added.Add(x.Name + "-" + x.Text));

                     if (tBox.Enabled && orderline.antal > 0) order.Add(orderline);
                }

                TextBox tBoxGrp3 = panelGrpBox3.Controls.OfType<TextBox>().FirstOrDefault();
                Label labelGrp3 = panelGrpBox3.Controls.OfType<Label>().FirstOrDefault();

                    if (int.TryParse(tBoxGrp3.Text, out int value) && value > 1 && value  < 11)
                    {
                        decimal i = GetFieldValue.Get(tBoxGrp3.Name);            
                        if (value != 0)
                              labelGrp3.Text = Constants.KCAL_SLICE_TEXT + (i / value).ToString("##.#") + "KCal\n" +
                                " Kalorier (family): " + ((i / value) * 1.5M).ToString("##.#") + "KCal";
               
                    }
                    else if (tBoxGrp3.Text != "")
                    {
                        System.Windows.Forms.MessageBox.Show("Indtast 2 til 10 antal skiver");
                        return;
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
                    Console.WriteLine(chkBox.Name);
                    chkBox.Checked = false;
                }
              
            }
            if (ctrl is TextBox) ctrl.Text = "";
            if (ctrl is Label && ctrl.Name.EndsWith("SubTotal")) ctrl.Text = "Sub Total:";
            if (ctrl is Label && ctrl.Name.EndsWith("totalLabel")) ctrl.Text = "Total: ";
            if (ctrl is Label && ctrl.Name.EndsWith("bestillingsNummerLabel")) ctrl.Text = "Dit bestillingsnummer er: ";
            if (ctrl is Label && ctrl.Text.StartsWith(Constants.KCAL_SLICE_TEXT)) ctrl.Text = Constants.KCAL_SLICE_TEXT;
            if (ctrl is Label && ctrl.Name.EndsWith("forventetLabel")) ctrl.Text = "Forventet færdig: ";

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
        public static int Get (string name)
        {
            var prop = typeof(Constants).GetField(name).GetValue(null);
            return (int)prop;
        } 
    }
   
    


}
      
    

