using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPP.WebCrawler.Config
{
    internal class AppConfig
    {
        [JsonProperty("depth")]
        public int MaxCrawlDepth { get; set; }

        [JsonProperty("resources")]
        public string[] RootResources { get; set; }
    }
}
