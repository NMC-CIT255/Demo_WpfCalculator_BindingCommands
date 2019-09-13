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
        private ICommand _button1Command;

        public ICommand Button1Command
        {
            get
            {
                return _button1Command;
            }
            set
            {
                _button1Command = value;
            }
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
            Button1Command = new RelayCommand(new Action<object>(ChangeScreen));
        }

        private void ChangeScreen(object obj)
        {
            DisplayContent = "Hello John!!";
        }
    }
}
