using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Planteskole.Domain.Models;

namespace Planteskole.WPF.Converters
{
    class LocNameAreaNameToLocationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Location returnLocation = new Location();

            if(values[0] != null) returnLocation.LocationName = values[0].ToString();
            //returnLocation.Name = (string)values[1];
            if (values[1] != null) returnLocation.AreaName = values[1].ToString();

            return returnLocation;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            object[] returnArray = new object[3];

            Location loc = value as Location;
            if (loc != null)
            {
                if (loc.LocationName != null) returnArray[0] = loc.LocationName;
                //if(loc.Name != null) returnArray[1] = loc.Name;
                if (loc.AreaName != null) returnArray[1] = loc.AreaName;
            }

            return returnArray;
        }
    }
}
