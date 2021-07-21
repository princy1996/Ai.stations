using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    interface IGeometry
    {
        CollectionType Type { get; } => CollectionType.Point;
        IEnumerable<float> Coordinates { get; }
    }
}
