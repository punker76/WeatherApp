using System.Windows;

namespace Phone
{
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Gps_OnChecked(object sender, RoutedEventArgs e)
        {
            Settings.AllowGPS = (bool)gps.IsChecked;
        }
    }
}