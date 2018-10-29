using System;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{

    public class Question6
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            int[][] times = new int[numOfServers][];
            for (int i = 0; i < numOfServers; i++)
            {
                times[i] = new int[numOfServers];
                for (int j = 0; j < numOfServers; j++)
                {
                    times[i][j] = connectionTimeMatrix[i, j];
                }
            }
            Graph gr = new Graph(numOfServers, targetServer, times);
            return gr.getShortestDistance(0);
        }
    }

    class Graph
    {
        private int V;
        private int[][] graph;
        private int target;

        public Graph(int V, int target, int[][] times)
        {
            this.V = V;

            this.target = target;

            this.graph = times;
        }



        public int getShortestDistance(int src)
        {
            int[] dist = new int[V];

            bool[] frontier = new bool[V];


            for (int i = 0; i < V; i++)
            {
                dist[i] = Int32.MaxValue;
                frontier[i] = false;
            }


            // Distance of source vertex from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {

                int u = -1;

                int min = Int32.MaxValue;
                int min_index = -1;

                for (int v = 0; v < V; v++)
                {
                    if (!frontier[v] && dist[v] <= min)
                    {
                        min = dist[v];
                        min_index = v;
                    }
                }

                u = min_index;





                frontier[u] = true;


                for (int v = 0; v < V; v++)
                {

                    if (!frontier[v] && graph[u][v] != 0 && dist[u] != Int32.MaxValue
                                      && dist[u] + graph[u][v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u][v];
                    }
                }



            }

            // print the constructed distance array 
            return dist[target];
        }
    }
}