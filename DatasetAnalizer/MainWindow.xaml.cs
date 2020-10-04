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


namespace DatasetAnalizer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WindowState lastWindowstate;

        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            lastWindowstate = WindowState.Normal;
            ConsoleManager.Show();

            this.PreviewMouseDown += window_MouseDown;
        }

        void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        void OnHandleClick(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            lastWindowstate = this.WindowState;
        }

        void OnMaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        void Maximize()
        {
            WindowState = WindowState.Maximized;
            MainBorder.Margin = new Thickness(6);
            MainBorder.BorderThickness = new Thickness(0);
            windowChrome.ResizeBorderThickness = new Thickness(0);
            B_maximize.Content = "\ueb81";
        }

        void Normalize()
        {
            WindowState = WindowState.Normal;
            MainBorder.Margin = new Thickness(0);
            //MainBorder.BorderThickness = new Thickness(1);
            windowChrome.ResizeBorderThickness = new Thickness(7);
            B_maximize.Content = "\ueb79";
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(this.WindowState != lastWindowstate)
            {
                if (this.WindowState == WindowState.Maximized)
                    Maximize();
                else
                if (this.WindowState == WindowState.Normal)
                    Normalize();

                lastWindowstate = this.WindowState;
            }
        }
    }
}
