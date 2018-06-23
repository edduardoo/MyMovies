using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Models
{
    public class SearchResult
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Movie> Movies { get; set; }

    }
}
