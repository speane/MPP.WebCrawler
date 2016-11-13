using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using WebCrawler.Result;

namespace WebCrawler.Crawler
{
    public class SimpleWebCrawler : ISimpleWebCrawler
    {
        private readonly int _crawlDepth;

        public SimpleWebCrawler(int depth)
        {
            _crawlDepth = depth;
        }

        public async Task<CrawlResult> PerformCrawlingAsync(string[] rootUrls)
        {
            const int startDepth = 1;
            const string rootUrl = "/";
            List<Task<CrawlResult>> crawlResultTasks = new List<Task<CrawlResult>>();
            foreach (string url in rootUrls)
            {
                crawlResultTasks.Add(CrawlUrl(url, startDepth + 1));
            }

            return new CrawlResult()
            {
                Url = rootUrl,
                CrawlResults = new ObservableCollection<CrawlResult>(await Task.WhenAll(crawlResultTasks))
            };
        }

        private async Task<CrawlResult> CrawlUrl(string url, int depth)
        {
            CrawlResult result = new CrawlResult {Url = url};
            if (depth <= _crawlDepth)
            {
                string[] childUrls = await Task<string[]>.Factory.StartNew(() => GetChildUrls(url));

                List<Task<CrawlResult>> crawlResultTasks = new List<Task<CrawlResult>>();
                foreach (string childUrl in childUrls)
                {
                    crawlResultTasks.Add(CrawlUrl(childUrl, depth + 1));
                }

                result.CrawlResults = new ObservableCollection<CrawlResult>(await Task.WhenAll(crawlResultTasks));
            }

            return result;
        }

        private static string[] GetChildUrls(string url)
        {
            Thread.Sleep(100);
            return new[] {url + 1, url + 2};
        }
    }
}
