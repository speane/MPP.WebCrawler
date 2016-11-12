using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MPP.WebCrawler.Annotations;
using WebCrawler.Result;

namespace MPP.WebCrawler.ViewModel
{
    public class MainViewModel : IIncrementable, ICrawlable, INotifyPropertyChanged
    {
        private int _count;

        public ICommand IncrementCommand { get; set; }

        public ICommand CrawlCommand { get; set; }

        public int Count {
            get { return _count; }
            set
            {
                _count = value;
                RaiseOnPropertyChanged(nameof(Count));
            }
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
            throw new NotImplementedException();
        }
    }
}
