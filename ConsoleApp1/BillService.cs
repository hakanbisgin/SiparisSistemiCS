using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BillService
    {
        private List<Bill> Bills = new List<Bill>();

        public BillService() { }
        public void ListUnpaidBills()
        {
            string result = "";
            foreach (var bill in Bills)
            {
                if ((bill.PaidDate).ToString() == "1.1.0001 00:00:00")
                {
                    result += bill.ToString();
                }
            }
            Console.WriteLine(result);
        }
        public Bill CreateBill()
        {
            Bill createdBill = new Bill();
            return createdBill;
        }


    }
}
