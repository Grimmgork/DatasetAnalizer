using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading;
using DatasetAnalizer;

namespace DatasetAnalizer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand clearAllCommand { get; private set; }
        ImportDataSetViewModel vm = new ImportDataSetViewModel();

        public MainWindowViewModel()
        {
            clearAllCommand = new ClearAllCommand(this);
            //ConsoleManager.Show();
        }

        ViewModelBase _mainContent;
        public ViewModelBase MainContent
        {
            get
            {
                return _mainContent;
            }
            set
            {
                _mainContent = value;
                OnPropertyChanged("MainContent");
            }
        }

        public void Reset()
        {
            vm.Show();
        }

        public class ClearAllCommand : ICommand
        {
            private MainWindowViewModel obj;

            public ClearAllCommand(MainWindowViewModel _obj)
            {
                obj = _obj;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                obj.Reset();
            }
        }

        public class ImportDataSetCommand : ICommand
        {
            private MainWindowViewModel obj;
            private ImportDataSetViewModel vm;

            public ImportDataSetCommand(MainWindowViewModel obj, ImportDataSetViewModel vm)
            {
                this.obj = obj;
                this.vm = vm;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                //obj.ImportDataset(vm.Objects);
            }
        }
    }
}
