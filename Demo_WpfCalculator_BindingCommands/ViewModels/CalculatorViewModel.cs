using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Demo_WpfCalculator_BindingCommands;

namespace Demo_WpfCalculator_BindingCommands.ViewModels
{
    public class CalculatorViewModel : ObservableObject
    {
        private enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Percent,
            Sin,
            Cos,
            Tan,
            Square,
            SquareRoot
        }

        private Dictionary<string, Operation> BinaryOperations = new Dictionary<string, Operation>()
        {
            { "+", Operation.Add },
            { "-", Operation.Add },
            { "*", Operation.Add },
            { "/", Operation.Add },
            { "%", Operation.Add }
        };

        private Dictionary<string, Operation> UnaryOperations = new Dictionary<string, Operation>()
        {
            { "Sin", Operation.Add },
            { "Cos", Operation.Add },
            { "Tan", Operation.Add },
            { "Sqr", Operation.Add },
            { "SqrRt", Operation.Add }
        };

        private static string _operandString;
        private static double _operand1;
        private static double _operand2;

        public ICommand ButtonNumberCommand { get; set; }
        public ICommand ButtonOperationCommand { get; set; }

        private Operation CurrentOperation { get; set; }

        private string _displayContent;

        public string DisplayContent
        {
            get { return _displayContent; }
            set
            {
                _displayContent = value;
                OnPropertyChanged("DisplayContent");
            }
        }

        public CalculatorViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            _displayContent = "Enter Number";
            ButtonNumberCommand = new RelayCommand(new Action<object>(UpdateOperandString));
            ButtonOperationCommand = new RelayCommand(new Action<object>(SetOperation));
        }

        private void UpdateOperandString(object obj)
        {
            if (obj.ToString() != "CE")
            {
                _operandString += obj.ToString();

            }
            else
            {
                _operandString = "";
            }
            DisplayContent = _operandString;
        }

        private void SetOperation(object obj)
        {
            string operation = obj.ToString();

            if (double.TryParse(_operandString, out double result))
            {
                _operand1 = result;
                _operandString = "";
                DisplayContent = _operandString;

                if (BinaryOperations.ContainsKey(operation))
                {

                }
                else if (UnaryOperations.ContainsKey(operation))
                {
                    DisplayContent = ProcessUnaryOperation(UnaryOperations[operation]).ToString();
                }
                else
                {
                    DisplayContent = "Unknown Error Encountered";
                }
            }
            else
            {
                DisplayContent = "Unknown Error Encountered";
            }
        }

        static double ProcessUnaryOperation(Operation operation)
        {
            double result = 0;

            switch (operation)
            {
                case Operation.Sin:
                    result = Math.Sin(_operand1);
                    break;
                case Operation.Cos:
                    break;
                case Operation.Tan:
                    break;
                case Operation.Square:
                    break;
                case Operation.SquareRoot:
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
