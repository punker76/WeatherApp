using System;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Windows.Devices.Geolocation;

namespace RT
{
    public class LocationService : ILocationService
    {
        public async Task<Position> GetLocation()
        {
            var geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.Default;
            var result = new Position();
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(10));

                result.Lat = geoposition.Coordinate.Latitude;
                result.Long = geoposition.Coordinate.Longitude;
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    return null;
                }
                //else
                {
                    // something else happened acquring the location
                }
            }

            return result;
        }
    }
}