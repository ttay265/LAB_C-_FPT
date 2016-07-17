using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1
{
    class Product : IComparable<Product>
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

