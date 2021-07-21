using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    interface IFeatureCollection
    {
        CollectionType Type { get; } => CollectionType.FeatureCollection;
        List<Feature> Features { get; }
    }
}
