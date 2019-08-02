using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Bill
    {
        private List<OrderLineItem> orderLineItems = new List<OrderLineItem>();
        public DateTime PaidDate { get; set; }

        public Bill()
        {

        }
        public void AddOrderLineItem(Product product, int amount)
        {
            OrderLineItem orderLineItem = new OrderLineItem(product, amount);
            orderLineItems.Add(orderLineItem);
        }
        public override string ToString()
        {
            string result = "";
            foreach (var orderLineItem in orderLineItems)
            {
                result += orderLineItem.ToString() + "\n";
            }
            result += "Total: " + CalculateBill();
            return result;
        }
        public decimal CalculateBill()
        {
            decimal result = 0;
            foreach (var orderLineItem in orderLineItems)
            {
                result += orderLineItem.CalculatePrice();
            }
            return result;
        }
        public void NextPhase(int orderLineItemId)
        {
            foreach (var orderLineItem in orderLineItems)
            {
                if (orderLineItem.Id == orderLineItemId)
                {
                    orderLineItem.NextPhase();
                    Console.WriteLine("Successfully updated.");
                    return;
                }
            }
            Console.WriteLine("Cannot find ");
        }
        public void ListReadyServeOrders()
        {
            foreach (var orderLineItem in orderLineItems)
            {
                if (orderLineItem.GetProductPhaseIndex() == 0)
                {
                    Console.WriteLine(orderLineItem.ToString());
                }
            }
        }
    }
}
