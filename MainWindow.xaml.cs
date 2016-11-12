using System.Windows;
using MPP.WebCrawler.Commands;
using MPP.WebCrawler.ViewModel;
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
            InitializeComponent();

            var model = new MainViewModel();

            var crawlCommand = new CrawlCommand(model);
            crawlCommand.Crawler = new SimpleWebCrawler();

            model.CrawlCommand = new CrawlCommand(model);
            model.IncrementCommand = new IncrementCommand(model);

            DataContext = model;
        }
    }
}
