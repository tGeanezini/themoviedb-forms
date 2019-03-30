using System.Threading.Tasks;
using Xamarin.Forms;

namespace TheMovieDb
{
    public class BaseViewModel : BindableObject
    {
        protected readonly INavigationService NavigationService;

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public BaseViewModel(string title)
        {
            Title = title;
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync()
        {
            return Task.FromResult(false);
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
