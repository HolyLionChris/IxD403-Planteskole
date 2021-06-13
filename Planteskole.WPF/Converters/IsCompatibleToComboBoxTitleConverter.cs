using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Planteskole.WPF.Converters
{
    class IsCompatibleToComboBoxTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ComboBoxTitle = null;

            switch (value) 
            {
                case true:
                    ComboBoxTitle = "Compatible Locations:";
                    break;
                case false:
                    ComboBoxTitle = "Non-compatible Locations:";
                    break;
                default:
                    break;
            }

            return ComboBoxTitle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
