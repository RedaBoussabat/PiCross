using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class WelcomeViewModel
    {
        public MainViewModel MainViewModel { get; }
        public ICommand Start { get; }
        public ICommand SelectPuzzle { get; }
        public ICommand Quit { get; }

        public WelcomeViewModel(MainViewModel mainViewModel)
        {
            this.MainViewModel = mainViewModel;
            this.Start = new StartCommand(this.MainViewModel);
            this.SelectPuzzle = new SelectPuzzleCommand(this.MainViewModel);
            this.Quit = new Command(() => this.MainViewModel.CloseWindow());
        }

        public class StartCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private MainViewModel _vm;
            private bool _canExe;

            public StartCommand(MainViewModel viewModel)
            {
                _vm = viewModel;
                _canExe = true;
            }

            public bool CanExecute(object p)
            {
                return _canExe;
            }
            public void Execute(object p)
            {
                _vm.StartGame();
            }
        }

        public class SelectPuzzleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private MainViewModel _vm;
            private bool _canExe;

            public SelectPuzzleCommand(MainViewModel viewModel)
            {
                _vm = viewModel;
                _canExe = true;
            }

            public bool CanExecute(object p)
            {
                return _canExe;
            }

            public void Execute(object p)
            {
                _vm.SelectPuzzle();
            }

        }
    }
}
