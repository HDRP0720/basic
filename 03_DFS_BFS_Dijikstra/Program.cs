using System;

namespace _03_DFS_BFS_Dijikstra
{
    class Program
    {
        static void Main(string[] args)
        {
            MyGraph graph = new MyGraph();

            // graph.DFS(3);
            // graph.DFS2(3);
            // graph.SearchAll();
            // graph.BFS(3);
            graph.Dijikstra(0);
        }
    }
}
