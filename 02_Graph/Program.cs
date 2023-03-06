using System;
using System.Collections.Generic;

namespace _02_Graph
{   
    class Program
    {
        static void Main(string[] args)
        {
            VertexGraph vg = new VertexGraph();
            vg.CreateGraph();

            ListGraph lg = new ListGraph();
            MatrixGraph mg = new MatrixGraph();
        }
    }
}
