using System;
using System.Globalization;
using System.Windows.Data;
using Common.WorldWeatherOnline;

namespace Phone
{
    public class ConditionToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((WeatherCondition)value)
            {
                case WeatherCondition.Cloudy:
                    return "`";
                case WeatherCondition.Drizzle:
                    return "3";
                case WeatherCondition.Foggy:
                    return "s";
                case WeatherCondition.Hail:
                    return "e";
                case WeatherCondition.Lightning:
                    return "z";
                case WeatherCondition.Rain:
                    return "9";
                case WeatherCondition.Snow:
                    return "]";
                case WeatherCondition.Sunny:
                    return "v";
                case WeatherCondition.Windy:
                    return "k";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}