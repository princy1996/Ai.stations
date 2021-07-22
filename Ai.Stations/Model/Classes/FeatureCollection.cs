using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    public class FeatureCollection : IFeatureCollection
    {
        public CollectionType Type => CollectionType.FeatureCollection;
        public List<Feature> Features { get; set; }
    }
}
