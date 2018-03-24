using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrders
{
    class PizzaOrder
    {
        public PizzaOrder(List<OrderLine> order)
        {
            Order = order;
            ProcessOrder(order);
        }
        private void ProcessOrder (List<OrderLine> order) // TODO : more functions
        {
            decimal total = 0;
            
            foreach (OrderLine ol in order)
            {
                decimal sizeModifier = (ol.size == "family") ? 1.5M : 1;
                int antal = ol.antal;
                decimal pizzaSum = ol.price * antal * sizeModifier;
                decimal addedSum = ol.added.Select(x => x.Price * sizeModifier * antal).Sum();
               

                total += pizzaSum + addedSum;
                string key = ol.id;

                if (!Subtotal.ContainsKey(key))
                    Subtotal.Add(key, pizzaSum + addedSum);
                else
                    Subtotal[key] += pizzaSum + addedSum;

                string keyLine = ol.id + " " + ol.name + ol.size + String.Join(" ", ol.added.Select(x => x.Name));

                OrderLineSum.Add(keyLine, pizzaSum + addedSum);
                PizzaList.Add(keyLine, antal);                
            }

            Total = total;
        }
        private Dictionary<string, int> PizzaList = new Dictionary<string, int>();
        private Dictionary<string, decimal> OrderLineSum = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> Subtotal = new Dictionary<string, decimal>();
        private List<OrderLine> Order = new List<OrderLine>();
        public decimal Total { get; private set; } = 0;
        public decimal GetSubtotal(string id) => Subtotal.ContainsKey(id) ? Subtotal[id] : 0;
        public string GetInfo () => string.Join("", PizzaList
            .Select(x => x.Key + " antal:" + x.Value + " beløb " + OrderLineSum[x.Key] + "\n").ToArray()) 
                     + "\nDet total beløb er " + Total;     
    }
}


