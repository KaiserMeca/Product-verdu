using System.Globalization;

namespace Mvvm_Product.Converters
{
    public class NewProductConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value.ToString(),out DateTime date))
            {
                var today = DateTime.Now;
                var days = (today- date).TotalDays;
                return days > 7 ? 1 : 0;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
