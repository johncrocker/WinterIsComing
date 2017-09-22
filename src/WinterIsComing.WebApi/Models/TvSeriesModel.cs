using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WinterIsComing.Data.Models;

namespace WinterIsComing.WebApi.Models
{
    /// <summary>
    /// Represents a Television Season
    /// </summary>
    public class TvSeriesModel
    {
        /// <summary>
        /// Television Season Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public static TvSeriesModel CopyFrom(TvSeries series)
        {
            return new TvSeriesModel()
            {
                Name = series.Name
            };
        }
    }
}