using Refit;
using System.Threading.Tasks;

namespace TheMovieDb
{
    [Headers("Content-Type: application/json")]
    public interface IApiRestful
    {
        [Get("/movie/upcoming?api_key={apiKey}&page={page}")]
        Task<MovieResponse> GetUpcomingMoviesAsync(string apiKey, int page);

        [Get("/genre/movie/list?api_key={apiKey}")]
        Task<GenreResponse> GetMovieGenresAsync(string apiKey);
    }
}
