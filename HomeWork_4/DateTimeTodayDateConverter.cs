using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HomeWork_4
{
    public class DateTimeTodayDateConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object paremeter, CultureInfo cultureInfo)
        {
            var d = value as DateTime?;
            if (d != null)
            {
                return DateTime.Today == d.Value;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object paremeter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
