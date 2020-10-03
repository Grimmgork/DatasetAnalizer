using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DatasetAnalizer.Model
{
    public class CSVImport
    {
        RawDataset rawDataset;

        public CSVImport(string path)
        {

        }

        public void ApplyParameters(Parameters par)
        {

        }

        public struct Parameters
        {
            public int numberOfColumns;

            public int skipFirst;
            public int skipLast;

            public char fieldSeperator;
        }

        public class Structure
        {
            public string name;
        }


        public class Field 
        {
            string text;

            public string GetName()
            {
                throw new NotImplementedException();
            }

            public string GetText()
            {
                return text;
            }
        }

        public class NumericField : Field
        {
            public float value;

            public NumericField()
            {

            }

            public string GetName()
            {
                throw new NotImplementedException();
            }

            public float GetNumber()
            {
                return 0f;
            }

            public static bool CheckData(string text)
            {
                return true;
            }
        }


        public class RawDataset
        {
            byte[] text;

            int startIndex;
            int endIndex;

            RawRecord[] records;

            public int GetFieldEndIndex(int row, int field)
            {
                return 0;
            }

            public byte GetDataPoint(int index)
            {
                return text[index];
            }

            public RawRecord[] GetRecords()
            {
                return records;

            }

            public IEnumerable<byte> GetField(int recordIndex, int fieldIndex)
            {
                return null;
            }

            public IEnumerable<byte> GetRow(int index)
            {
                return null;
            }
        }

        public struct RawRecord 
        {
            public int[] fieldEndIndexes;

            public RawRecord(int[] fieldEndIndexes)
            {
                this.fieldEndIndexes = fieldEndIndexes;
            }
        }

        public DataTable ExportData()
        {
            return new DataTable();
        }

        public RawDataset GetRawData()
        {
            return rawDataset;
        }
    }
}
