using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {

        public IPlayablePuzzleSquare Square { get; }
        public ICommand Cycle { get; }
        public Cell<Square> Contents
        {
            get
            {
                return Square.Contents;
            }
        }

        public SquareViewModel(IPlayablePuzzleSquare Square)
        {
            this.Square = Square;
            this.Cycle = new CycleCommand(this);
        }

    }

    public class CycleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private SquareViewModel _viewModel;

        public CycleCommand(SquareViewModel viewmodel)
        {
            _viewModel = viewmodel;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var square = parameter as IPlayablePuzzleSquare;
            if (square.Contents.Value == Square.FILLED)
            {
                square.Contents.Value = Square.EMPTY;
            }
            else
            {
                square.Contents.Value = Square.FILLED;
            }
        }
    }
}
