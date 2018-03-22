using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrders
{
    static class PriceCatalog
    {
        static private Dictionary<string, int> dict = new Dictionary<string, int>
        {
            { Constants.P1_NAME, Constants.P1_TAG }, // pizza1
            { Constants.P2_NAME, Constants.P2_TAG },  // pizza2

            { Constants.P1_CHK1_NAME, Constants.P1_CHK1_TAG }, // pizza 1 checkbox 1 -3
            { Constants.P1_CHK2_NAME, Constants.P1_CHK2_TAG },
            { Constants.P1_CHK3_NAME, Constants.P1_CHK3_TAG },

            { Constants.P2_CHK1_NAME, Constants.P2_CHK1_TAG }, // pizza 2 checkbox 1 -3
            { Constants.P2_CHK2_NAME, Constants.P2_CHK2_TAG },
            { Constants.P2_CHK3_NAME, Constants.P2_CHK3_TAG },

            { Constants.P1_KCAL_NAME, Constants.P1_KCAL_TAG }, // pizza 1 kalorier

            { Constants.P2_KCAL_NAME, Constants.P2_KCAL_TAG }  // pizza 2 kalorier

        };
        public static int GetValue(string s)
        {
            return dict[s];
        }
    }
}
