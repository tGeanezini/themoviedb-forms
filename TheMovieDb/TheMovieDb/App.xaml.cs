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

            ConfigureMap();
        }

        void ConfigureMap ()
        {
            NavigationService.ConfigureMap<MainViewModel, MainPage>();
        }
    }
}
