using System.Collections.Generic;

namespace Common.WorldWeatherOnline.Models
{
    public class Data
    {
        public List<CurrentCondition> current_condition { get; set; }
        public List<Request> request { get; set; }
        public List<Weather> weather { get; set; }
    }
}