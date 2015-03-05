using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomHexFormatProvider
{
    /// <summary>
    /// hex(Hex) - is special string for use hex format of this provider
    /// hex - lowercase
    /// Hex - uppercase
    /// </summary>
    public class HexFormat : IFormatProvider, ICustomFormatter
    {
        #region fields
        IFormatProvider parentFormat;

        char[] highSymbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        char[] lowSymbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        const int valueBase = 16;
        #endregion

        #region constructors
        public HexFormat():this(CultureInfo.CurrentCulture) { }
        public HexFormat(Int64 g) : this(CultureInfo.CurrentCulture) { }
        public HexFormat(IFormatProvider format)
        {
            parentFormat = format;
        }
        #endregion

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        string ICustomFormatter.Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Если это не наша форматная строка, передать ее родительскому поставщику:
            if (arg == null || (format != "hex" && format != "Hex"))
                return string.Format(parentFormat, "{0:" + format + "}", arg);

            string value = string.Format(CultureInfo.InvariantCulture, "{0}", arg);
            Int64 hexValue;
            bool success = Int64.TryParse(value,out hexValue);
            if (success == false)
            {
                return value;
            }
            
            bool negative=false;

            if (hexValue < 0)
            {
                negative = true;
                hexValue = -hexValue;
            }

            StringBuilder sb = new StringBuilder();

            var symbols = (format != "hex") ? highSymbols : lowSymbols;

            do
            {
                sb.Insert(0, symbols[hexValue % valueBase]);
                hexValue /= valueBase;
            } while (hexValue > 0);

            if (negative) sb.Insert(0,"-");

            return sb.ToString();
        }

        //if we want to create method like standard hex format method
        //string ICustomFormatter.Format(...
        private string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Если это не наша форматная строка, передать ее родительскому поставщику:
            if (arg == null || (format != "hex" && format != "Hex"))
                return string.Format(parentFormat, "{0:" + format + "}", arg);

            string value = string.Format(CultureInfo.InvariantCulture, "{0}", arg);
            Int64 hexValue;
            bool success = Int64.TryParse(value, out hexValue);
            if (success == false)
            {
                return value;
            }

            StringBuilder sb = new StringBuilder();

            var symbols = (format != "hex") ? highSymbols : lowSymbols;

            int calc = 0;
            do
            {
                sb.Insert(0, symbols[hexValue & 0xF]);
                hexValue >>= 4;
                calc++;
            } while (calc < 16 && hexValue != 0);

            return sb.ToString();
        }
    }
}
