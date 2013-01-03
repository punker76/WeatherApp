using Common.WorldWeatherOnline;

namespace Common.Models
{
    public class Forecast
    {
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }

        public WeatherCondition Condition { get; set; }
    }
}