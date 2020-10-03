using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatasetAnalizer.Model
{
    public class TextfileImport
    {
        public string fileName { get; private set; }
        public RowPreviewContainer[] preview { get; private set; }

        Encoding encoding = new ASCIIEncoding();

        public TextfileImport(string path)
        {
            fileName = path.Split(new char[1] { '/' }).Last();
            Stream stream = new FileStream(path, FileMode.Open);

            List<RowPreviewContainer> rows = new List<RowPreviewContainer>();

            List<byte> buffer = new List<byte>();

            int d = 0;
            while (d != -1)
            {
                d = stream.ReadByte();
                if (d == 13 || d == 10)
                {
                    rows.Add(new RowPreviewContainer(rows.Count, encoding.GetString(buffer.ToArray())));
                    buffer.Clear();

                    d = stream.ReadByte();
                    if (d != 10)
                        stream.Position--;

                    continue;
                }

                buffer.Add((byte)d);
            }

            if(buffer.Count > 0)
                rows.Add(new RowPreviewContainer(rows.Count, encoding.GetString(buffer.ToArray())));

            preview = rows.ToArray();
        }

        public int columnCount { get; private set; }

        public void ApplyParameters(Parameters p)
        {
            columnCount = p.columnCount;

            ushort[] seperationCharIndexes = new ushort[p.columnCount - 1];

            StringBuilder dataElementBuffer = new StringBuilder();

            for (int rowIndex = 0; rowIndex < preview.Length; rowIndex++)
            {
                Complication complication = null;

                if (rowIndex < p.skipFirstRows)
                {
                    preview[rowIndex].SetAsText();
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
                        
                        seperationCharIndexes[dataElementIndex] = (ushort)(indexInLine+1);

                        dataElementIndex++;
                        dataElementBuffer.Clear();

                        continue;
                    }

                    dataElementBuffer.Append(cb);
                }

                if (dataElementIndex < p.columnCount-1){
                    complication = new Complication.TooFewData();
                }

                preview[rowIndex].SetAsObject(objectData, seperationCharIndexes, complication);
            }
        }

        public DataTable GetData()
        {
            DataTable data = new DataTable();

            for (int i = 0; i < columnCount; i++)
            {
                data.Columns.Add(new DataColumn());
            }

            for(int i = 0; i < preview.Length; i++)
            {
                RowPreviewContainer c = preview[i];
                if(c.IsObject)
                {
                    data.Rows.Add(c.objectData);
                }
            }

            return data;
        }

        [System.Serializable]
        public struct Parameters : IConversionParameters
        {
            public int name { get; set; }
            public ushort columnCount { get; set; }

            public byte[] dataSeperator { get; set; }
            public byte[] objectSeperator { get; set; }

            public int skipFirstRows { get; set; }
            public int skipLastRows { get; set; }
        }
    }

    public interface IConversionParameters
    {
        public int name { get; set; }
        public ushort columnCount { get; set; }
    }
}
