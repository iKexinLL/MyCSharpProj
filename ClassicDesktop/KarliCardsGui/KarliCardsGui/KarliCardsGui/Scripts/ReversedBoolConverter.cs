using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarliCardsGui
{
    [ValueConversion(typeof(bool), typeof(bool))]
    class ReversedBoolConverter : IValueConverter
    {
        // 真假转换
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && !(bool) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && !(bool) value;
        }
    }
}
