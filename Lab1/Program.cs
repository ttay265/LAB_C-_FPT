using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 86;
            Menu Menu = new Menu("Product Management");
            Menu.ClearPreviousTask = true;
            ProductManager Manage = new ProductManager();
            // Add menu item
            Menu.AddLine("1. Add New Product.");
            Menu.AddLine("2. Update product by code.");
            Menu.AddLine("3. Delete product by code.");
            Menu.AddLine("4. Search product by Name.");
            Menu.AddLine("5. Search product by price range.");
            Menu.AddLine("6. Find products belong to a given Manufacturer.");
            Menu.AddLine("7. Display all products.");
            Menu.AddLine("8. Exit.");
            while (!Menu.ExitOption)
            {
                switch (Menu.select())
                {
                    case 1: //Add a new Product
                        {
                            Product NewProduct = new Product();   // Create a Product then add
                            NewProduct.Input();                 //
                            if (Manage.AddNewProduct(NewProduct))
                            {
                                Menu.LastTaskMessage = "Product " + NewProduct.ProductCode + " Added!"; // Response to Add successfully
                            }
                            else
                            {
                                Menu.LastTaskMessage = "Product " + NewProduct.ProductCode + " Existed!"; // Response to Add failed

                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2: // Update Product by Code
                        {
                            Console.Clear();
                            (new Product()).Display();
                            Console.Write("Enter Product Code to update: ");
                            string UpdateCode = Console.ReadLine();
                            if (Manage.UpdateByCode(UpdateCode))
                            {
                                Menu.LastTaskMessage = "Product " + UpdateCode + " Updated Successfully!";
                            }
                            else
                            {
                                Menu.LastTaskMessage = "Updated Failed or Product not Found!";
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.Write("Enter Product Code to delete: ");
                            string DeleteCode = Console.ReadLine();
                            if (Manage.DeleteByCode(DeleteCode))
                            {
                                Menu.LastTaskMessage = "Product " + DeleteCode + " Deleted Successfully!";
                            }
                            else
                            {
                                Menu.LastTaskMessage = "Delete Failed or Product not Found!";
                            }
                            break;
                        }
                    case 4:
                        {
                            string ErrorMessage = "";
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine(ErrorMessage);
                                Console.Write("Enter Product Name to search: ");
                                string SearchValue = Console.ReadLine();
                                if (SearchValue.Count() > 0)
                                {
                                    ProductManager Result = Manage.Search(SearchValue, ProductManager.SEARCH_BY_NAME);
                                    if (Result != null)
                                    {
                                        Menu.LastTaskMessage = "Search results for " + SearchValue + ":\n" + Result.Display();
                                        Console.WriteLine(Menu.LastTaskMessage);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Menu.LastTaskMessage = "No results found!";
                                    }
                                    break;
                                }
                                else
                                {
                                    ErrorMessage = "Product Name must have at least 1 character(s)! Try Again!";
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            string ErrorMessage = "";
                            while (true)
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine(ErrorMessage);
                                    Console.Write("Enter Min Price to search: ");
                                    string MinValueString = Console.ReadLine();
                                    double MinValue = double.Parse(MinValueString);
                                    Console.Write("Enter MAX Price to search: ");
                                    string MaxValueString = Console.ReadLine();
                                    double MaxValue = double.Parse(MaxValueString);
                                    ProductManager Result
                                        = Manage.Search(new double[] { MinValue, MaxValue }, ProductManager.SEARCH_BY_PRICERANGE);
                                    if (Result != null)
                                    {
                                        Menu.LastTaskMessage = "Search results for Price Range " + MinValue + " - " + MaxValue + ":\n" + Result.Display();
                                        Console.WriteLine(Menu.LastTaskMessage);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Menu.LastTaskMessage = "No results found!";
                                    }
                                    break;
                                }
                                catch
                                {
                                    ErrorMessage = "Invalid Price!";
                                }
                            }
                            break;
                        }
                    case 6:
                        {
                            string ErrorMessage = "";
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine(ErrorMessage);
                                Console.Write("Enter Product Manufacturer to search (At least 3 characters): ");
                                string SearchValue = Console.ReadLine();
                                if (SearchValue.Count() > 3)
                                {
                                    ProductManager Result = Manage.Search(SearchValue, ProductManager.SEARCH_BY_MANUFACTURER);
                                    if (Result != null)
                                    {
                                        Menu.LastTaskMessage = "Search results for " + SearchValue + ":\n" + Result.Display();
                                        Console.WriteLine(Menu.LastTaskMessage);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Menu.LastTaskMessage = "No results found!";
                                    }
                                    break;
                                }
                                else
                                {
                                    ErrorMessage = "Product Manufacturer must have at least 3 characters! Try Again!";
                                }
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine(Manage.Display());
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            Menu.LastTaskMessage = "";
                            break;
                        }
                    case 8:
                        {
                            Menu.ExitOption = true;
                            break;
                        }
                }
            }
        }
    }
}
