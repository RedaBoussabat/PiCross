using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class GameViewModel
    {
        public Puzzle Puzzle { get; }
        public PiCrossFacade Facade { get; }
        public IPlayablePuzzle PlayablePuzzle { get; set; }
        public MainViewModel MainViewModel { get; set; }
        public IGrid<SquareViewModel> Grid { get; set; }
        public ICommand Back { get; private set; }
        public ICommand Quit { get; private set; }
        public GameViewModel(MainViewModel mainViewModel, Puzzle puzzle)
        {
            this.initialize(mainViewModel, mainViewModel.PiCrossFacade.CreatePlayablePuzzle(puzzle));
        }

        private void initialize(MainViewModel mainViewModel, IPlayablePuzzle playablePuzzle)
        {
            this.MainViewModel = mainViewModel;
            this.PlayablePuzzle = playablePuzzle;
            // => is een lambda expressie, di een blok code die behandeld wordt als een object
            // normaal --> een anonieme inner klasse maken
            //public void actionPerformed(ActionEvent square){  
            //   square = new...
            //}

            //copy creeert de grid
            this.Grid = PlayablePuzzle.Grid.Map(square => new SquareViewModel(square)).Copy();
            this.Quit = new Command(() => this.MainViewModel.Close());
            this.Back = new Command(() => this.MainViewModel.BackToStart());
        }

        public GameViewModel(MainViewModel mainViewModel, IPlayablePuzzle puzzle)
        {
            this.initialize(mainViewModel, puzzle);
        }
    }
}
