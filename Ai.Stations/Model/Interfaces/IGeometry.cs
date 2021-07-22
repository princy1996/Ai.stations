using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    interface IGeometry
    {
        CollectionType Type { get; }
        List<float> Coordinates { get; }
    }
}
