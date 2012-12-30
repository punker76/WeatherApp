using Common.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace RT
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = new MainViewModel();
            DataContext = viewModel;
        }
    }
}
