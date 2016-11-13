using System;
using System.Windows.Input;
using MPP.WebCrawler.ViewModel;
using WebCrawler.Crawler;
using WebCrawler.Result;

namespace MPP.WebCrawler.Commands
{
    internal class CrawlCommand : ICommand
    {
        private const int MIN_CRAWL_DEPTH = 1;
        private const int MAX_CRAWL_DEPTH = 6;

        private readonly ICrawlable _crawlable;
        private readonly string[] _rootResources;

        private readonly ISimpleWebCrawler _crawler;

        public CrawlCommand(ICrawlable crawlable, string[] rootResources, int depth)
        {
            _crawlable = crawlable;
            _rootResources = rootResources;
            int crawlDepth;
            if (depth >= MIN_CRAWL_DEPTH)
            {
                crawlDepth = depth <= MAX_CRAWL_DEPTH ? depth : MAX_CRAWL_DEPTH;
            }
            else
            {
                crawlDepth = MIN_CRAWL_DEPTH;
            }
            _crawler = new SimpleWebCrawler(crawlDepth);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            CrawlResult result = await _crawler.PerformCrawlingAsync(_rootResources);
            _crawlable.SetCrawlResult(result);
        }

        public event EventHandler CanExecuteChanged;
    }
}
