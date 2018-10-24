using System;
using C_Sharp_Challenge_Skeleton.Beans;

namespace C_Sharp_Challenge_Skeleton.Answers
{

    class Solver
    {
        int MAXN = 31;

        private bool[,] gr;

        public Solver()
        {
            gr = new bool[MAXN, MAXN];
        }

        public void insertEdge(int edgeA, int edgeB)
        {
            gr[edgeA, edgeB] = true;
            gr[edgeB, edgeA] = true;
        }

        private bool isCover(int V, int k, int E)
        {
            int set = (1 << k) - 1;
            int limit = (1 << V);
            bool[,] vis = new bool[MAXN, MAXN];

            while (set < limit)
            {
                for (int i = 0; i < MAXN * MAXN; i++)
                {
                    vis[i % MAXN, i / MAXN] = false;
                }

                int cnt = 0;

                for (int j = 1, v = 1; j < limit; j = j << 1, v++)
                {
                    if ((set & j) != 0)
                    {
                        // Mark all edges emerging out of this 
                        // vertex visited 
                        for (int l = 1; l <= V; l++)
                        {
                            if (gr[v, l] && !vis[v, l])
                            {
                                vis[v, l] = true;
                                vis[l, v] = true;
                                cnt++;
                            }
                        }
                    }
                }

                if (cnt == E)
                {
                    return true;
                }
                int c = set & -set;
                int r = set + c;
                set = (((r ^ set) >> 2) / c) | r;

            }

            return false;
        }

        public int findMinCover(int n, int m)
        {
            // Binary search the answer 
            int left = 1, right = n;
            while (right > left)
            {
                int mid = (left + right) >> 1;
                if (isCover(n, mid, m) == false)
                    left = mid + 1;
                else
                    right = mid;
            }

            // at the end of while loop both left and 
            // right will be equal,/ as when they are 
            // not, the while loop won't exit the minimum 
            // size vertex cover = left = right 
            return left;
        }


    }


    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {

            Solver sv = new Solver();

            int numberOfEdges = 0;

            foreach (var item in edgeLists)
            {
                numberOfEdges += 1;
                sv.insertEdge(item.EdgeA, item.EdgeB);
            }

            int minCover = sv.findMinCover(numOfNodes, numberOfEdges);

            int result = numOfNodes - 2 * minCover;

            return result;
        }
    }
}