using System;
using Callisto.Controls;
using Common.ViewModels;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace RT
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = new MainViewModel(new LocationService());
            DataContext = viewModel;
        }

        private void MainPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            SettingsCommand cmd = new SettingsCommand("settings", "Settings", (x) =>
            {
                SettingsFlyout settings = new SettingsFlyout
                    {
                        HeaderBrush = new SolidColorBrush(Colors.Orange),
                        HeaderText = "Weather Settings",
                        ContentBackgroundBrush = new SolidColorBrush(Colors.Black)
                    };
                BitmapImage bmp = new BitmapImage(new Uri("ms-appx:///Assets/SmallLogo.png"));
                settings.SmallLogoImageSource = bmp;
                settings.Content = new SettingsUserControl();
                settings.IsOpen = true;
            });

            args.Request.ApplicationCommands.Add(cmd);
        }
    }
}
