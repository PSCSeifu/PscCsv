using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types.Read
{
    public class CsvRow
    {
        private readonly List<CsvCol> _Cols;

        public CsvRow()
        {
            this._Cols = new List<CsvCol>();
        }

        public CsvCol GetCol(string header)
            => _Cols.Where(x => x.GetHeader() == header).SingleOrDefault() ?? new CsvCol();
        
        
        #region " NewRow "
        
        //public  CsvRow NewRow(string valueLine, string headerLine)
        //{
        //    var values = valueLine.Split(',').ToList();
        //    var headers = headerLine.Split(',').ToList();

        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        _Cols.Add(new CsvCol(headers[i], values[i]));
        //    }
        //    return this;
        //}

        public CsvRow NewRow(string valueLine, string headerLine)
            => NewRow(valueLine, headerLine, ',', char.MinValue);

        public CsvRow NewRow(string valueLine, string headerLine, char separator)
            => NewRow(valueLine, headerLine, separator, char.MinValue);

        public CsvRow NewRow(string valueLine, string headerLine, char separator, char quote)
        {
            if (string.IsNullOrEmpty(valueLine) && string.IsNullOrEmpty(headerLine))
                return new CsvRow();
            else
            {
                var rawValues = valueLine.Split(separator).ToList();
                var rawHeaders = headerLine.Split(separator).ToList();
               
                var headers = ((int)quote != 0) ?  RemoveQuote(rawHeaders, quote)  : rawHeaders;
                var values = ((int)quote != 0) ? RemoveQuote(rawValues, quote) : rawValues;
                                

                if (values.Count == headers.Count)
                {
                    for (int i = 0; i < values.Count; i++)
                    { _Cols.Add(new CsvCol(headers[i], values[i])); }
                    
                    return this;
                }               
                else if (values.Count < headers.Count)
                {
                    for (int i = 0; i < headers.Count; i++)
                    { _Cols.Add(new CsvCol(
                                headers[i],
                                (i >= values.Count()) ? "" : values[i]
                            ));
                    }
                    return this;
                }
                else
                {
                    throw new ArgumentException("More data values than headers");
                }
                //else
                //{
                //    for (int i = 0; i < values.Count; i++)
                //        _Cols.Add(new CsvCol(
                //                (i >= headers.Count()) ? "" : headers[i]
                //                , values[i]
                //            ));
                //}
            }
        }

        private List<string> RemoveQuote(List<string> list, char quote)
        {
            if (list == null || list.Count == 0)
                return list;
            else
            {
                List<string> dequotedList = new List<string>();
                foreach (var value in list)
                {
                    var dequotedItem = "";
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.Length > 3)
                        {
                            dequotedItem = ((int)value.First() == (int)quote) ?
                                dequotedItem = value.Substring(1, value.Length - 1) :
                                dequotedItem = value;

                            dequotedItem = ((int)value.Last() == (int)quote) ?
                                dequotedItem.Substring(0, value.Length - 2) :
                                dequotedItem = value;
                        }
                        else
                        {
                            if (value.Length == 1 && (int)value[0] == (int)quote)
                                dequotedItem = "";
                            if (value.Length == 2)
                                dequotedItem = ((int)value[0] == (int)quote && (int)value[1] == (int)quote) ?
                                     "" : value;
                        }
                    }
                    dequotedList.Add(dequotedItem);
                }
                return dequotedList;
            }
        }

        #endregion

        #region " To Line"

        public string ToLine(char separator, char quote)
            => ToLine(separator, quote, Environment.NewLine);

        public string ToLine(char separator)
            => ToLine(separator, char.MinValue, Environment.NewLine);

        public string ToLine()
            => ToLine(',', char.MinValue, Environment.NewLine);

        public string ToLine(char separator, char quote, string endOfLine)
        {
            if ((int)separator == 0) separator = ',';
            if ((int)quote == 0) quote = char.MinValue;
            if (string.IsNullOrEmpty(endOfLine)) endOfLine = Environment.NewLine;

            StringBuilder sb = new StringBuilder();
            foreach (var item in this._Cols)
            {
                sb.Append($"{quote}{item.GetValue()}{quote}{separator}");
            }
            sb.Append(endOfLine);

            return sb.ToString();
        }

        #endregion
    }


}
