using DatasetAnalizer.Model;
using DatasetAnalizer.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DatasetAnalizer.DialogSystem;

namespace DatasetAnalizer.ViewModel
{
    public class ImportDataSetViewModel : OverlayViewModelBase
    {
        CSVFileImport importer;

        bool _valid;
        public bool Valid
        {
            get
            {
                return _valid;
            }
            private set
            {
                _valid = value;
                OnPropertyChanged("Valid");
            }
        }

        CSVFileImport.Parameters _paramteres;
        public CSVFileImport.Parameters Parameters
        {
            get
            {
                return _paramteres;
            }
            set
            {
                _paramteres = value;
                OnPropertyChanged("Parameters");
            }
        }

        CSVFileImport.PreviewData _preview;
        public CSVFileImport.PreviewData Preview
        {
            get
            {
                return _preview;
            }
            set
            {
                _preview = value;
                OnPropertyChanged("Preview");
            }
        }

        string _fileName;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public ICommand ImportCommand { get; internal set; }
        public ICommand openFileCommand { get; internal set; }

        public ImportDataSetViewModel()
        {
            Parameters = new CSVFileImport.Parameters() { skipFirstRows = 13, skipLastRows = 3, columnCount = 9, dataSeperator = new byte[1] { 9 } };

            ImportCommand = new ImportDataSetCommand(this);
            openFileCommand = new OpenFileCommand(this);

            Title = "Import CSV dataset";

            Visuals = new ImportDataset();
        }

        public void ApplyParameters()
        {
            importer.ApplyParameters(Parameters);
            Preview = importer.previewData;
        }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == false)
                return;

            string path = openFileDialog.FileName;

            importer = new CSVFileImport(path);
            FileName = importer.fileName;
            ApplyParameters();
        }


        class ImportDataSetCommand : ICommand
        {
            ImportDataSetViewModel vm;
            public ImportDataSetCommand(ImportDataSetViewModel vm)
            {
                this.vm = vm;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                vm.Hide();
            }
        }

        class OpenFileCommand : ICommand
        {
            ImportDataSetViewModel vm;

            public OpenFileCommand(ImportDataSetViewModel vm)
            {
                this.vm = vm;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                vm.OpenFile();
            }
        }
    }
}
