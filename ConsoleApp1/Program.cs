using System;

namespace ConsoleApp1
{
    class Program
    {
        private const string listOfAllChoices = @"
----
1- Create Product
2- Update Price of a Product
3- List All Products
4- Order
5- Show Bill
6- Pay Bill
7- List All Paid Bills
8- List All Phase
9- Add Phase
10-Update Phase
11-Define Phase for Product
12-Remove Product's Phase
13-Show Unpaid Bills
14-Update Next Phase for Order Lineitem
15-List Ready to Serve Orders
16-Show sum. of categories
17-Change Category of product
0- Exit
----
";

        static void Main(string[] args)
        {
            bool isContinue = true;
            BillService billService = new BillService();
            Bill bill = billService.CreateBill();
            Ledger ledger = new Ledger();
            string name;
            decimal price;
            int productId;
            Product product;
            int amount;
            PhasesOfProducts phasesOfProducts = new PhasesOfProducts();
            int index;
            string phase;
            int orderLineItemIndex;
            string categoryName;
            ProductService productService = new ProductService();

            string manual = listOfAllChoices;

            while (isContinue)
            {
                int choice;

                Console.WriteLine(manual);

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //Create Product
                        Console.WriteLine("Enter product name: ");
                        name = Console.ReadLine();

                        if (name == null)
                        {
                            Console.WriteLine("Invalid name.");
                            break;
                        }

                        Console.WriteLine("Enter product price");
                        try
                        {
                            price = Convert.ToDecimal(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Price.");
                            break;
                        }
                        Console.WriteLine("Enter Category Name: ");
                        categoryName = Console.ReadLine();
                        productService.AddProduct(name, price, categoryName);
                        break;

                    case 2:
                        //update Price of Product
                        Console.WriteLine("Enter product Id:");
                        productId = Convert.ToInt32(Console.ReadLine());
                        product = productService.GetProduct(productId);

                        Console.WriteLine("Enter price:");
                        try
                        {
                            price = Convert.ToDecimal(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Price.");
                            break;
                        }
                        product.Price = price;
                        break;

                    case 3:
                        //List All Products
                        productService.ListAllProducts();
                        break;

                    case 4:
                        //Order
                        do
                        {
                            Console.WriteLine("Enter product Id: ");
                            productId = Convert.ToInt32(Console.ReadLine());
                        } while (!(productId >= 1));

                        Console.WriteLine("Enter amount: ");
                        amount = Convert.ToInt32(Console.ReadLine());
                        if ((amount < 1))
                        {
                            break;
                        }
                        bill.AddOrderLineItem(productService.GetProduct(productId), amount);

                        break;
                    case 5:
                        //Show bill
                        Console.WriteLine(bill.ToString());
                        break;

                    case 6:
                        //Pay the bill
                        ledger.PayBill(bill);
                        break;

                    case 7:
                        //Show all paid bills
                        ledger.ListAllPaidBills();
                        break;
                    case 8:
                        //show all phases
                        phasesOfProducts.ShowAllPhases();
                        break;
                    case 9:
                        //Add Phase
                        Console.WriteLine("Enter phase name: ");
                        phase = Console.ReadLine();
                        if (phase != null)
                        {
                            phasesOfProducts.AddPhase(phase);
                            Console.WriteLine("successfully added.");
                        }
                        else
                        {
                            Console.WriteLine("The phase was not added.");
                        }
                        break;
                    case 10:
                        //Update phase
                        Console.WriteLine("Enter index: ");
                        try
                        {
                            index = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid index.");
                            break;
                        }
                        Console.WriteLine("Enter phase name: ");
                        phase = Console.ReadLine();
                        if (phase != null)
                        {
                            phasesOfProducts.UpdatePhase(index, phase);
                            Console.WriteLine("successfully updated.");
                        }
                        else
                        {
                            Console.WriteLine("The phase was not updated.");
                        }
                        break;
                    case 11:
                        //Define Phase for Product
                        Console.WriteLine("Enter index: ");
                        try
                        {
                            index = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid index.");
                            break;
                        }
                        do
                        {
                            Console.WriteLine("Enter product Id: ");
                            productId = Convert.ToInt32(Console.ReadLine());
                        } while (!(productId >= 1));
                        product = productService.GetProduct(productId);
                        product.AddPhase(index);
                        break;
                    case 12:
                        //Remove Product's Phase
                        try
                        {
                            Console.WriteLine("Enter product id: ");
                            productId = Convert.ToInt32(Console.ReadLine());

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Invalid product id.");
                            break;
                        }
                        try
                        {
                            Console.WriteLine("Enter phase index: ");
                            index = Convert.ToInt32(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid phase index.");
                            break;
                        }
                        try
                        {
                            product = productService.GetProduct(productId);
                            product.RemovePhase(index);
                            Console.WriteLine("Phase successfully removed.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Phase was not removed.");
                        }
                        break;
                    case 13:
                        billService.ListUnpaidBills();
                        break;
                    case 14:
                        //for an orderlineitem stmt update
                        Console.WriteLine(bill.ToString() + "\nEnter Order Lineitem Id: ");
                        orderLineItemIndex = Convert.ToInt32(Console.ReadLine());
                        bill.NextPhase(orderLineItemIndex);
                        break;
                    case 15:
                        //List Ready To Serve Orders
                        bill.ListReadyServeOrders();
                        break;
                    case 16:
                        //show sum. of categories
                        productService.GetCategoriesSum();
                        break;
                    case 17:
                        //Change category of products
                        try
                        {
                            Console.WriteLine("Product id? Id is: ");
                            productId = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Id Exception.");
                            break;
                        }
                        try
                        {
                            categoryName = Console.ReadLine();
                            productService.ChangeProductCategory(productId, categoryName);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Not Changed.");
                        }
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
