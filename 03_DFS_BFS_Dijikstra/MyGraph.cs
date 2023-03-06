using System;
using System.Collections.Generic;
using System.Text;

namespace _03_DFS_BFS_Dijikstra
{
    class MyGraph
    {
        // adj & adj2 is same graph, but different expression 
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0},
            { 1, 0, 1, 1, 0, 0},
            { 0, 1, 0, 0, 0, 0},
            { 1, 1, 0, 0, 1, 0},
            { 0, 0, 0, 1, 0, 1},
            { 0, 0, 0, 0, 1, 0},
        };
        List<int>[] adj2 = new List<int>[]
        {
            new List<int>(){1, 3},
            new List<int>(){0, 2, 3},
            new List<int>(){1},
            new List<int>(){0, 1, 4},
            new List<int>(){3, 5},
            new List<int>(){4},
        };

        // adj3 has weight value at edge
        int[,] adj3 = new int[6, 6]
        {
            { 0, 15, 0, 35, 0, 0 },
            { 15, 0, 05, 10, 0, 0 },
            { 0, 05, 0, 0, 0, 0 },
            { 35, 10, 0, 0, 05, 0 },
            { 0, 0, 0, 05, 0, 05 },
            { 0, 0, 0, 0, 05, 0 },
        };

        bool[] visited = new bool[6]; //adj.getlength(0)

        public void DFS(int startPoint)
        {
            // Visit startPoint
            Console.WriteLine(startPoint);
            visited[startPoint] = true;

            // Check next-point is connected with startPoint, visit undiscovered point
            for (int next = 0; next < 6; next++)
            {
                // Check next-point is connected
                if (adj[startPoint, next] == 0) continue; 

                if (visited[next]) continue; // Check already visited

                DFS(next); // recursive function
            }
        }
        public void DFS2(int startPoint)
        {
            Console.WriteLine(startPoint);
            visited[startPoint] = true;

            foreach (int next in adj2[startPoint])
            {
                if (visited[next]) continue; // check already visited

                DFS2(next);
            }
        }
        public void SearchAll()
        {
            visited = new bool[6];

            for (int startPoint = 0; startPoint < 6; startPoint++)
            {
                if (visited[startPoint] == false)
                {
                    DFS(startPoint);
                }
            }
        }
        public void BFS(int startPoint)
        {
            bool[] reservedPoint = new bool[6];
            int[] parentPoint = new int[6];
            int[] distance = new int[6];

            Queue<int> q = new Queue<int>();
            q.Enqueue(startPoint);

            reservedPoint[startPoint] = true;
            parentPoint[startPoint] = startPoint;
            distance[startPoint] = 0;

            while (q.Count > 0)
            {
                int currentPoint = q.Dequeue();
                Console.WriteLine($"방문포인트:{currentPoint}, 부모포인트:{parentPoint[currentPoint]}, 거리: {distance[currentPoint]}");

                for (int nextPoint = 0; nextPoint < 6; nextPoint++)
                {
                    if (adj[currentPoint, nextPoint] == 0) continue;

                    if (reservedPoint[nextPoint]) continue;

                    q.Enqueue(nextPoint);

                    reservedPoint[nextPoint] = true;
                    parentPoint[nextPoint] = currentPoint;
                    distance[nextPoint] = distance[currentPoint] + 1;
                }
            }
        }
        public void Dijikstra(int startPoint)
        {
            bool[] reservedPoints = new bool[6];
            int[] parentPoints = new int[6];
            int[] distance = new int[6];

            // Make all components in distrance-array infinite
            Array.Fill(distance, Int32.MaxValue);

            distance[startPoint] = 0;
            parentPoints[startPoint] = startPoint;

            while (true)
            {
                int closest = Int32.MaxValue;
                int now = -1;

                // find the best candidate which has the shortest distance
                for (int i = 0; i < 6; i++)
                {
                    // check already reserved
                    if (reservedPoints[i]) continue;

                    // check if it's not reserved & farther than the existing candidate
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue;

                    // update info
                    closest = distance[i];
                    now = i;
                }

                if (now == -1) break; // Check there is no candidate

                reservedPoints[now] = true;

                // Reserve next point
                for (int next = 0; next < 6; next++)
                {
                    if (adj3[now, next] == 0) continue;

                    if (reservedPoints[next]) continue;

                    int nextDist = distance[now] + adj3[now, next];
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parentPoints[next] = now;
                    }
                }
            }
        }
    }
}
