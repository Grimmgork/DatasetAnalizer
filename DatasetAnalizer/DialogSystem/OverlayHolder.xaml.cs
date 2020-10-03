using DatasetAnalizer.Model;
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

namespace DatasetAnalizer.DialogSystem
{
    /// <summary>
    /// Interaktionslogik für OverlayHolder.xaml
    /// </summary>
    public partial class OverlayHolder : UserControl
    {
        Dictionary<OverlayViewModelBase, UIElement> stack = new Dictionary<OverlayViewModelBase, UIElement>();

        public OverlayHolder()
        {
            InitializeComponent();
            Overlay.SetMainOverlayHolder(this);
        }

        public void AddOverlay(OverlayViewModelBase overlayView)
        {
            if (stack.Keys.Contains(overlayView))
                return;

            OverlayLayer layer = new OverlayLayer(overlayView);
            stack.Add(overlayView, layer);
            main.Children.Add(layer);
        }

        public void CloseOverlay(OverlayViewModelBase overlayView)
        {
            main.Children.Remove(stack[overlayView]);
            stack.Remove(overlayView);
        }

        public void Clear()
        {
            main.Children.Clear() ;
            stack.Clear();
        }
    }
}
