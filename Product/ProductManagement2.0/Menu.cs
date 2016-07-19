using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement2._0
{
    public class Menu : List<String>
    {
        #region Attributes & Properties 
        private string _Title;
        private bool _ClearPreviousTask;
        private bool _ExitOption;
        private string _LastTaskMessage;
        private string _InvalidChoice = "Invalid Choice!";
        private bool _InvalidChosen;

        public bool InvalidChosen
        {
            get { return _InvalidChosen; }
            set { _InvalidChosen = value; }
        }


        public string InvalidChoice
        {
            get { return _InvalidChoice; }
            set { _InvalidChoice = value; }
        }


        public string LastTaskMessage
        {
            get { return _LastTaskMessage; }
            set { _LastTaskMessage = value; }
        }

        public bool ExitOption
        {
            get { return _ExitOption; }
            set { _ExitOption = value; }
        }

        public bool ClearPreviousTask
        {
            get { return _ClearPreviousTask; }
            set { _ClearPreviousTask = value; }
        }


        public string Title
        {
            get { return Title; }
            set { Title = value; }
        }
        #endregion
        #region Constructor
        public Menu()
        {
            this._ExitOption = false;
        }

        public Menu(string Title)
        {
            this._ExitOption = false;
            this._Title = Title;
        }
        #endregion

        public void AddLine(string line)
        {
            this.Add(line);
        }
        public int select()
        {
            if (_ClearPreviousTask)
            {
                Console.Clear();
                this.Display();
            }
            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice <= this.Count)
                {
                    return choice;
                } 
            }
            catch (Exception ex)
            {
            }
            _InvalidChosen = true;
            return -1;
            
        }
        public void Display()
        {
            if (!this._Title.Any())
            {
                this._Title = "*";
            }
            Console.WriteLine("*****************{0}*****************\n", this._Title);
            foreach (string line in this)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("*************************************\n");
            if (!string.IsNullOrEmpty(LastTaskMessage))
            {
                Console.WriteLine("Message: \n{0}", LastTaskMessage);
            }
            if (InvalidChosen)
            {
                Console.WriteLine("Message: \n{0}", _InvalidChoice);
            }
            Console.Write("\nSelect: ");
        }
    }
}
