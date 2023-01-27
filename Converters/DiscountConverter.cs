using System.Globalization;

namespace Mvvm_Product.Converters
{
    public class DiscountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float.TryParse(value.ToString(), out float discount);
            return discount > 0 ? 1 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
