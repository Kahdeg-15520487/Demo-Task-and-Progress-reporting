using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.WPF_ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public TaskViewModel(string name)
        {
            this.name = name;
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private long progress;
        public long Progress
        {
            get => progress;
            set
            {
                progress = value;
                NotifyPropertyChanged("Progress");
            }
        }

        private string result;
        public string Result
        {
            get => result;
            set
            {
                result = value;
                NotifyPropertyChanged("Result");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Obj)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Obj));
        }
    }
}
