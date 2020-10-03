using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DatasetAnalizer.Model
{
    public class RowPreviewContainer : PropertyChangedBase
    {
        Complication _complication;
        Complication complication
        {
            get
            {
                return _complication;
            }
            set
            {
                _complication = value;
                OnPropertyChanged("complication");
            }
        }

        public bool HasComplication
        {
            get
            {
                return complication != null;
            }
        }

        public string ComplicationDescription
        {
            get
            {
                if (HasComplication)
                    return complication.Description;
                return "";

            }
        }

        bool _isObject;
        public bool IsObject
        {
            get
            {
                return _isObject;
            }
            set
            {
                _isObject = value;
                OnPropertyChanged("IsObject");
                OnPropertyChanged("This");
                OnPropertyChanged("TextData");
            }
        }

        public int rowIndex { get; private set; }
        public int rowNumber
        {
            get
            {
                return rowIndex + 1;
            }
        }

        string _rowData;
        public string RowData
        {
            get
            {
                return _rowData;
            }
            set
            {
                _rowData = value;
                OnPropertyChanged("TextData");
            }
        }

        public ushort[] seperationCharIndexes { get; private set; }
        public string[] objectData { get; private set; }

        public RowPreviewContainer This { get { return this; } }

        public RowPreviewContainer(int ri, string t)
        {
            rowIndex = ri;
            RowData = t;
            seperationCharIndexes = new ushort[0];
        }

        public void SetAsObject(string[] od, ushort[] csi, Complication comp)
        {
            IsObject = true;
            seperationCharIndexes = csi;
            objectData = od;
            complication = comp;
        }

        public void SetAsText()
        {
            IsObject = false;
            complication = null;
        }
    }

    public class Complication
    {
        string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {

            }
        }

        public class TooMuchData : Complication
        {
            public TooMuchData()
            {
                _description = "More data than Fields!";
            }
        }

        public class TooFewData : Complication
        {
            public TooFewData()
            {
                _description = "Less data than Fileds!";
            }
        }
    }
}
