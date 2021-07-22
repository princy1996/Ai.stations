using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    interface IFeature
    {
        Geometry Geometry { get; }
        CollectionType Type { get; }
        Properties Properties { get; }
        string Address { get; }
    }
}
