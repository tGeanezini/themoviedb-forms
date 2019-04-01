using System.Collections.Generic;

namespace TheMovieDb
{
    public class GenreResponse
    {
        public IEnumerable<GenreItemResponse> Genres { get; set; }
    }
}
