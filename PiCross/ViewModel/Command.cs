using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _A;

        public Command(Action A)
        {
            this._A = A;
        }

        public bool CanExecute(object p)
        {
            return true;
        }

        public void Execute(object p)
        {
            _A();
        }


    }

}

