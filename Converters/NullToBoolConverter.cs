using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDataSaving.Converters
{
    public class NullToBoolConverter
    {
        public bool Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => value != null;
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
