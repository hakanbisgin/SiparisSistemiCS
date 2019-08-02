using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class ProductService
    {
        private List<Category> categories;

        public ProductService()
        {
            categories = new List<Category>();
        }

        public Category FindOrCreateCategory(string categoryName)
        {
            foreach (var category in categories)
            {
                if (categoryName == category.Name)
                {
                    return category;
                }
            }
            return new Category(categoryName);
        }
        public void AddProduct(string name, decimal price, string categoryName)
        {
            Category category = FindOrCreateCategory(categoryName);
            categories.Add(category);

            category.AddProduct(name, price);
        }
        public Product GetProduct(int id)
        {
            foreach (var category in categories)
            {
                Product product = category.GetProduct(id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;

        }
        public void GetCategoriesSum()
        {
            string result = "";
            foreach (var category in categories)
            {
                result += category.Name + "\n";
            }
            Console.WriteLine(result);
        }
        public void ListAllProducts()
        {
            foreach (var category in categories)
            {
                category.ListAllProducts();
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (var category in categories)
            {
                result += category.ToString();
            }
            return result;
        }
        public Category GetCategory(int id)
        {
            foreach (var category in categories)
            {
                Product product = category.GetProduct(id);
                if (product != null)
                {
                    return category;
                }
            }
            return null;
        }
        internal void ChangeProductCategory(int productId, string categoryName)
        {
            Category category = GetCategory(productId);
            Product product = GetProduct(productId);
            if (category != null)
            {
                category.RemoveProduct(productId);
                category = FindOrCreateCategory(categoryName);
                category.AddProduct(product);
            }
            else
            {
                category = FindOrCreateCategory(categoryName);
                category.AddProduct(product);
            }

        }
    }
}
