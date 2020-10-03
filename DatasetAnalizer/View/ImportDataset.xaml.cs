using DatasetAnalizer.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DatasetAnalizer.View
{
    /// <summary>
    /// Interaktionslogik für Source.xaml
    /// </summary>
    public partial class ImportDataset : UserControl
    {
        public ImportDataset()
        {
            InitializeComponent();
            //CB_chars.ItemsSource = NamedChars.GetNames();
        }
    }
}
