using Common.ViewModels;

namespace Phone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = new MainViewModel(new LocationService());
            DataContext = viewModel;
        }
    }
}