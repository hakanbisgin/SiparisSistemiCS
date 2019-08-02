using System;

namespace ConsoleApp1
{
    class OrderLineItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        private int productPhaseIndex;
        public OrderLineItem() { }
        public OrderLineItem(Product product, int amount)
        {
            Product = product;
            Amount = amount;
            productPhaseIndex = 1;
            Id = IdGenerator.OrderLineItemId;
        }
        public decimal CalculatePrice()
        {
            return Product.Price * Amount;
        }
        public string GetPhaseName()
        {
            try
            {
                string result = Product.GetPhaseName(Product.Phases[productPhaseIndex]);
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Phase info is not available.");
                return "";
            }
        }
        public int GetProductPhaseIndex(){
            return productPhaseIndex;
        }
        public void NextPhase()
        {
            try
            {
                if (productPhaseIndex < (Product.Phases.Count - 1) && productPhaseIndex != 0)
                {
                    productPhaseIndex++;
                }
                else
                {
                    productPhaseIndex = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to update Phase info");
            }
        }
        public override string ToString()
        {
            string result = Id + Product.ToString() + " ";
            for (int i = 0; i < Amount; i++)
            {
                result += "X";
            }
            result += "\t last stmt : " + GetPhaseName();
            result += "  Price : " + CalculatePrice();
            
            return result;
        }

    }
}
