using System.Threading.Tasks;

namespace TheMovieDb
{
    public class DetailViewModel : BaseViewModel
    {
        string _movieTitle;
        public string MovieTitle {
            get { return _movieTitle; }
            set { _movieTitle = value; OnPropertyChanged(); }
        }

        string _posterImage;
        public string PosterImage
        {
            get { return _posterImage; }
            set { _posterImage = value; OnPropertyChanged(); }
        }

        string _genre;
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; OnPropertyChanged(); }
        }

        string _overview;
        public string Overview
        {
            get { return _overview; }
            set { _overview = value; OnPropertyChanged(); }
        }

        string _releaseDate;
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; OnPropertyChanged(); }
        }

        public DetailViewModel() : base(Resource.MovieDetailsTitle)
        {
        }

        public override async Task InitializeAsync(object navigationData)
        {
            var movieWrapper = (navigationData as MovieWrapper);

            MovieTitle = movieWrapper.Title;
            PosterImage = movieWrapper.BackdropPath;
            Genre = movieWrapper.Genres;
            Overview = movieWrapper.Overview;
            ReleaseDate = movieWrapper.ReleaseDate;

            await base.InitializeAsync(navigationData);
        }        
    }
}
