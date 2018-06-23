using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Models
{
    public class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public string VoteAverage { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterUrl { get; set; }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BannerUrl { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Description { get; set; }

        public string Year {
            get { return Date.Substring(0, 4); }
        }
        
    }
}
