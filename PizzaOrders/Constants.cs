namespace PizzaOrders
{
    public static class Constants
    {

        public const int PIZZA1 = 64;
        public const int PIZZA1AddCheckBox1 = 5;
        public const int PIZZA1AddCheckBox2 = 10; 
        public const int PIZZA1AddCheckBox3 = 7;
        public const int P1_KCAL = 231;


        public const int PIZZA2 = 59;
        public const int PIZZA2AddCheckBox1 = 8;
        public const int PIZZA2AddCheckBox2 = 11;
        public const int PIZZA2AddCheckBox3 = 6;
        public const int P2_KCAL = 253;
 
        public static int Get(string name) => (int)typeof(Constants).GetField(name).GetValue(null);
   
    }
}
