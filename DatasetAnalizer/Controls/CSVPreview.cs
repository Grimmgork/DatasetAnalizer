using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatasetAnalizer.Model;
using DatasetAnalizer.Model.CSVImport;

namespace DatasetAnalizer.Controls
{
    public class CSVPreview : Control
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(PreviewData), typeof(CSVPreview), new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.AffectsRender,OnDataPropertyChanged));
        private static void OnDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CSVPreview o = d as CSVPreview;
            o.InitData();
        }
        public PreviewData Data
        {
            get
            {
                return (PreviewData)GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
            }
        }

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(Brush), typeof(CSVPreview), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush TextColor
        {
            get
            {
                return (Brush)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public static readonly DependencyProperty DarkTextColorProperty = DependencyProperty.Register("DarkTextColor", typeof(Brush), typeof(CSVPreview), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush DarkTextColor
        {
            get
            {
                return (Brush)GetValue(DarkTextColorProperty);
            }
            set
            {
                SetValue(DarkTextColorProperty, value);
            }
        }

        public static readonly DependencyProperty HighlightColorProperty = DependencyProperty.Register("HighlightColor", typeof(Brush), typeof(CSVPreview), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush HighlightColor
        {
            get
            {
                return (Brush)GetValue(HighlightColorProperty);
            }
            set
            {
                SetValue(HighlightColorProperty, value);
            }
        }


        static GlyphTypeface typeFace;
        static int numberOfColors = 3;

        static int letterWidth = 7;
        static int letterHeight = 18;


        ObservableCollection<PreviewData.Row> headers;
        GlyphRun[] glyphRuns = new GlyphRun[numberOfColors];


        int _firstRowIndex;
        int firstRowIndex
        {
            get
            {
                return _firstRowIndex;
            }
            set
            {
                _firstRowIndex = value;
            }
        }

        int _viewHeight;
        int viewHeight
        {
            get
            {
                return _viewHeight;
            }
            set
            {
                _viewHeight = value;
            }
        }

        Rectangle mainArea;
        ItemsControl rowHeaderControl;
        ScrollBar verticalScrollbar;
        ScrollBar horizontalScrollbar;


        static CSVPreview()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CSVPreview), new FrameworkPropertyMetadata(typeof(CSVPreview)));
            new Typeface("Consolas").TryGetGlyphTypeface(out typeFace);
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            verticalScrollbar = GetTemplateChild("CSVPreview_VerticalScrollbar") as ScrollBar;
            horizontalScrollbar = GetTemplateChild("CSVPreview_HorizontalScrollbar") as ScrollBar;
            rowHeaderControl = GetTemplateChild("CSVPreview_RowHeaderItemControl") as ItemsControl;
            mainArea = GetTemplateChild("CSVPreview_MainAreaRectangle") as Rectangle;

            if (verticalScrollbar == null) throw new Exception("Couldn't find 'CSVPreview_VerticalScrollbar'");
            if (horizontalScrollbar == null) throw new Exception("Couldn't find 'CSVPreview_HorizontalScrollbar'");
            if (rowHeaderControl == null) throw new Exception("Couldn't find 'CSVPreview_RowHeaderItemControl'");
            if (mainArea == null) throw new Exception("Couldn't find 'CSVPreview_MainAreaRectangle'");

            verticalScrollbar.Scroll += VerticalScrollbar_Scroll;
            SizeChanged += CSVPreview_SizeChanged;
            headers = new ObservableCollection<PreviewData.Row>();
            rowHeaderControl.ItemsSource = headers;
        }

        private void VerticalScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            firstRowIndex = (int)(sender as ScrollBar).Value;
            ComputeRowHeaders();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (Data == null)
                return;

            ComputeGlyphRuns();

            GlyphRun gr;
            gr = glyphRuns[0];
            if (gr != null)
                drawingContext.DrawGlyphRun(TextColor, gr);
            gr = glyphRuns[1];
            if (gr != null)
                drawingContext.DrawGlyphRun(DarkTextColor, gr);
            gr = glyphRuns[2];
            if (gr != null)
                drawingContext.DrawGlyphRun(HighlightColor, gr);
        }


        private void CSVPreview_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Data == null)
                return;

            MoveView((int)(mainArea.ActualHeight / letterHeight), 0);
        }

        void ComputeGlyphRuns()
        {
            Console.WriteLine("Computing glyphRuns!");
        }

        void ComputeRowHeaders()
        {
            headers.Clear();

            for (int i = firstRowIndex; i < firstRowIndex+viewHeight; i++)
            {
                if (i >= Data.rows.Length)
                    break;

                headers.Add(Data.rows[i]);
            }
        }

        void InitData()
        {
            Console.WriteLine("Data changed!");
            verticalScrollbar.Maximum = Data.rows.Length;
            verticalScrollbar.ViewportSize = viewHeight;

            ComputeRowHeaders();
        }

        void MoveView(int row, int column)
        {
            firstRowIndex = row;
            ComputeRowHeaders();
            InvalidateVisual();
        }
    }
}
