using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DatasetAnalizer.ViewModel;

namespace DatasetAnalizer.DialogSystem
{
    public class OverlayViewModelBase : ViewModelBase
    {
        public ICommand close { get; private set; }

        string title = "Popup";
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(Title);
            }
        }

        UIElement _visuals;
        public UIElement Visuals
        {
            get
            {
                return _visuals;
            }
            internal set
            {
                _visuals = value;
                OnPropertyChanged("Visuals");
            }
        }

        public OverlayViewModelBase()
        {
            close = new CloseCommand(this);
        }

        public void Show()
        {
            Overlay.Add(this);
        }

        public void Hide()
        {
            Overlay.Hide(this);
        }

        class CloseCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            OverlayViewModelBase vm;

            public CloseCommand(OverlayViewModelBase vm)
            {
                this.vm = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                vm.Hide();
            }
        }
    }
}
