using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DatasetAnalizer.Model
{
    public class CSVImport
    {
        public string fileName { get; private set; }
        Encoding encoding = new ASCIIEncoding();
        public PreviewData previewData { get; internal set; }
        public bool IsDatasetReady { get; internal set; }

        public CSVImport(string path)
        {
            IsDatasetReady = false;
            fileName = path.Split(new char[1] { '/' }).Last();
            Stream stream = new FileStream(path, FileMode.Open);

            byte[] rawData = new byte[stream.Length];
            List<PreviewData.Row> rows = new List<PreviewData.Row>();

            int d = stream.ReadByte();
            int rowIndex = 0;

            bool inRow = true;
            int rowStartIndex = 0;
            
            while (d != -1)
            {
                rawData[stream.Position] = (byte)d;
                if (d == 13 || d == 10)
                {
                    if (inRow)
                    {
                        inRow = false;
                        rows.Add(new PreviewData.Row(rowIndex, rowStartIndex, (int)stream.Position - 1));
                        rowIndex++;
                    }
                }
                else
                {
                    if (!inRow)
                    {
                        inRow = true;
                        rowStartIndex = (int)stream.Position;
                    }
                }

                d = stream.ReadByte();
            }

            if(inRow)
                rows.Add(new PreviewData.Row(rowIndex, rowStartIndex, (int)stream.Position));

            previewData = new PreviewData(rawData, rows.ToArray());
        }

        public void ApplyParameters(Parameters p)
        {
            IsDatasetReady = previewData.ApplyParameters(p);
        }

        public DataTable GetDataset()
        {
            if (!IsDatasetReady)
                return null;

            DataTable data = new DataTable();

            return data;
        }
        

        [System.Serializable]
        public struct Parameters 
        {
            public int name { get; set; }
            public ushort columnCount { get; set; }

            public int headerRowIndex { get; set; }
            public byte[] headerRowSeperator { get; set; }

            public byte[] dataSeperator { get; set; }

            public int skipFirstRows { get; set; }
            public int skipLastRows { get; set; }
        }

        public class PreviewData : PropertyChangedBase
        {
            public Row[] rows { get; internal set; }
            public byte[] rawText { get; internal set; }
            
            public Parameters parameters { get; internal set; }
            public int dataStartRow { get; internal set; }
            public int dataEndRow { get; internal set; }

            public int columnCount { get; internal set; }

            public PreviewData(byte[] rawText, Row[] rows)
            {
                this.rows = rows;
                this.rawText = rawText;
            }


            public bool ApplyParameters(Parameters p)
            {
                columnCount = p.columnCount;
                ushort[] seperationCharIndexes = new ushort[p.columnCount - 1];

                for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
                {
                    if (rowIndex < p.skipFirstRows)
                    {
                        rows[rowIndex]
                        continue;
                    }

                    if (rowIndex >= preview.Length - p.skipLastRows)
                    {
                        preview[rowIndex].SetAsText();
                        continue;
                    }

                    dataElementBuffer.Clear();

                    string[] objectData = new string[p.columnCount];
                    seperationCharIndexes = new ushort[p.columnCount - 1];

                    int dataElementIndex = 0;

                    string rowData = preview[rowIndex].RowData;

                    for (ushort indexInLine = 0; indexInLine < rowData.Length; indexInLine++)
                    {
                        char cb = rowData[indexInLine];

                        if (cb == p.dataSeperator[0])
                        {
                            if (dataElementIndex >= seperationCharIndexes.Length)
                            {
                                complication = new Complication.TooMuchData();
                                break;
                            }

                            //add the buffer as an element to Object
                            objectData[dataElementIndex] = dataElementBuffer.ToString();

                            seperationCharIndexes[dataElementIndex] = (ushort)(indexInLine + 1);

                            dataElementIndex++;
                            dataElementBuffer.Clear();

                            continue;
                        }

                        dataElementBuffer.Append(cb);
                    }

                    if (dataElementIndex < p.columnCount - 1)
                    {
                        complication = new Complication.TooFewData();
                    }

                    preview[rowIndex].SetAsObject(objectData, seperationCharIndexes, complication);
                }

                parameters = p;
                return true;
            }

            public class Row
            {
                public int index { get; internal set; }
                public int startIndex { get; internal set; }
                public int endIndex { get; internal set; }

                public Complication comp { get; internal set; }
                public int[] columnStartIndexes { get; internal set; }

                public Row(int index, int startIndex, int endIndex)
                {
                    this.index = index;
                    this.startIndex = startIndex;
                    this.endIndex = endIndex;
                }

                public enum Complication
                {
                    None,
                    TooViewColumns,
                    TooMuchColumns,
                }
            }
        }
    }
}
