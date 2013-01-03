using System;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Microsoft.Xna.Framework.GamerServices;
using Windows.Devices.Geolocation;
namespace Phone
{
    public class LocationService : ILocationService
    {
        private Position defaultPosition = new Position { Lat = 50, Long = 50 };
        public async Task<Position> GetLocation()
        {
            if (!Settings.AskedForPermission)
            {
                var asyncResult = Guide.BeginShowMessageBox("May I get your location from GPS?",
                                                            "This application uses your location (GPS) to get the most accurate weather reading",
                                                            new[] { "Allow", "Deny" }, 0, MessageBoxIcon.Alert, null, null);

                var allowed = await Task.Factory.FromAsync(asyncResult, r => Guide.EndShowMessageBox(r));
                Settings.AskedForPermission = true;
                Settings.AllowGPS = (allowed.Value != 1);
            }

            if (!Settings.AllowGPS)
                return defaultPosition;

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 50 };

            var result = new Position();
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(10));
                result.Lat = geoposition.Coordinate.Latitude;
                result.Long = geoposition.Coordinate.Longitude;
            }
            catch (Exception ex)
            {
                return defaultPosition;
            }

            return result;
        }
    }
}
