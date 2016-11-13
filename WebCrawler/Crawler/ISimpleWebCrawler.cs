﻿using System.Threading.Tasks;
using WebCrawler.Result;

namespace WebCrawler.Crawler
{
    public interface ISimpleWebCrawler
    {
        Task<CrawlResult> PerformCrawlingAsync(string[] rootUrls);
    }
}
