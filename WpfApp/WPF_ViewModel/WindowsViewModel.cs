using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.WPF_ViewModel
{
    public class WindowsViewModel
    {
        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public WindowsViewModel()
        {
            Tasks = new ObservableCollection<TaskViewModel>();
        }
    }
}
