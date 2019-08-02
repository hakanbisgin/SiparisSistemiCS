using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Ledger
    {
        private List<Bill> paidBills = new List<Bill>();

        public void PayBill(Bill bill)
        {
            if ((bill.PaidDate).ToString() != "1.1.0001 00:00:00")
            {
                Console.WriteLine($"The Bill has paid before. {bill.PaidDate}");
                return;
            }
            bill.PaidDate = DateTime.Now;

            try
            {
                paidBills.Add(bill);

            }
            catch (Exception)
            {
                Console.WriteLine($"failed to pay the bill \n {bill.ToString()}");
                return;
            }
        }

        public void ListAllPaidBills()
        {
            string result = "List of ALL paid bills. \n";
            foreach (var paidBill in paidBills)
            {
                result += "\n" + paidBill.ToString() + "\n";
            }
            result += "End of paid bills' list";
            Console.WriteLine(result);
            return;

        }
    }
}
