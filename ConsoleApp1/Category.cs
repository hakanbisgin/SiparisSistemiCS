using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Category
    {
        public string Name { get; set; }
        private List<Product> products = new List<Product>();

        public Category()
        {

        }
        public Category(string name)
        {
            Name = name;
        }
        public void AddProduct(string name, decimal price)
        {
            Product product = new Product(name, price);
            products.Add(product);
            
            Console.WriteLine("Urun başarı ile eklendi.");
            Console.WriteLine(product.ToString());
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public Product GetProduct(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }

            }
            return null;

        }
        public void RemoveProduct(int id)
        {
            Product product;
            product = GetProduct(id);
            products.Remove(product);
        }
        public void ListAllProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        public override string ToString()
        {
            string result = "Category name is: " + Name + " \n\n";
            foreach (var product in products)
            {
                result += product.ToString();
            }
            result += "end of category.";
            return result;
        }
    }
}
