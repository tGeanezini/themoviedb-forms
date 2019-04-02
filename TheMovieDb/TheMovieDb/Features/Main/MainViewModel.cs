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
        public ICommand LoadMoreMoviesCommand { get; }

        public ObservableCollection<MovieWrapper> Items { get; }

        protected int Page { get; private set; }

        bool hasMoviesToLoad = true;


        bool _pageLoaded;
        public bool PageLoaded
        {
            get { return _pageLoaded; }
            set { _pageLoaded = value; OnPropertyChanged(); }
        }

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
            LoadMoreMoviesCommand = new Command(async () => await LoadMoreMoviesAsync());

            Items = new ObservableCollection<MovieWrapper>();

            Page = 1;

            PageLoaded = false;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if(hasMoviesToLoad)
            {              
                var movies = await _movieService.GetMoviesAsync(Page);

                movies.ToList().ForEach(m => Items.Add(m));

                hasMoviesToLoad = movies.Any();

                PageLoaded = true;
                DataLoaded = true;

                Page++;
            }
            
        }

        async Task ItemClickedCommandExecuteAsync(MovieWrapper movie)
        {
            await NavigationService.NavigateToAsync<DetailViewModel>(movie);
        }

        async Task LoadMoreMoviesAsync() => await InitializeAsync();
    }
}
