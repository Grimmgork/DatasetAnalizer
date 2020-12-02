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
        bool _valid;
        public bool Valid
        {
            get
            {
                return _valid;
            }
            set
            {
                _valid = value;
                OnPropertyChanged("Valid");
            }
        }

        CSVImport _importer;
        public CSVImport Importer
        {
            get
            {
                return _importer;
            }
            set
            {
                _importer = value;
                OnPropertyChanged("Importer");
                OnPropertyChanged("Preview");
            }
        }

        public CSVImport.PreviewData Preview
        {
            get
            {
                //Console.WriteLine("kek");
                if(Importer.IsDatasetReady && Importer != null)
                    return Importer.previewData;
                return null;
            }
        }


        public ICommand ImportCommand { get; internal set; }
        public ICommand openFileCommand { get; internal set; }

        
        public ImportDataSetViewModel()
        {
            ImportCommand = new ImportDataSetCommand(this);
            openFileCommand = new OpenFileCommand(this);

            Title = "Import CSV dataset";

            Visuals = new ImportDataset();
        }

        public string OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            else
                return null;
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
                string path = vm.OpenFile();
                if (path == null)
                    return;

                CSVImport.Parameters p = new CSVImport.Parameters();
                p.skipFirstRows = 13;
                p.skipLastRows = 3;
                p.columnCount = 9;
                p.dataSeperator = new byte[1] { 9 };

                vm.Importer = new CSVImport(path);
                vm.Importer.ApplyParameters(p);
            }
        }
    }
}
