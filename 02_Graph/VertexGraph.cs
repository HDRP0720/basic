using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Graph
{
    // Directed-graph of vertex-edge 
    // type of creating instances
    class VertexGraph
    {
        public List<VertexGraph> vertex;
        public List<VertexGraph> edges = new List<VertexGraph>();

        public void CreateGraph()
        {
            vertex = new List<VertexGraph>(6)
            {
                new VertexGraph(),
                new VertexGraph(),
                new VertexGraph(),
                new VertexGraph(),
                new VertexGraph(),
                new VertexGraph(),
            };
            vertex[0].edges.Add(vertex[1]);
            vertex[0].edges.Add(vertex[3]);
            vertex[1].edges.Add(vertex[0]);
            vertex[1].edges.Add(vertex[2]);
            vertex[1].edges.Add(vertex[3]);
            vertex[3].edges.Add(vertex[4]);
            vertex[5].edges.Add(vertex[4]);
        }
    }
}
