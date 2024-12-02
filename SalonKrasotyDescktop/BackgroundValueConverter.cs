using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SalonKrasotyDescktop
{
    public class BackgroundValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double && (double)value > 0)
            {
                return Brushes.LightGreen;
            }

            if (value is double && (double)value == 0)
            {
                return Brushes.White;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}