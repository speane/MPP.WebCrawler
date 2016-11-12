using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MPP.WebCrawler.Annotations;

namespace MPP.WebCrawler.ViewModel
{
    public class MainViewModel : IIncrementable, INotifyPropertyChanged
    {
        private int _count;

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
    }
}
