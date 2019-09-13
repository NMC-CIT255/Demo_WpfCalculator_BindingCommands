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
        public ICommand ButtonNumberCommand { get; set; }

        private string _operandString;

        public string OperandString
        {
            get { return _operandString; }
            set { _operandString = value; }
        }


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
            _displayContent = "Hello Amy!";
            ButtonNumberCommand = new RelayCommand(new Action<object>(UpdateOperandString));
        }

        private void UpdateOperandString(object obj)
        {
            _operandString += obj.ToString();
            DisplayContent = _operandString;
        }
    }
}
