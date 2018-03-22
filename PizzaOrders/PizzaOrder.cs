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
            orderLines.Add(arr);
            foreach (ArrayList orderline in arr)
            {
                //  Console.WriteLine("[{0}]", string.Join(", ", orderline.ToArray()));

                //    string added = (string)orderline[3] + (string)orderline[4] + (string)orderline[5];
                //   var props = typeof(Constants).GetField((string)orderline[3]).GetValue(null);
                

                CollectPizzas(
                    (string)orderline[0], 
                    (string)orderline[1], 
                    (string)orderline[2], 
                    (int)orderline[3], 
                    CollectAdded((ArrayList)orderline[4])
                );

                CalculatePizzas(
                    (string)orderline[0], 
                    (string)orderline[1], 
                    (string)orderline[2], 
                    (int)orderline[3], 
                    CalculateAdded((ArrayList)orderline[4], (string)orderline[2])
                );
            }
        }
        public Dictionary<string, int> PizzaList = new Dictionary<string, int>();
        public Dictionary<string, decimal> PizzaSum = new Dictionary<string, decimal>();
        private ArrayList orderLines = new ArrayList();
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
        public decimal CalculateAdded(ArrayList arr, string size)
        {
            decimal sizeModifier = (size == "family") ? 1.5M : 1;
            List<decimal> list = new List<decimal>();
            foreach (string added in arr)
            {

                string[] tokens = added.Split('-');
                decimal addPrice = PriceCatalog.GetValue(tokens[0]) * sizeModifier;

                list.Add(addPrice);
            }
            Console.WriteLine(list.Sum());
            return list.Sum();
        }
        public void CalculatePizzas(string id, string navn, string size, int antal, decimal added)
        {
            int idPrice = PriceCatalog.GetValue(id);
            decimal sizeModifier = (size == "family") ? 1.5M : 1;
            string key = id;
            decimal subtotal = (idPrice * antal * sizeModifier) + (added * antal);
            if (PizzaSum.ContainsKey(key))
            {
                PizzaSum[key] += subtotal;
              //  total += subtotal;
            }
            else
            {
                PizzaSum.Add(key, subtotal);
            }
            total += subtotal;
            // TODO : correct me!

            // PizzaSum.ToList().ForEach(Console.WriteLine);          
        }
        public void CollectPizzas(string id, string navn, string size, int antal, string added)
        {
            string key = navn + " " + size + " " + added;
            //if (PizzaList.ContainsKey(key)) // TODO : is needed?
            //{
            //    PizzaList[key] =  antal;
            //} else
            //{
            PizzaList.Add(key, antal);
            // }                 
        }
        public string DisplayPizzaOrder() // TODO : Improve!
        {
            string s = "";
            foreach (KeyValuePair<string, int> kvp in PizzaList)
            {

                s += kvp.Key + " antal: " + kvp.Value + "\n";
            }

            return s;
        }
        public string DisplayPizzaSubTotal(string s)
        {
            return (PizzaSum.ContainsKey(s)) ? PizzaSum[s].ToString() : "";
        }
    }
}
