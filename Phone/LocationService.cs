using System;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Windows.Devices.Geolocation;

namespace Phone
{
    public class LocationService : ILocationService
    {
        public async Task<Position> GetLocation()
        {
            var geolocator = new Geolocator
                {
                    DesiredAccuracyInMeters = 50
                };

            var result = new Position();
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(10));
                result.Lat = geoposition.Coordinate.Latitude;
                result.Long = geoposition.Coordinate.Longitude;
            }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }
    }
}
