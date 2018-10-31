using System;
using C_Sharp_Challenge_Skeleton.Beans;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{



    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {
            int N = numOfNodes;

            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i <= numOfNodes + 21; i++)
            {
                adj.Add(new List<int>());
            }

            foreach (var item in edgeLists)
            {
                adj[item.EdgeA].Add(item.EdgeB);
                adj[item.EdgeB].Add(item.EdgeA);
            }

            bool[] visited = new bool[N + 1];

            for (int i = 1; i <= N; i++)
            {
                if (!visited[i])
                {
                    foreach (var item in adj[i])
                    {
                        if (!visited[item])
                        {
                            visited[i] = true;
                            visited[item] = true;
                            break;
                        }
                    }
                }
            }
            int min = 0;
            for (int i = 0; i < N; i++)
            {
                if (visited[i])
                {
                    min += 1;
                }
            }

            int cardX = numOfNodes - min;
            int cardY = min;

            if (cardY > cardX)
            {
                return 0;
            }

            return cardX - cardY;
        }
    }
}