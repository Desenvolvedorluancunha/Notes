using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Search
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("imdbID")]
        public string imdbID { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }
    }
}
