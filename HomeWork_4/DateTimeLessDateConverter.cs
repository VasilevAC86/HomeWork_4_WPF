using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace HomeWork_4
{
    public class DateTimeLessDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object paremeter, CultureInfo cultureInfo)
        {
            var d = value as DateTime?;
            if (d != null)
            {
                return DateTime.Now > d.Value;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object paremeter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
