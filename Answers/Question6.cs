using System;
using System.Collections.Generic;

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
    }

    class DjikstraHeap
    {

        private Dictionary<int, int> totalCosts;
        private List<int> minHeap;
        private HashSet<int> visited;
        private Dictionary<int, List<Pair<int, int>>> neighbours;

        private int N;

        private int target;

        public DjikstraHeap(int numberOfServers, int targetServer, int[,] connectionTimes)
        {

            N = numberOfServers;
            target = targetServer;



            totalCosts = new Dictionary<int, int>();
            minHeap = new List<int>();
            visited = new HashSet<int>();
            neighbours = new Dictionary<int, List<Pair<int, int>>>();

            for (int i = 0; i < N; i++)
            {
                List<Pair<int, int>> nghb = new List<Pair<int, int>>();
                for (int ii = 0; ii < N; ii++)
                {
                    int distanceToIth = connectionTimes[i, ii];
                    if (i != ii)
                    {
                        nghb.Add(new Pair<int, int>(ii, distanceToIth));
                    }
                }
                neighbours.Add(i, nghb);
            }

        }

        //Actual Algorithm; the rest of the code in the class is just handling the min heap
        public int getShortestDistance(int start)
        {
            totalCosts.Add(start, 0);
            //adds start node to minHeap
            {
                minHeap.Add(start);
                int index = minHeap.Count - 1;
                while ((index - 1) / 2 >= 0 && totalCosts[(index - 1) / 2] > totalCosts[minHeap[index]])
                {

                    int aux = minHeap[index];
                    minHeap[index] = minHeap[(index - 1) / 2];
                    minHeap[(index - 1) / 2] = aux;
                    index = (index - 1) / 2;
                }
            }
            visited.Add(start);
            for (int i = 1; i < N; i++)
            {
                //if (i != start)
                //{
                totalCosts.Add(i, Int32.MaxValue);
                //}
            }

            while (this.minHeap.Count != 0)
            {
                //printDebugData();
                int newSmallest = 0;

                {
                    int item = minHeap[0];
                    minHeap[0] = minHeap[minHeap.Count - 1];
                    minHeap.RemoveAt(minHeap.Count - 1);
                    int index = 0;
                    while (index * 2 + 1 < minHeap.Count) //checks if node has left child
                    {
                        int smallerChildIndex = index * 2 + 1;
                        if (index * 2 + 2 < minHeap.Count && totalCosts[2 * index + 2] < totalCosts[2 * index + 1])
                        {
                            smallerChildIndex = 2 * index + 2;
                        }
                        if (totalCosts[minHeap[index]] < totalCosts[minHeap[smallerChildIndex]])
                        {
                            break;
                        }


                        int aux = minHeap[index];
                        minHeap[index] = minHeap[smallerChildIndex];
                        minHeap[smallerChildIndex] = aux;
                        index = smallerChildIndex;
                    }
                    newSmallest = item;
                }

                int nearest = 0;
                int minDistance = Int32.MaxValue;

                foreach (var node in neighbours[newSmallest])
                {
                    if (!visited.Contains(node.First))
                    {
                        int altCost = totalCosts[newSmallest] + node.Second;
                        if (altCost < totalCosts[node.First])
                        {
                            totalCosts[node.First] = altCost;
                        }
                        if (altCost < minDistance)
                        {
                            minDistance = altCost;
                            nearest = node.First;
                        }
                    }
                }
                visited.Add(nearest);
                //adds nearest node to minHeap
                {
                    minHeap.Add(nearest);
                    int index = minHeap.Count - 1;
                    while ((index - 1) / 2 >= 0 && totalCosts[(index - 1) / 2] > totalCosts[minHeap[index]])
                    {

                        int aux = minHeap[index];
                        minHeap[index] = minHeap[(index - 1) / 2];
                        minHeap[(index - 1) / 2] = aux;
                        index = (index - 1) / 2;
                    }
                }

                if (nearest == target)
                {
                    break;
                }

            }
            return totalCosts[target];
        }








        /*public void printDebugData()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Nearest: " + minHeap[0]);
            Console.Write("Visited: ");
            foreach (var item in visited)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("!!" + totalCosts.Count);
            foreach (var item in totalCosts)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

        }

        public void displayGraph()
        {
            Console.WriteLine("!!!!!");
            foreach (var item in neighbours)
            {
                foreach (Pair<int, int> ngh in item.Value)
                {
                    Console.WriteLine(item.Key + " " + ngh.First + " " + ngh.Second);
                }
            }
        }*/

    }

    public class Question6
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            DjikstraHeap dh = new DjikstraHeap(numOfServers, targetServer, connectionTimeMatrix);
            return dh.getShortestDistance(0);
        }
    }
}