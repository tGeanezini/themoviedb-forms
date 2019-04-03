using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheMovieDb
{
    public class MovieResponse
    {
        public int Page { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        public DatesResponse Dates { get; set; }
        public IEnumerable<MovieItemResponse> Results { get; set; }
    }
}
