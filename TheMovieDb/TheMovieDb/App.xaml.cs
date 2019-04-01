using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TheMovieDb
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterTypes();
            ConfigureMap();
            InitializeAsync();
        }

        void RegisterTypes()
        {
            ViewModelLocator.Instance.Register<INavigationService, NavigationService>();
            ViewModelLocator.Instance.Register<IMovieService, MovieService>();

            ViewModelLocator.Instance.Register<MainViewModel>();
            ViewModelLocator.Instance.Register<DetailViewModel>();

            ViewModelLocator.Instance.Build();
        }

        void ConfigureMap ()
        {
            NavigationService.ConfigureMap<MainViewModel, MainPage>();
            NavigationService.ConfigureMap<DetailViewModel, DetailPage>();
        }

        async void InitializeAsync() =>
            await ViewModelLocator.Instance.Resolve<INavigationService>().NavigateToAsync<MainViewModel>();
    }
}
