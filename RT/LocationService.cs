using System;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace RT
{
    public class LocationService : ILocationService
    {
        private Position defaultPosition = new Position { Lat = 50, Long = 50 };
        public async Task<Position> GetLocation()
        {
            if (!Settings.AskedForPermission)
            {
                bool? r = null;
                var md = new MessageDialog("This application uses your location (GPS) to get the most accurate weather reading", "May I get your location from GPS?");
                md.Commands.Add(new UICommand("Allow", (cmd) => r = true));
                md.Commands.Add(new UICommand("Deny", (cmd) => r = false));
 
                await md.ShowAsync();
                Settings.AskedForPermission = true;
                Settings.AllowGPS = (bool)r;
            }

            if (!Settings.AllowGPS)
                return defaultPosition;

            var geolocator = new Geolocator { DesiredAccuracy = PositionAccuracy.Default };
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