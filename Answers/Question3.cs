using System;
using C_Sharp_Challenge_Skeleton.Beans;

namespace C_Sharp_Challenge_Skeleton.Answers
{

    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    class Solver
    {
        int MAXN = 31;

        private int N;

        private int M;

        private bool[][] gr;

        private int[] vc;

        List<List<int>> adj;

        public Solver(int N)
        {
            gr = new bool[MAXN][];

            this.N = N;
            this.M = M;

            for (int i = 0; i < MAXN; i++)
            {
                gr[i] = new bool[MAXN];
            }

            adj = new List<List<int>>();
            for (int i = 0; i <= N; i++)
            {
                adj.Add(new List<int>());
            }

            vc = new int[N + 1];

        }

        public void setNumberOfEdges(int M)
        {
            this.M = M;
        }

        public void insertEdge(int edgeA, int edgeB)
        {
            gr[edgeA][edgeB] = true;
            gr[edgeB][edgeA] = true;
        }

        public void addEdge(Edge ed)
        {
            adj[ed.EdgeA].Add(ed.EdgeB);
            adj[ed.EdgeB].Add(ed.EdgeA);
        }

        public void printEdges()
        {
            foreach (var row in adj)
            {
                foreach (var item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        public int findMinCover()
        {
            if (isTree())
            {
                return getMinCoverTree(1, -1);
            }
            else if (isBipartite())
            {
                return getMinCoverBipartite();

            }
            else if (N < 32)
            {
                return findMinCoverGospelHack32();
            }
            else
            {

            }
            return -1;
        }

        public int findMinCoverGospelHack32()
        {
            // Binary search the answer 
            int left = 1, right = N;
            while (right > left)
            {
                int mid = (left + right) >> 1;
                bool isCover = false;
                {
                    int V = this.N;
                    int k = mid;
                    int E = this.M;

                    int set = (1 << k) - 1;
                    int limit = (1 << V);
                    bool[][] vis = new bool[MAXN][];

                    while (set < limit)
                    {
                        for (int i = 0; i < MAXN; i++)
                        {
                            for (int j = 0; j < MAXN; j++)
                            {
                                vis[i] = new bool[MAXN];
                                vis[i][j] = false;
                            }

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
                                    if (gr[v][l] && !vis[v][l])
                                    {
                                        vis[v][l] = true;
                                        vis[l][v] = true;
                                        cnt++;
                                    }
                                }
                            }
                        }

                        if (cnt == E)
                        {
                            isCover = true;
                            break;
                        }
                        int c = set & -set;
                        int r = set + c;
                        set = (((r ^ set) >> 2) / c) | r;

                    }
                }

                if (isCover == false)
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


        public bool isTree()
        {
            bool[] visited = new bool[N + 1];

            Stack<Pair<int, int>> st = new Stack<Pair<int, int>>();

            st.Push(new Pair<int, int>(1, -1));

            while (st.Count != 0)
            {
                var current = st.Pop();
                int currentNode = current.First;
                int parrent = current.Second;

                visited[currentNode] = true;

                foreach (var item in adj[currentNode])
                {
                    if (!visited[item])
                    {
                        st.Push(new Pair<int, int>(item, currentNode));
                    }
                    else if (item != parrent)
                    {

                        return false; //is circular
                    }
                }
            }


            for (int i = 1; i <= N; i++)
            {
                if (!visited[i])
                {

                    return false;
                }
            }

            return true;
        }

        private bool isBipartite()
        {
            return false;
        }

        int getMinCoverTree(int node, int parrent)
        {
            if (adj[node].Count == 1)
            {
                return 0;
            }

            if (vc[node] != 0)
            {
                return vc[node];
            }

            int sizeIncl = 1;
            int sizeExl = 0;



            foreach (int item in adj[node])
            {
                if (item != parrent)
                {
                    sizeIncl += getMinCoverTree(item, node);

                }
            }


            foreach (int item in adj[node])
            {
                if (item != parrent)
                {
                    sizeExl += 1;
                    foreach (int itemChild in adj[item])
                    {
                        if (itemChild != node)
                        {
                            sizeExl += getMinCoverTree(itemChild, item);

                        }
                    }
                }
            }



            vc[node] = Math.Min(sizeIncl, sizeExl);




            return vc[node];
        }

        int getMinCoverBipartite()
        {
            return 0;
        }

    }





    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {

            Solver sv = new Solver(numOfNodes);

            int numberOfEdges = 0;

            foreach (var item in edgeLists)
            {
                numberOfEdges += 1;
                sv.insertEdge(item.EdgeA, item.EdgeB);
                sv.addEdge(item);
            }

            sv.setNumberOfEdges(numOfNodes);



            int minCover = sv.findMinCover();

            int cardY = minCover;
            int cardX = numOfNodes - cardY;

            if (cardX < cardY)
            {
                return 0;
            }

            return cardX - cardY;
        }
    }
}