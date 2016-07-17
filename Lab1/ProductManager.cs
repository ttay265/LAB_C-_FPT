using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1
{
    class ProductManager : LinkedList<Product>
    {
        #region Attributes & Properties
        public static int SEARCH_BY_NAME = 1;
        public static int SEARCH_BY_PRICERANGE = 2;
        public static int SEARCH_BY_MANUFACTURER = 3;
        #endregion

        public bool AddNewProduct(Product newOne)
        {
            Console.WriteLine("Adding to Product List...");
            if (this.Contains(newOne))
            {
                return false;
            }
            else
            {
                if (this.AddLast(newOne) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool UpdateByCode(String Code)
        {
            LinkedListNode<Product> node = this.Find(new Product(Code));

            if (node != null)
            {
                Product UpdateProduct = node.Value;
                Product UpdatedProduct = UpdateProduct.Update(Code);
                Console.WriteLine("Updating to Product List...");
                if (UpdatedProduct != null)
                {
                    node.Value = UpdatedProduct;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteByCode(string Code)
        {
            return this.Remove(new Product(Code));
        }

        public ProductManager Search(Object Keyword, int KeyType)
        {
            ProductManager SearchResult = new ProductManager();
            if (this.Any())
            {
                LinkedListNode<Product> CurrentNode = this.First;
                while (CurrentNode != null && CurrentNode.Value != null)
                {
                    bool found = false;
                    switch (KeyType)
                    {
                        case 1: //Compare Name
                            {
                                string name = (string)Keyword;
                                found = CompareName(CurrentNode.Value, name);
                                break;
                            }
                        case 2: //Compare Price Range
                            {
                                found = ComparePriceRange(CurrentNode.Value, (double[])Keyword);
                                break;
                            }
                        case 3: //Compare Manufacturer
                            {
                                found = CompareManufacturer(CurrentNode.Value, (string)Keyword);
                                break;
                            }
                        default: break;
                    }
                    if (found)
                    {
                        SearchResult.AddLast(CurrentNode.Value);
                    }
                    CurrentNode = CurrentNode.Next;
                }
                return SearchResult;
            }
            return null;


        }
        #region comparer
        bool CompareName(Product Product1, string Name)
        {
            Regex regex = new Regex(Name, RegexOptions.IgnoreCase);
            return regex.IsMatch(Product1.ProductName);
        }
        bool ComparePriceRange(Product Product1, double[] PriceRange)
        {
            return Product1.UnitPrice > PriceRange[0] && Product1.UnitPrice < PriceRange[1];
        }
        bool CompareManufacturer(Product Product1, string Manufacturer)
        {
            Regex regex = new Regex(Manufacturer, RegexOptions.IgnoreCase);
            return regex.IsMatch(Product1.Manufacturer);
        }
        #endregion

        public string Display()
        {

            string Header = " Product Code  |   Product Name   |  Quantity  |    Unit Price    |   Manufacturer   \n"
                          + "_______________|__________________|____________|__________________|__________________\n";
            string Body = "";
            foreach (Product one in this)
            {
                Body = string.Concat(Body, one.ToString() + "\n");
            }
            return string.Concat(Header, Body);
        }

    }
}
