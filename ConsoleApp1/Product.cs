using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<int> Phases = new List<int>();
        private static PhasesOfProducts phasesOfProducts = new PhasesOfProducts();

        public Product() { }
        public Product(string name, decimal price)
        {
            Id = IdGenerator.GlobalId;
            this.Name = name;
            this.Price = price;
        }
        public void AddPhase(int index)
        {
            string phaseName = "";
            phaseName = phasesOfProducts.GetPhaseName(index);
            if (phaseName != null)
            {
                Phases.Add(index);
                Console.WriteLine("Phase is successfully added.");
            }
            else
            {
                Console.WriteLine("This index is invalid.");
            }
        }
        public string GetPhaseName(int index)
        {
            string phaseName = "";
            PhasesOfProducts phasesOfProducts = new PhasesOfProducts();
            phaseName = phasesOfProducts.GetPhaseName(index);
            return phaseName;
        }
        public void RemovePhase(int index)
        {
            try
            {
                Phases.Remove(index);
                Console.WriteLine("successfully removed.");
            }
            catch (Exception)
            {
                Console.WriteLine("not removed.");
            }
        }
        public override string ToString()
        {
            return $"Product Id is: {Id} Product name is : {Name} Price is {Price}";
        }

    }
}
