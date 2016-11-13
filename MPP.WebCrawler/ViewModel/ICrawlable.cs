using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Result;

namespace MPP.WebCrawler.ViewModel
{
    internal interface ICrawlable
    {
        void SetCrawlResult(CrawlResult result);
    }
}
