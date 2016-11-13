using System;
using System.Windows.Input;
using MPP.WebCrawler.ViewModel;

namespace MPP.WebCrawler.Commands
{
    internal class IncrementCommand : ICommand
    {
        private readonly IIncrementable _incrementable;

        public IncrementCommand(IIncrementable incrementable)
        {
            _incrementable = incrementable;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _incrementable.Increment();
        }

        public event EventHandler CanExecuteChanged;
    }
}
