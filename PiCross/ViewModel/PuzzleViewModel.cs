using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiCross;
using System.Windows.Input;

namespace ViewModel
{
    public class PuzzleViewModel
    {
        public Puzzle Puzzle { get; }
        public IPlayablePuzzle PlayablePuzzle;
        public ICommand Select { get; }
        public MainViewModel MainViewModel { get; }
        public PuzzleViewModel(Puzzle puzzle, MainViewModel mainViewModel)
        {
            this.Puzzle = puzzle;
            this.MainViewModel = mainViewModel;
            this.PlayablePuzzle = this.MainViewModel.PiCrossFacade.CreatePlayablePuzzle(this.Puzzle);
            this.Select = new Command(() => this.MainViewModel.StartGame(this.PlayablePuzzle));
        }
    }
}
