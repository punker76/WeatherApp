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
        public MainViewModel()
        {
            Location = "MELBOURNE, AUSTRALIA";
            client = new WorldWeatherOnline.WWOClient("your-api-key");
            LoadData();
        }

        public async Task LoadData()
        {
            var results = await client.GetForecast();
            Today = results[0];
            Tomorrow = results[1];
        }
    }
}
