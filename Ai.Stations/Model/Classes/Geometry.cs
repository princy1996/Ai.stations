using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    public class Geometry : IGeometry
    {
        CollectionType Type { get; set; }
        List<float> Coordinates { get; set; }
    }
}
