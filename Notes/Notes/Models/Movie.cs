using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Movie
    {
        [JsonProperty("Title")]
        public string TITLE { get; set; }

        [JsonProperty("Year")]
        public string RELEASE_YEAR { get; set; }

        [JsonProperty("Poster")]
        public string IMAGEMS_URL { get; set; }

        [JsonProperty("type")]
        public string SUMARY { get; set; }
    }
}
