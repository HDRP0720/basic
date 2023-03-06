using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Graph
{
    // Directed-graph
    // type of using list
    // it reduce burden of creating new instances; vertex-edge type
    // save memory, but lose access speed
    // Get advantage at a case of samll number of edges / lots of vertices
    class ListGraph
    {
        List<int>[] adjacent = new List<int>[6]
        {
            new List<int>{1, 3},
            new List<int>{0, 2, 3},
            new List<int>{ },
            new List<int>{ 4 },
            new List<int>{ },
            new List<int>{ 4 },
        };
    }
}
