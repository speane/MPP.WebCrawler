using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Result;

namespace WebCrawler.Crawler
{
    public class SimpleWebCrawler : ISimpleWebCrawler
    {
        public async Task<CrawlResult> PerformCrawlingAsync(string[] rootUrls)
        {
            return new CrawlResult();
        }
    }
}
