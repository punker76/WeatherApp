using System.Collections.Generic;

namespace Common.WorldWeatherOnline.Models
{
    public class Weather
    {
        public string date { get; set; }
        public string precipMM { get; set; }
        public string tempMaxC { get; set; }
        public string tempMaxF { get; set; }
        public string tempMinC { get; set; }
        public string tempMinF { get; set; }
        public string weatherCode { get; set; }
        public List<WeatherDesc2> weatherDesc { get; set; }
        public List<WeatherIconUrl2> weatherIconUrl { get; set; }
        public string winddir16Point { get; set; }
        public string winddirDegree { get; set; }
        public string winddirection { get; set; }
        public string windspeedKmph { get; set; }
        public string windspeedMiles { get; set; }
    }
}