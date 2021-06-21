using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Planteskole.WPF.Converters
{
    class AddMeasureToVolumeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string returnString = null;
            double v = (double)value;
            //returnString = string.Format(v.ToString(new CultureInfo("en-us", false)) + " cm");
            returnString = string.Format("{0:F4}",  string.Concat(v.ToString(new CultureInfo("en-us", false)), " cm2"));
            return returnString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
