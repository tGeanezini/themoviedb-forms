using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheMovieDb
{
    [Headers("Content-Type: application/json")]
    public interface IApiRestful
    {
        [Get("/movie/upcoming?api_key={apiKey}")]
        Task<IEnumerable<MovieResponse>> GetUpcomingMoviesAsync(string apiKey);

        [Get("/genre/movie/list?api_key={apiKey}")]
        Task<GenreResponse> GetMovieGenresAsync(string apiKey);
    }
}
