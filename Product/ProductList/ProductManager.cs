using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2
{
    public class ProductManager : LinkedList<Product>
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
    public class Product : IComparable<Product>
    {
        #region Attributes&Properties&Constructor

        private string _ProductCode;
        private string _ProductName;
        private double _UnitPrice;
        private int _Quantity;
        private string _Manufacturer;


        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }


        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }


        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { _Manufacturer = value; }
        }

        public Product()
        {

        }

        public Product(string ProductCode, string Productname, double UnitPrice, int Quantity, string Manufacturer)
        {
            this._ProductCode = ProductCode;
            this._ProductName = Productname;
            this._UnitPrice = UnitPrice;
            this._Quantity = Quantity;
            this._Manufacturer = Manufacturer;
        }

        public Product(string ProductCode)
        {
            this._ProductCode = ProductCode;
        }

        #endregion

        #region OverridenMethods

        public override bool Equals(Object obj)
        {
            Product ProductObj = (Product)obj;
            return this._ProductCode.Equals(ProductObj._ProductCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(" {0,-14}|   {1,-15}|{2,10}  |{3,16:C}  |   {4,-15}"
                , this._ProductCode, this._ProductName, this._Quantity, this._UnitPrice, this._Manufacturer);
        }

        int IComparable<Product>.CompareTo(Product other)
        {
            return this.UnitPrice.CompareTo(other.UnitPrice);
        }
        #endregion


        #region Methods

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(" Product Code  |   Product Name   |  Quantity  |    Unit Price    |   Manufacturer   ");
            Console.WriteLine("_______________|__________________|____________|__________________|__________________");
            Console.WriteLine("{0}\n", this.ToString());
        }

        public void Input()
        {
            string ErrorMessage = "";
            while (true)
            {
                this.Display();
                Console.WriteLine(ErrorMessage);
                ErrorMessage = "";
                Console.Write("Enter Product Code (Pxxx): ");
                string tmp_ProductCode = Console.ReadLine();
                Regex ProductCodeRegex = new Regex(@"\b[P]\d{3}$", RegexOptions.IgnoreCase);
                if (!string.IsNullOrEmpty(tmp_ProductCode) && ProductCodeRegex.IsMatch(tmp_ProductCode))
                {
                    this._ProductCode = tmp_ProductCode;
                    break;
                }
                else
                {
                    ErrorMessage = "Invalid input! Error: Product Code format must be (Pxxx)! Try again!";
                }
            }
            while (true)
            {
                this.Display();
                Console.WriteLine(ErrorMessage);
                ErrorMessage = "";
                Console.Write("Enter Product Name: ");
                string tmp_ProductName = Console.ReadLine();
                if (!string.IsNullOrEmpty(tmp_ProductName))
                {
                    this._ProductName = tmp_ProductName;
                    break;
                }
                else
                {
                    ErrorMessage = "Invalid input! Error: Product Name must not be empty! Try again!";
                }
            }
            while (true)
            {
                this.Display();

                try
                {
                    Console.WriteLine(ErrorMessage);
                    Console.Write("Enter Quantity: ");
                    int tmp_Quantity = int.Parse(Console.ReadLine());
                    if (tmp_Quantity >= 0)
                    {
                        this._Quantity = tmp_Quantity;
                        break;
                    }
                    else
                    {
                        ErrorMessage = "Invalid Input!" + "Error: Quantity must be larger equal than 0!";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Invalid Input!" + "Error: Quantity must be decimal number!";
                }
            }
            while (true)
            {
                this.Display();
                try
                {
                    Console.WriteLine(ErrorMessage);
                    ErrorMessage = "";
                    Console.Write("Enter Unit Price (VND): ");
                    int tmp_UnitPrice = int.Parse(Console.ReadLine());
                    if (tmp_UnitPrice >= 0)
                    {
                        this._UnitPrice = tmp_UnitPrice;
                        break;
                    }
                    else
                    {
                        ErrorMessage = "Invalid Input!" + "Error: Unit Price must be larger equal than 0!";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Invalid Input!" + "Error: Unit Price must be number!";
                }
            }
            while (true)
            {
                this.Display();
                Console.WriteLine(ErrorMessage);
                ErrorMessage = "";
                Console.Write("Enter Product Manufacturer: ");
                string tmp_Manufacturer = Console.ReadLine();
                if (!string.IsNullOrEmpty(tmp_Manufacturer))
                {
                    this._Manufacturer = tmp_Manufacturer;
                    break;
                }
                else
                {
                    ErrorMessage = "Invalid input! Error: Product Manufacturer must not be empty! Try again!";
                }
            }
            this.Display();
        }
        public Product Update(string UpdateCode)
        {
            string ErrorMessage = "";
            while (true)
            {
                this.Display();
                Console.WriteLine(ErrorMessage);
                ErrorMessage = "";
                Console.Write("Enter Product Name: ");
                string tmp_ProductName = Console.ReadLine();
                if (!string.IsNullOrEmpty(tmp_ProductName))
                {
                    this._ProductName = tmp_ProductName;
                    break;
                }
                else
                {
                    ErrorMessage = "Invalid input! Error: Product Name must not be empty! Try again!";
                }
            }
            while (true)
            {
                this.Display();

                try
                {
                    Console.WriteLine(ErrorMessage);
                    Console.Write("Enter Quantity: ");
                    int tmp_Quantity = int.Parse(Console.ReadLine());
                    if (tmp_Quantity >= 0)
                    {
                        this._Quantity = tmp_Quantity;
                        break;
                    }
                    else
                    {
                        ErrorMessage = "Invalid Input!" + "Error: Quantity must be larger equal than 0!";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Invalid Input!" + "Error: Quantity must be decimal number!";
                }
            }
            while (true)
            {
                this.Display();
                try
                {
                    Console.WriteLine(ErrorMessage);
                    ErrorMessage = "";
                    Console.Write("Enter Unit Price (VND): ");
                    int tmp_UnitPrice = int.Parse(Console.ReadLine());
                    if (tmp_UnitPrice >= 0)
                    {
                        this._UnitPrice = tmp_UnitPrice;
                        break;
                    }
                    else
                    {
                        ErrorMessage = "Invalid Input!" + "Error: Unit Price must be larger equal than 0!";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Invalid Input!" + "Error: Unit Price must be number!";
                }
            }
            while (true)
            {
                this.Display();
                Console.WriteLine(ErrorMessage);
                ErrorMessage = "";
                Console.Write("Enter Product Manufacturer: ");
                string tmp_Manufacturer = Console.ReadLine();
                if (!string.IsNullOrEmpty(tmp_Manufacturer))
                {
                    this._Manufacturer = tmp_Manufacturer;
                    break;
                }
                else
                {
                    ErrorMessage = "Invalid input! Error: Product Manufacturer must not be empty! Try again!";
                }
            }
            this.Display();
            return this;
        }
        #endregion
    }
}
