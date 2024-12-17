using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec11_DrawGraph
{
    public class Graph
    {
        public List<Vertex> Vertices { get; }
        public List<Edge> Edges { get; }
        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        internal void AddVertex(Point location)
        {
            Vertices.Add(new Vertex(location));
        }
        internal void RemoveVertex(Vertex v)
        {
            Edges.RemoveAll(e => e.V1 == v || e.V2 == v);
            Vertices.Remove(v);
        }
        public void AddEdge(Vertex v1, Vertex v2)
        {
            Edges.Add(new Edge(v1, v2));
        }

        public class Vertex
        {
            public char Id { get; }
            public Point Location { get; set; }

            private static int counter = 0;

            public Vertex(Point location)
            {
                Location = location;

                Id = (char)((int)'A' + counter);
                counter++;
            }

            internal double Distance(Point location)
            {
                return Math.Sqrt(Math.Pow(this.Location.X - location.X, 2) +
                                 Math.Pow(this.Location.Y - location.Y, 2));
            }
        }

        public class Edge
        {
            public Vertex V1 { get; }
            public Vertex V2 { get; }
            public Edge(Vertex v1, Vertex v2)
            {
                this.V1 = v1;
                this.V2 = v2;
            }
        }
    }
}
