using System;
using System.Collections.Generic;
using System.Linq;

using System.Collections;

namespace PizzaOrders
{
    class PizzaOrder
    {
        public PizzaOrder(ArrayList arr)
        {
            orderLines = arr;
            ProcessOrder();
        }
        public void ProcessOrder () 
        {
            decimal total = 0;
            
            foreach (ArrayList ol in orderLines)
            {

                decimal sizeModifier = ((string)ol[2] == "family") ? 1.5M : 1;
                decimal pizzaPrice = GetFieldValue.Get((string)ol[0]);
                int antal = (int)ol[3];
                decimal pizzaSum = pizzaPrice * antal * sizeModifier;
                string addedNames = "";
                decimal addedSum = 0;

                foreach (string added in (ArrayList)ol[4])
                {
                    string[] _tokens = added.Split('-');
                    addedNames += " " + _tokens[1];
                    addedSum += GetFieldValue.Get(_tokens[0]) * sizeModifier * antal;                                
                }
                total += pizzaSum + addedSum;

                string key = (string)ol[0];

                if (!Subtotal.ContainsKey(key))
                {
                    Subtotal.Add(key, pizzaSum + addedSum);
                } else
                {
                    Subtotal[key] += pizzaSum + addedSum;
                }

                string keyLine = ol[0] + " " + ol[1] + ol[2] + addedNames;

                OrderLineSum.Add(keyLine, pizzaSum + addedSum);
                PizzaList.Add(keyLine, antal);                

            }

            Total = total;
        }
        public Dictionary<string, int> PizzaList = new Dictionary<string, int>();
        public Dictionary<string, decimal> OrderLineSum = new Dictionary<string, decimal>();
        public Dictionary<string, decimal> Subtotal = new Dictionary<string, decimal>();

        private ArrayList orderLines = new ArrayList();
        public decimal Total { get; private set; } = 0;
        public decimal GetSubtotal(string id)
        {
            return Subtotal.ContainsKey(id) ? Subtotal[id] : 0;
        }
        public string GetInfo ()
        {
           return string.Join("", PizzaList.Select(x => x.Key + " antal:" + x.Value + " beløb " + OrderLineSum[x.Key] + "\n").ToArray()) 
                     + "\nDet total beløb er " + Total;
        }
    }
}


