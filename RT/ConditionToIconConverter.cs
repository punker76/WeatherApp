using System;
using Common.WorldWeatherOnline;
using Windows.UI.Xaml.Data;

namespace RT
{
    public class ConditionToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
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

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}