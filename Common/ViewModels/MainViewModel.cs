using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Common.Annotations;
using Common.Models;
using Common.WorldWeatherOnline;

namespace Common.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ILocationService _gps;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Forecast Today
        {
            get { return _today; }
            set
            {
                _today = value;
                OnPropertyChanged();
            }
        }

        public Forecast Tomorrow
        {
            get { return _tomorrow; }
            set
            {
                _tomorrow = value;
                OnPropertyChanged();
            }
        }

        private WWOClient client;
        private Forecast _today;
        private Forecast _tomorrow;

        public string Location { get; set; }
        public MainViewModel(ILocationService gps)
        {
            _gps = gps;
            Location = "MELBOURNE, AUSTRALIA";
            client = new WWOClient("your-api-key");
            LoadData();
        }

        public async Task LoadData()
        {
            var results = await client.GetForecast(await _gps.GetLocation());
            Today = results[0];
            Tomorrow = results[1];
        }
    }
}
