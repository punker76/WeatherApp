using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Common.Models;

namespace Common
{
    public abstract class AbstractWeatherClient
    {
        public abstract Task<IList<Forecast>> GetForecast();

        public async Task<string> Get(string uri)
        {
            var c = (HttpWebRequest)HttpWebRequest.Create(uri);
            c.Method = "GET";

            var response = await c.GetResponseAsync();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string strContent = sr.ReadToEnd();
                return strContent;
            }
        }
    }
}