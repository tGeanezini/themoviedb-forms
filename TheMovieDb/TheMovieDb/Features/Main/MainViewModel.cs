using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TheMovieDb
{
    public class MainViewModel : BaseViewModel
    {
        readonly IMovieService _movieService;

        public ICommand ItemClickedCommand { get; }

        public ObservableCollection<MovieWrapper> Items { get; }

        bool _dataLoaded;
        public bool DataLoaded
        {
            get { return _dataLoaded; }
            set { _dataLoaded = value; OnPropertyChanged(); }
        }

        public MainViewModel(IMovieService movieService) : base(Resource.UpcomingMoviesTitle)
        {
            _movieService = movieService;

            ItemClickedCommand = new Command<MovieWrapper>(async (item) => await ItemClickedCommandExecuteAsync(item));
            Items = new ObservableCollection<MovieWrapper>();
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            DataLoaded = false;

            var movies = await _movieService.GetMoviesAsync();
            Items.Clear();
            movies.ToList().ForEach(m => Items.Add(m));

            DataLoaded = true;
        }

        async Task ItemClickedCommandExecuteAsync(MovieWrapper movie)
        {
            await NavigationService.NavigateToAsync<DetailViewModel>(movie);
        }
    }
}
