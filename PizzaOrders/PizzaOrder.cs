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
            //foreach (ArrayList orderline in arr)
            //{
                //  Console.WriteLine("[{0}]", string.Join(", ", orderline.ToArray()));

                //    string added = (string)orderline[3] + (string)orderline[4] + (string)orderline[5];
                //   var props = typeof(Constants).GetField((string)orderline[3]).GetValue(null);
                

                //CollectPizzas(
                //    (string)orderline[0], 
                //    (string)orderline[1], 
                //    (string)orderline[2], 
                //    (int)orderline[3], 
                //    CollectAdded((ArrayList)orderline[4])
                //);

                //CalculatePizzas(
                //    (string)orderline[0], 
                //    (string)orderline[1], 
                //    (string)orderline[2], 
                //    (int)orderline[3], 
                //    CalculateAdded((ArrayList)orderline[4], (string)orderline[2])
                //);
            //}
        }
        public void ProcessOrder () 
        {
            decimal total = 0;
            
            foreach (ArrayList ol in orderLines)
            {

                //    Console.WriteLine("[{0}]", string.Join(", ", ol.ToArray()));
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
            //foreach (KeyValuePair<string, int> kvp in PizzaList)
            //{

            //    Console.WriteLine(kvp.Key + " antal: " + kvp.Value + "\n");
            //};

            //foreach (KeyValuePair<string, decimal> kvp in OrderLineSum)
            //{

            //    Console.WriteLine(kvp.Key + " sum: " + kvp.Value + "\n");
            //}

            //foreach (KeyValuePair<string, decimal> kvp in Subtotal)
            //{

            //    Console.WriteLine(kvp.Key + " subtotalsum: " + kvp.Value + "\n");
            //}

            Total = total;
        }
        public Dictionary<string, int> PizzaList = new Dictionary<string, int>();
        public Dictionary<string, decimal> OrderLineSum = new Dictionary<string, decimal>();
        public Dictionary<string, decimal> Subtotal = new Dictionary<string, decimal>();

        private ArrayList orderLines = new ArrayList();
        public decimal Total { get; private set; } = 0;
        public decimal GetSubtotal(string id)
        {
            if (Subtotal.ContainsKey(id))
            {
                return Subtotal[id];
            }
            return 0;
        }
        public string GetInfo ()
        {
            string order = "";
            foreach (KeyValuePair<string, int> kvp in PizzaList)
            {
                order += kvp.Key + " antal: " + kvp.Value + " beløb " + OrderLineSum[kvp.Key] + "\n";

            }
            order += "Det total beløb er " + Total;
            return order;
        }

        //public string CollectAdded(ArrayList arr)
        //{
        //    string s = "";
        //    foreach (string added in arr)
        //    {
        //        string[] tokens = added.Split('-');
        //        s += tokens[1] + " ";
        //    }

        //    return s.Trim();
        //}
        //public decimal CalculateAdded(ArrayList arr, string size)
        //{
        //    decimal sizeModifier = (size == "family") ? 1.5M : 1;
        //    List<decimal> list = new List<decimal>();
        //    foreach (string added in arr)
        //    {
        //       // Console.WriteLine(added);
        //        string[] tokens = added.Split('-');
        //      //  Console.WriteLine(tokens[0]);
        //        decimal addPrice = GetFieldValue.Get(tokens[0]) * sizeModifier;
        //       // decimal addPrice = PriceCatalog.GetValue(tokens[0]) * sizeModifier;

        //        list.Add(addPrice);
        //    }
        //    Console.WriteLine(list.Sum());
        //    return list.Sum();
        //}
        //public void CalculatePizzas(string id, string navn, string size, int antal, decimal added)
        //{
        //    Console.WriteLine(id);
        //  //  int idPrice = PriceCatalog.GetValue(id);
        //    int idPrice = GetFieldValue.Get(id);

        //    decimal sizeModifier = (size == "family") ? 1.5M : 1;
        //    string key = id;
        //    decimal subtotal = (idPrice * antal * sizeModifier) + (added * antal);
        //    if (PizzaSum.ContainsKey(key)) // TODO : make unnessecasry
        //    {
        //        PizzaSum[key] += subtotal;
        //      //  total += subtotal;
        //    }
        //    else
        //    {
        //        PizzaSum.Add(key, subtotal);
        //    }
        //    total += subtotal;
        //    // TODO : correct me!

        //    // PizzaSum.ToList().ForEach(Console.WriteLine);          
        //}
        //public void CollectPizzas(string id, string navn, string size, int antal, string added)
        //{
        //    string key = navn + " " + size + " " + added;
        //    //if (PizzaList.ContainsKey(key)) // TODO : is needed?
        //    //{
        //    //    PizzaList[key] =  antal;
        //    //} else
        //    //{
        //    PizzaList.Add(key, antal);
        //    // }                 
        //}
        //public string DisplayPizzaOrder() // TODO : Improve!
        //{
        //    string s = "";
        //    foreach (KeyValuePair<string, int> kvp in PizzaList)
        //    {

        //        s += kvp.Key + " antal: " + kvp.Value + "\n";
        //    }

        //    return s;
        //}
        //public string DisplayPizzaSubTotal(string s)
        //{
        //    return (PizzaSum.ContainsKey(s)) ? PizzaSum[s].ToString() : "";
        //}
    }
}
