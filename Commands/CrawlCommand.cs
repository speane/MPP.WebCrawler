using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MPP.WebCrawler.ViewModel;
using WebCrawler.Crawler;

namespace MPP.WebCrawler.Commands
{
    internal class CrawlCommand : ICommand
    {
        private ICrawlable _crawlable;

        public ISimpleWebCrawler Crawler { get; set; }

        public CrawlCommand(ICrawlable crawlable)
        {
            _crawlable = crawlable;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
