using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Common.ViewModels;
using Common.WorldWeatherOnline.Models;
using Newtonsoft.Json;

namespace Common.WorldWeatherOnline
{
    public class WWOClient : AbstractWeatherClient
    {
        private readonly string _apikey;
        private readonly string baseUrl = @"http://free.worldweatheronline.com/feed/weather.ashx?q={0}&format=json&num_of_days=2&key={1}";

        public WWOClient(string apikey)
        {
            _apikey = apikey;
        }

        public override async Task<IList<Forecast>> GetForecast(Position p)
        {
            List<Forecast> forecasts = new List<Forecast>();

            var result = JsonConvert.DeserializeObject<RootObject>(await Get(string.Format(baseUrl, (p.Lat.ToString("0.00") + "," + p.Long.ToString("0.00")), _apikey)));
            foreach (var d in result.data.weather)
            {
                forecasts.Add(new Forecast
                            {
                                MaxTemp = double.Parse(d.tempMaxC),
                                MinTemp = double.Parse(d.tempMinC),
                                Condition = WeatherCodeToState(d.weatherCode)
                            }
                );
            }

            return forecasts;
        }

        private static WeatherCondition WeatherCodeToState(string code)
        {
            switch (code)
            {
                case "113":
                    return WeatherCondition.Sunny;

                case "116":
                case "119":
                case "122":
                    return WeatherCondition.Cloudy;

                case "143":
                case "248":
                case "260":
                    return WeatherCondition.Foggy;

                case "176":
                case "263":
                case "266":
                case "281":
                case "284":
                    return WeatherCondition.Drizzle;

                case "293":
                case "296":
                case "299":
                case "302":
                case "305":
                case "308":
                case "311":
                case "314":
                case "353":
                case "356":
                case "359":
                case "365":
                case "371":
                    return WeatherCondition.Rain;

                case "179":
                case "182":
                case "185":
                case "227":
                case "230":
                case "317":
                case "320":
                case "323":
                case "326":
                case "329":
                case "332":
                case "335":
                case "338":
                case "350":
                case "368":
                case "362":

                    return WeatherCondition.Snow;

                case "200":
                case "386":
                case "389":
                case "392":
                case "395":
                    return WeatherCondition.Lightning;

                case "377":
                case "374":
                    return WeatherCondition.Hail;
            }

            return 0;
        }
    }
}
