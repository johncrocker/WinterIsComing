using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Data.Models
{
    public class Book
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "pages")]
        public Int16 Pages { get; set; }

        [JsonProperty(PropertyName = "ISBN")]
        public string ISBN { get; set; }

        [JsonProperty(PropertyName = "releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(PropertyName = "authors")]
        public string[] Authors { get; set; }
    }
}
