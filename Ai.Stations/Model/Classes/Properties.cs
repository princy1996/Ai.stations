using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ai.Stations.Model
{
    public class Properties : IProperties
    {
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Marker-Symbol")]
        public string MarkerSymbol { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<LineType> Lines { get; set; }
    }
}
