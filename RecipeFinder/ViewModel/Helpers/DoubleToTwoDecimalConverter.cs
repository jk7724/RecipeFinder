using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RecipeFinder.ViewModel.Helpers
{
    public class DoubleToTwoDecimalConverter : IValueConverter
    {

        // A class that implements IValueConverter for converting double values to strings with two decimal places
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is double doubleValue)
            {
                // Convert the double to a string with two decimal places
                return doubleValue.ToString("F2");
            }
            return value;
        }

        // Converts a string with two decimal places back to a double value
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the input value is a string and try to parse it as a double
            if (value is string stringValue && double.TryParse(stringValue, out double result))
            {
                return result;
            }
            return value;
        }
    }
}
