using DatasetAnalizer.Model;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using System.Diagnostics;

namespace DatasetAnalizer.View
{
    public partial class FormattingPreview : UserControl, INotifyPropertyChanged
    {
        RowPreviewContainer[] _rows;
        public RowPreviewContainer[] Rows
        {
            set
            {
                _rows = value;
            }
            get
            {
                return _rows;
            }
        }

        int _selectedAsciiSymbol;
        public int SelectedAsciiSymbol
        {
            get
            {
                return _selectedAsciiSymbol;
            }
            set
            {
                _selectedAsciiSymbol = value;
                OnPropertyChanged("SelectedAsciiSymbol");
            }
        }

        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("Rows", typeof(RowPreviewContainer[]), typeof(FormattingPreview), new PropertyMetadata(null, RowsChangedCallback));
        private static void RowsChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            FormattingPreview userControl = ((FormattingPreview)dependencyObject);
            userControl.Rows = (RowPreviewContainer[])args.NewValue;
        }

        public int letterWidth { get; private set; }
        public int letterHeight { get; private set; }

        void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public FormattingPreview()
        {
            InitializeComponent();

            letterHeight = 20;
            letterWidth = 10;

            CANV.DataContext = this;
        }

        public void SetProcessing(bool value)
        {
            if(value)
            {
                ProcessingOverlay.Visibility = Visibility.Visible;
                ProcessingOverlay.IsHitTestVisible = true;
            }
            else
            {
                ProcessingOverlay.Visibility = Visibility.Hidden;
                ProcessingOverlay.IsHitTestVisible = false;
            }
        }

        public int GetLetter(int x, int y)
        {
            if (Rows == null)
                return -1;

            if (x < Rows[y].RowData.Length)
                return (int)Rows[y].RowData[x];
            else
                return -1;
        }

        private void LB_ItemMouseMove(object sender, MouseEventArgs e)
        {
            letterHighlight.Visibility = Visibility.Visible;

            Point p = e.GetPosition((sender as TextRow));
            int x = (int)((p.X) / letterWidth);
            int y = (sender as TextRow).Row.rowIndex;

            int value = GetLetter(x, y);
            SelectedAsciiSymbol = value;

            if (value == -1)
                letterHighlight.Visibility = Visibility.Hidden;

            Point plb = e.GetPosition(LB);
            Canvas.SetTop(letterHighlight, (int)((plb.Y) / letterHeight) * letterHeight);
            Canvas.SetLeft(letterHighlight, x * letterWidth + (sender as TextRow).TransformToVisual(LB).Transform(new Point(0,0)).X);
        }

        private void LB_ItemMouseLeave(object sender, MouseEventArgs e)
        {
           letterHighlight.Visibility = Visibility.Hidden;
           SelectedAsciiSymbol = -1;
        }
    }

    static class TextRowParent
    {
        public static Typeface monospaceTypeface = new Typeface(new FontFamily("Consolas"), FontStyles.Normal, FontWeights.Bold, FontStretches.Medium);

        public static GlyphTypeface glyphTypeface;
        public static double renderingEmSize = 15;
        public static double letterWidth = 10;
        public static Point baselineOrigin = new Point(0, 15);

        static byte _colorFieldCount = (byte)Enum.GetNames(typeof(Colors)).Length;
        public static byte ColorFieldCount
        {
            get
            {
                return _colorFieldCount;
            }
        }

        static Brush[] brushes = new Brush[4]
        {
            Application.Current.FindResource("TextDarkColor") as Brush,
            Application.Current.FindResource("PrimaryColor") as Brush,
            Application.Current.FindResource("SuccessColor") as Brush,
            Application.Current.FindResource("TextNormalColor") as Brush
        };

        public static Appearence TextAppearence = new Appearence(brushes, 0,1,2,0 );
        public static Appearence ObjectAppearence = new Appearence(brushes, 3,1,2,0 );

        static TextRowParent()
        {
            monospaceTypeface.TryGetGlyphTypeface(out glyphTypeface);
        }

        public struct Appearence
        {
            Brush[] arsenal;
            int[] map;

            public Appearence(Brush[] arsenal, int baseColor, int rowSepearationColor, int objectNameColor, int cutoffDataseperatorColor)
            {
                map = new int[4] { baseColor, rowSepearationColor, objectNameColor, cutoffDataseperatorColor };
                this.arsenal = arsenal;
            }

            public Brush GetBrush(Colors f)
            {
                return arsenal[map[(int) f]];
            }
        }

        public enum Colors
        {
            baseColor,
            columnSeperatorColor,
            objectNameColor,
            cutoffDataseperatorColor
        }
    }

    

    public class TextRow : FrameworkElement
    {
        bool working = false;

        public GlyphRun[] CurrentRow = new GlyphRun[TextRowParent.ColorFieldCount];
        GlyphRunConstructor[] holders = new GlyphRunConstructor[TextRowParent.ColorFieldCount];

        public RowPreviewContainer Row
        {
            get { return (RowPreviewContainer)GetValue(RowProperty); }
            set { SetValue(RowProperty, value); }
        }
        public static readonly DependencyProperty RowProperty = DependencyProperty.Register("Row", typeof(RowPreviewContainer), typeof(TextRow), new FrameworkPropertyMetadata(NeedRedraw));

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
            if (Row.RowData.Length != 0)
            {
                    if(CurrentRow == null)
                    {
                        CalculateRuns(Row.RowData, CalculateColorMap(Row.seperationCharIndexes, (ushort)Row.RowData.Length, 0));
                    }

                    ref TextRowParent.Appearence app = ref TextRowParent.TextAppearence;
                    if (Row.IsObject)
                        app = ref TextRowParent.ObjectAppearence;

                    drawingContext.DrawGlyphRun(app.GetBrush(TextRowParent.Colors.baseColor), CurrentRow[(int)TextRowParent.Colors.baseColor]);
                    drawingContext.DrawGlyphRun(app.GetBrush(TextRowParent.Colors.objectNameColor), CurrentRow[(int)TextRowParent.Colors.objectNameColor]);
                    drawingContext.DrawGlyphRun(app.GetBrush(TextRowParent.Colors.columnSeperatorColor), CurrentRow[(int)TextRowParent.Colors.columnSeperatorColor]);
                    drawingContext.DrawGlyphRun(app.GetBrush(TextRowParent.Colors.cutoffDataseperatorColor), CurrentRow[(int)TextRowParent.Colors.cutoffDataseperatorColor]);
            }
        }

        private static void NeedRedraw(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TextRow element = source as TextRow;
            element.CurrentRow = null;
            element.InvalidateVisual();
        }

        void CalculateRuns(string line, ColorMap map)
        {
            CurrentRow = new GlyphRun[TextRowParent.ColorFieldCount];

            for (byte i = 0; i < holders.Length; i++)
            {
                holders[i].Clear(TextRowParent.letterWidth, map.GetColorCount(i));
            }

            for (ushort j = 0; j < line.Length; ++j)
            {
                char c = line[j];
                if (c == 9)
                    c = '\u2192';
                else
                if (c < 32 || c == 127)
                    c = '\u2591';
                else
                if (c == 32)
                    c = '\u02FE';

                ushort glyphIndex = TextRowParent.glyphTypeface.CharacterToGlyphMap[c];
                holders[map.GetColorAt(j)].AddLetter(glyphIndex, j);
            }

            for(int i = 0; i < map.colorDepth; i++){
                CurrentRow[i] = holders[i].GetGlyphRun(TextRowParent.renderingEmSize, TextRowParent.baselineOrigin, TextRowParent.glyphTypeface);
            }
        }

        ColorMap CalculateColorMap(ushort[] seperationCharIndexes, ushort rowLength, ushort fieldCutoff)
        {
            byte colorDepth = TextRowParent.ColorFieldCount;
            ColorMap colorMap = new ColorMap(rowLength, colorDepth);
            
            for(ushort i = 0; i < seperationCharIndexes.Length; i++)
            {
                if(i == seperationCharIndexes.Length-fieldCutoff)
                {
                    for (ushort j = seperationCharIndexes[i]; j < rowLength; j++)
                        colorMap.SetColor(j, TextRowParent.Colors.cutoffDataseperatorColor);
                    break;
                }

                if (seperationCharIndexes[i] == 0)
                    break;

                colorMap.SetColor(seperationCharIndexes[i]-1, TextRowParent.Colors.columnSeperatorColor);
            }

            return colorMap;
        }

        struct ColorMap
        {
            ushort[] colorCounts;
            byte[] map;

            public byte colorDepth
            {
                get
                {
                    return (byte) colorCounts.Length;
                }
            }

            public ColorMap(ushort length, byte colorDepth)
            {
                map = new byte[length];
                colorCounts = new ushort[colorDepth];
                colorCounts[0] = length;
            }

            public void SetColor(int index, TextRowParent.Colors color)
            {
                byte c = (byte)color;

                colorCounts[c]++;
                colorCounts[ map[index] ]--;
                map[index] = c;
            }

            public ushort GetColorCount(byte colorIndex)
            {
                return colorCounts[colorIndex];
            }

            public byte GetColorAt(ushort index)
            {
                return map[index];
            }

            public byte[] GetColorMap()
            {
                return map;
            }
        }

        struct GlyphRunConstructor
        {
            public const byte offsetX = 1;
            public const byte offsetY = 0;

            public int count;
            public double letterWidth;

            public ushort[] glyphIndices;
            public double[] advanceWidths;
            public Point[] glyphOffsets;

            public void Clear(double letterWidth, ushort maxIndices)
            {
                count = 0;
                this.letterWidth = letterWidth;
                glyphIndices = new ushort[maxIndices];
                glyphOffsets = new Point[maxIndices];
            }

            public void AddLetter(ushort glyphIndex, ushort index)
            {
                double x = index * letterWidth + offsetX;
                glyphIndices[count] = glyphIndex;
                glyphOffsets[count] = new Point(x,offsetY);
                count++;
            }

            public GlyphRun GetGlyphRun(double renderingEmSize, Point baselineOrigin, GlyphTypeface tf)
            {
                advanceWidths = new double[count];
                if(count > 0)
                    return new GlyphRun(tf, 0, false, renderingEmSize, glyphIndices, baselineOrigin, advanceWidths, glyphOffsets, null, null, null, null, null);
                return null;
            }
        }
    }
}
