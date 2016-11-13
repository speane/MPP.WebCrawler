using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MPP.WebCrawler.Annotations;
using MPP.WebCrawler.Commands;
using WebCrawler.Result;

namespace MPP.WebCrawler.ViewModel
{
    public class MainViewModel : IIncrementable, ICrawlable, INotifyPropertyChanged
    {
        private const int MinCrawlDepth = 1;
        private const int MaxCrawlDepth = 6;

        private readonly string[] _rootResources;

        private int _count;
        private int _crawlDepth;
        private string _customRootResource;

        public ICommand IncrementCommand => new IncrementCommand(this);

        public ICommand CrawlCommand
        {
            get
            {
                string[] rootResources = string.IsNullOrEmpty(_customRootResource)
                    ? _rootResources
                    : new[] {_customRootResource};

                return new CrawlCommand(this, rootResources, _crawlDepth);
            }
        }

        public int Count {
            get { return _count; }
            set
            {
                _count = value;
                RaiseOnPropertyChanged(nameof(Count));
            }
        }

        public string CustomRootResource
        {
            get { return _customRootResource; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _customRootResource = Uri.IsWellFormedUriString(value, UriKind.Absolute) ? value : string.Empty;
                }
                else
                {
                    _customRootResource = string.Empty;
                }
                RaiseOnPropertyChanged(nameof(CustomRootResource));
            }
        }

        public string CrawlDepth
        {
            get { return _crawlDepth.ToString(); }
            set
            {
                int tempCrawlDepth;
                if (int.TryParse(value, out tempCrawlDepth))
                {
                    if (tempCrawlDepth >= MinCrawlDepth)
                    {
                        _crawlDepth = tempCrawlDepth <= MaxCrawlDepth ? tempCrawlDepth : MaxCrawlDepth;
                    }
                    else
                    {
                        _crawlDepth = MinCrawlDepth;
                    }
                }
                RaiseOnPropertyChanged(nameof(CrawlDepth));
            }
        }

        public MainViewModel(string[] rootResources, int crawlDepth)
        {
            _crawlDepth = crawlDepth;
            _rootResources = rootResources;
        }

        public void Increment()
        {
            Count++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetCrawlResult(CrawlResult result)
        {
            MessageBox.Show("fihish");
        }
    }
}
