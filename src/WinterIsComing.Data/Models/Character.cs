using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Data.Models
{
    public class Character
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "aliases")]
        public IEnumerable<string> Aliases { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "playedBy")]
        public IEnumerable<string> PlayedBy { get; set; }

        [JsonProperty(PropertyName = "titles")]
        public IEnumerable<string> Titles { get; set; }
    }
}
