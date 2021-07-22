using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    public enum CollectionType
    {
        [Description("Feature Collection")]
        FeatureCollection,
        Point,
        Feature
    }
}
