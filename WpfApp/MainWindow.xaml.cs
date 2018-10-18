using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp.WPF_ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TransactionHandler handler;
        WindowsViewModel viewModel;
        int taskCount;

        public MainWindow()
        {
            InitializeComponent();
            handler = new TransactionHandler();
            viewModel = new WindowsViewModel();
            DataContext = viewModel;
            taskCount = 0;
        }

        /// <summary>
        /// Dispatch add task
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(TaskViewModel task)
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                // Need for invoke if called from a different thread
                Dispatcher.Invoke(
                    DispatcherPriority.Normal, (ThreadStart)delegate () { AddTask(task); });
            }
            else
            {
                // add this line at the top of the log
                viewModel.Tasks.Add(task);
            }
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <returns></returns>
        (TaskViewModel task, IProgress<long> progress) CreateTask(string tt = null)
        {
            TaskViewModel task = new TaskViewModel($"task {tt} {taskCount++}");
            IProgress<long> progress = new Progress<long>(value =>
            {
                task.Progress = value;
            });
            AddTask(task);
            return (task, progress);
        }

        private async void button_createIdealTask_Click(object sender, RoutedEventArgs e)
        {
            (TaskViewModel task, IProgress<long> progress) = CreateTask("ideal");
            task.Result = await handler.GetTransactionId("ok", progress);
        }

        private async void button_createLongTask_Click(object sender, RoutedEventArgs e)
        {
            (TaskViewModel task, IProgress<long> progress) = CreateTask("long");
            task.Result = await handler.GetTransactionId("long", progress);
        }

        private async void button_createFaultyTask_Click(object sender, RoutedEventArgs e)
        {
            (TaskViewModel task, IProgress<long> progress) = CreateTask("faulty");
            try
            {
                task.Result = await handler.GetTransactionId("fail", progress);
            }
            catch (InvalidOperationException)
            {
                task.Result = "failed";
            }
        }

        private async void button_createIdealTask_bulk_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Parallel.For(0, 5, async (i) =>
             {
                 (TaskViewModel task, IProgress<long> progress) = CreateTask("ideal");
                 task.Result = await handler.GetTransactionId("ok", progress);
             }));
        }

        private async void button_createLongTask_Copy_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Parallel.For(0, 5, async (i) =>
            {
                (TaskViewModel task, IProgress<long> progress) = CreateTask("long");
                task.Result = await handler.GetTransactionId("long", progress);
            }));
        }

        private async void button_createFaultyTask_bulk_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Parallel.For(0, 5, async (i) =>
            {
                (TaskViewModel task, IProgress<long> progress) = CreateTask("faulty");
                try
                {
                    task.Result = await handler.GetTransactionId("fail", progress);
                }
                catch (InvalidOperationException)
                {
                    task.Result = "failed";
                }
            }));
        }
    }
}
