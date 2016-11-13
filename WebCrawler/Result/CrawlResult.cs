using System.Collections.ObjectModel;

namespace WebCrawler.Result
{
    public class CrawlResult
    {
        public string Url { get; set; }

        public ObservableCollection<CrawlResult> CrawlResults { get; set; }
    }
}
