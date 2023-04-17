using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_3
{
    public class Plane
    {
        public Vertex normal;
        private float distance;

        public float Distance
        {
            get { return distance; }
        }

        public Plane(Vertex normal, float distance)
        {
            this.normal = normal;
            this.distance = distance;
        }
    }
}
