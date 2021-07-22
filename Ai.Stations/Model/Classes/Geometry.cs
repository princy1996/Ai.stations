using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ai.Stations.Model
{
    public class Geometry : IGeometry
    {
        public CollectionType Type => CollectionType.Point;
        public List<float> Coordinates { get; set; }
    }
}
