using DatasetAnalizer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DatasetAnalizer.DialogSystem
{
    public static class Overlay
    {
        static OverlayHolder overlayHolder;

        public static void SetMainOverlayHolder(OverlayHolder oh)
        {
            if (overlayHolder != null)
                throw new System.InvalidOperationException("There cannot be more than one OverlayHolder at any time!");

            overlayHolder = oh;
        }

        public static void Add(OverlayViewModelBase overlayView)
        {
            overlayHolder.AddOverlay(overlayView);
        }

        public static void Close(OverlayViewModelBase overlayView)
        {
            overlayHolder.CloseOverlay(overlayView);
        }

        public static void Clear()
        {
            overlayHolder.Clear();
        }
    }
}
