using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvRow
    {
        private readonly List<string> _Items;

        public CsvRow()
        {
            this._Items = new List<string>();
        }

        #region " Write "
        
        public void AddItem(string item)
        {
            _Items.Add(item);
        }

        internal string ToLine()
        {
            var line = "";
            foreach (var item in this._Items)
            {
                line += $"{item},";
            }
            line += Environment.NewLine;
            return line;
        }

        #endregion

        #region "  Read "
        
        public string GetItem(int index)
        {
            if (_Items.Count > index)
                return _Items[index];
            return null;
        }        

        internal void ToItems(string data)
        {
            data.Split(',')
                .ToList()
                .ForEach(item => AddItem(item));
        }

        #endregion
    }
}
