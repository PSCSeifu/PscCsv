using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvLine
    {
        
        private readonly List<string> _Items;

        public CsvLine()
        {
            this._Items = new List<string>();
        }

        internal string GetItem(int index)
        {
            return _Items[index];
        }

        internal List<string> ToItems()
        {
            List<string> items = new List<string>();

            foreach (var item in this._Items)
            {
                items.Add(item);
            }

            return items;
        }

    }
}
