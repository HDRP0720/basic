using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Graph
{
    // Directed-graph
    // type of using array   
    // memory consumption alot, but fast access speed
    // Get advantage at a case on lots of edges / small number of vertices
    class MatrixGraph
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0},
            { 1, 0, 1, 1, 0, 0},
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0},
        };
    }
}
