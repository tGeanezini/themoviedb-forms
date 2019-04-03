using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMovieDb
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieWrapper>> GetMoviesAsync(int page);
    }

    public class MovieService : IMovieService
    {
        IApiRestful Api => RestService.For<IApiRestful>(ConstantsHelper.UrlBase);

        public async Task<IEnumerable<MovieWrapper>> GetMoviesAsync(int page)
        {
            try
            {
                var moviesResult = await Api.GetUpcomingMoviesAsync(ConstantsHelper.ApiKey, page);
                var genresResult = await Api.GetMovieGenresAsync(ConstantsHelper.ApiKey);

                if (moviesResult != null)
                {
                    var movies = new List<MovieWrapper>();

                    moviesResult.Results.ToList().ForEach(m => movies.Add(ToMovieWrapper(m, genresResult.Genres)));                    

                    return movies;
                }
            }
            catch (Exception ex)
            {
                var e = ex;
                return null;
            }

            return null;
        }

        MovieWrapper ToMovieWrapper(MovieItemResponse movie, IEnumerable<GenreItemResponse> genres)
        {
            var movieGenres = new List<string>();

            foreach (var genre in movie.GenreIds)
            {
                var movieGenre = genres.FirstOrDefault(g => g.Id == genre).Name;
                if (!string.IsNullOrEmpty(movieGenre))
                    movieGenres.Add(movieGenre);
            }

            return new MovieWrapper
            {
                Title = movie.Title,
                PosterPath = $"{ConstantsHelper.ImageUrl}{movie.PosterPath}",
                BackdropPath = $"{ConstantsHelper.ImageUrl}{movie.BackdropPath}",
                Overview = movie.Overview,
                ReleaseDate = DateTimeOffset.Parse(movie.ReleaseDate).ToString("dd/MM/yyyy"),
                Genres = string.Join(", ", movieGenres)
            };
        }
            

}    
}
