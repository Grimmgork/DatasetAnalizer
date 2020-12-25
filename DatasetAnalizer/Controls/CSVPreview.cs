using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

namespace DatasetAnalizer.Controls
{
    public class CSVPreview : Control
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(CSVFileImport.PreviewData), typeof(CSVPreview), new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.AffectsRender,OnDataPropertyChanged));
        private static void OnDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CSVPreview o = d as CSVPreview;
            o.InitData();
        }
        public CSVFileImport.PreviewData Data
        {
            get
            {
                return (CSVFileImport.PreviewData)GetValue(DataProperty);
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

        BackgroundWorker worker;

        static GlyphTypeface typeFace;
        static int numberOfColors = 3;

        static ushort letterWidth = 10;
        static ushort letterHeight = 20;

        static int mouseWheelSpeed = 5;

        ObservableCollection<CSVFileImport.PreviewData.Row> rows;
        GlyphRun[] glyphRuns = new GlyphRun[numberOfColors];

        int firstRowIndex;
        int viewHeight;
        int viewWidth;

        bool buisy;

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

            verticalScrollbar.ValueChanged += VerticalScrollbar_ValueChanged;
            MouseWheel += CSVPreview_MouseWheel;
            SizeChanged += CSVPreview_SizeChanged;
            rows = new ObservableCollection<CSVFileImport.PreviewData.Row>();

            verticalScrollbar.SmallChange = 1;
            verticalScrollbar.LargeChange = 1;
            rowHeaderControl.ItemsSource = rows;
        }

        private void VerticalScrollbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int value = (int)(sender as ScrollBar).Value;
            if (firstRowIndex != value)
                MoveView(value, 0);
        }

        private void CSVPreview_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int value;
            if (e.Delta < 0)
                value = mouseWheelSpeed;
            else
                value = -mouseWheelSpeed;

            verticalScrollbar.Value += value;
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

            glyphRuns = null;
        }


        private void CSVPreview_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Measure();
            ComputeRows();
        }

        void ComputeGlyphRuns()
        {
            glyphRuns = new GlyphRun[numberOfColors];

            var glyphIndices = new List<ushort>();
            var advanceWidths = new List<double>();
            var glyphOffsets = new List<Point>();

            ushort x = 0, y = 0;
            int lastRowIndex = firstRowIndex + viewHeight;

            for (int rowIndex = firstRowIndex; rowIndex < firstRowIndex+viewHeight && rowIndex < Data.NumberOfRows; rowIndex++)
            {
                CSVFileImport.PreviewData.Row row = Data.rows[rowIndex];
                for(int li = row.startIndex; li < row.endIndex; li++)
                {
                    ushort letter = (ushort) Data.rawText[li];
                    glyphIndices.Add(letter);
                    glyphOffsets.Add(new Point(x,y));
                    advanceWidths.Add(0);

                    x += letterWidth;
                }

                //Console.WriteLine(rowIndex);
                x = 0;
                y += letterHeight;
            }


            if (glyphIndices.Count == 0)
                return;

            GlyphRun gr = new GlyphRun(5);
            gr.GlyphTypeface = typeFace;
            gr.AdvanceWidths = advanceWidths;
            gr.FontRenderingEmSize = 10;
            gr.BidiLevel = 10;
            gr.GlyphIndices = glyphIndices;
            gr.BaselineOrigin = new Point(0, 0);
            gr.GlyphOffsets = glyphOffsets;
            glyphRuns[0] = gr;// new GlyphRun(typeFace, 10, false, 12, glyphIndices, new Point(0,0), advanceWidths, glyphOffsets, null, null, null, null, null);
        }

        void ComputeRows()
        {
            rows.Clear();
            if (Data == null)
                return;

            for (int i = firstRowIndex; i < firstRowIndex+viewHeight; i++)
            {
                if (i >= Data.rows.Length)
                    break;

                rows.Add(Data.rows[i]);
            }
        }

        void InitData()
        {
            Measure();
            ComputeRows();
        }

        void Measure()
        {
            int rowCount = 0;
            if (Data != null)
                rowCount = Data.NumberOfRows;

            viewHeight = (int)(mainArea.ActualHeight / letterHeight);
            viewWidth = (int)(mainArea.ActualWidth / letterWidth);
            verticalScrollbar.Maximum = rowCount;
            verticalScrollbar.Minimum = 0;
            verticalScrollbar.ViewportSize = viewHeight;
        }

        public void MoveView(int row, int column)
        {
            firstRowIndex = row;
            if (firstRowIndex != verticalScrollbar.Value)
                verticalScrollbar.Value = row;

            ComputeRows();
            InvalidateVisual();
        }
    }
}
