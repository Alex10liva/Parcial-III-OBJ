using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_3
{
    public class Model
    {
        public Vertex[] vertices;
        public Triangle[] triangles;

        public Model(Vertex[] vertices, Triangle[] triangles)
        {
            this.vertices = vertices;
            this.triangles = triangles;
        }

    }
}
