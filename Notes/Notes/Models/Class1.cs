using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Class1
    {
        [JsonProperty("Search")]
        public List<Search> Search { get; set; }

        [JsonProperty("totalResults")]
        public int totalResults { get; set; }

        [JsonProperty("Response")]
        public bool Response { get; set; }
    }
}
