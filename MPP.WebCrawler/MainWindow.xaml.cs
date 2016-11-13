using System.IO;
using System.Windows;
using MPP.WebCrawler.Commands;
using MPP.WebCrawler.Config;
using MPP.WebCrawler.ViewModel;
using Newtonsoft.Json;
using WebCrawler.Crawler;

namespace MPP.WebCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppConfig config = LoadConfig("AppConfig.json");
            InitializeComponent();

            var model = new MainViewModel(config.RootResources, config.MaxCrawlDepth);

            DataContext = model;
        }

        private static AppConfig LoadConfig(string configFilePath)
        {
            return JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(configFilePath));
        }
    }
}
