using PiCross;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class PuzzleSelectorViewModel
    {
        public MainViewModel ViewModel { get; }
        public List<PuzzleViewModel> Puzzles { get; set; }
        public IPuzzleLibrary PuzzleLibrary { get; set; }
        public ICommand Quit { get; }
        public ICommand Back { get; }

        public PuzzleSelectorViewModel(MainViewModel mainViewModel)
        {
            this.ViewModel = mainViewModel;
            var data = this.ViewModel.PiCrossFacade.CreateDummyGameData();
            this.Puzzles = data.PuzzleLibrary.Entries.Select(e => new PuzzleViewModel(e.Puzzle, mainViewModel)).ToList();
            this.Quit = new Command(() => this.ViewModel.Close());
            this.Back = new Command(() => this.ViewModel.BackToStart());
        }
    }
    }
