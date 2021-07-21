using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    public class Feature : IFeature
    {
        public Geometry Geometry { get; set; }
        public CollectionType Type { get; set; } = CollectionType.Feature;
        public Properties Properties { get; set; }
        public string Address { get; set; }
    }
}
