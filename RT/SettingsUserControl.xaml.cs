using Windows.UI.Xaml;

namespace RT
{
    public sealed partial class SettingsUserControl
    {
        public SettingsUserControl()
        {
            InitializeComponent();
        }

        private void Gps_OnToggled(object sender, RoutedEventArgs e)
        {
            Settings.AllowGPS = gps.IsOn;
        }
    }
}
