using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object activeScreen;

        public event PropertyChangedEventHandler PropertyChanged;

        public PiCrossFacade PiCrossFacade { get; }

        public MainViewModel()
        {
            this.activeScreen = new WelcomeViewModel(this);
            this.PiCrossFacade = new PiCrossFacade();
        }

        public object ActiveScreen
        {
            get
            {
                return activeScreen;
            }

            private set
            {
                activeScreen = value;

            //if (propertychanged =! null) then invoke --> vraagteken is een verkorte if functie
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveScreen)));
            }
        }

        public void StartGame()
        {
            var data = this.PiCrossFacade.CreateDummyGameData();
            var list = data.PuzzleLibrary.Entries;
            var Puzzles = data.PuzzleLibrary.Entries.Select(e => e.Puzzle).ToList();
            this.ActiveScreen = new GameViewModel(this, Puzzles.First());
        }

        public Action Close { get; set; }

        public void SelectPuzzle()
        {
            this.ActiveScreen = new PuzzleSelectorViewModel(this);
        }

        public void StartGame(IPlayablePuzzle puzzle)
        {
            this.ActiveScreen = new GameViewModel(this, puzzle);
        }

        public void CloseWindow()
        {
            this.Close?.Invoke();
        }

        public void BackToStart()
        {
            this.ActiveScreen = new WelcomeViewModel(this);
        }
    }
}
