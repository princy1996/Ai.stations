using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ai.Stations.Model
{
    interface IProperties
    {
        string Description { get; }
        [JsonProperty(PropertyName = "Marker-Symbol")]
        string MarkerSymbol { get; }
        string Title { get; } 
        string Url { get; }
        List<LineType> Lines { get; }
    }
}
