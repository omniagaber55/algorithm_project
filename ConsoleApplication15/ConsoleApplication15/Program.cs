using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13
{
    class Program
    {

        class graph
        {
            class Edge : IComparable<Edge>
            {
                public int SRC, DST, W;
                public int CompareTo(Edge compareEdge)
                {
                    return this.W - compareEdge.W;
                }
            }
            public class subset
            {
                public int parent, rank;
            };

            int V, E;
            Edge[] edge;

            graph(int v, int e)
            {
                V = v;
                E = e;
                edge = new Edge[E];
                for (int i = 0; i < e; ++i)
                    edge[i] = new Edge();
            }
            int find(subset[] subsets, int i)
            {
                if (subsets[i].parent != i)
                    subsets[i].parent
                        = find(subsets, subsets[i].parent);

                return subsets[i].parent;
            }
            void Union(subset[] subsets, int x, int y)
            {
                int xroot = find(subsets, x);
                int yroot = find(subsets, y);
                if (subsets[xroot].rank < subsets[yroot].rank)
                    subsets[xroot].parent = yroot;
                else if (subsets[xroot].rank > subsets[yroot].rank)
                    subsets[yroot].parent = xroot;
                else
                {
                    subsets[yroot].parent = xroot;
                    subsets[xroot].rank++;
                }
            }
            void KMST()
            {
                Edge[] result = new Edge[V];
                int e = 0;
                int i
                    = 0;
                for (i = 0; i < V; ++i)
                    result[i] = new Edge();
                Array.Sort(edge);
                subset[] subsets = new subset[V];
                for (i = 0; i < V; ++i)
                    subsets[i] = new subset();
                for (int v = 0; v < V; ++v)
                {
                    subsets[v].parent = v;
                    subsets[v].rank = 0;
                }
                i = 0;
                while (e < V - 1)
                {
                    Edge next_edge = new Edge();
                    next_edge = edge[i++];
                    int x = find(subsets, next_edge.SRC);
                    int y = find(subsets, next_edge.DST);
                    if (x != y)
                    {
                        result[e++] = next_edge;
                        Union(subsets, x, y);
                    }
                }
                Console.WriteLine("Following are the edges in " + "the constructed MST");

                int minimumCost = 0;
                for (i = 0; i < e; ++i)
                {
                    Console.WriteLine("{" + result[i].SRC + "," + result[i].DST + "} =" + result[i].W);
                    minimumCost += result[i].W;
                }
                Console.WriteLine("Minimum cost spanning tree=" + minimumCost);
                Console.ReadLine();
            }
            public static void Main(String[] args)
            {
                Console.WriteLine("Enter the number of vertices ");
                int ver = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of edges");
                int ed = int.Parse(Console.ReadLine());
                graph graph = new graph(ver, ed);
                for (int i = 0; i < ed; i++)
                {
                    Console.WriteLine("Enter the source ");
                    graph.edge[i].SRC = int.Parse(Console.ReadLine()); ;
                    Console.WriteLine("Enter the destination");
                    graph.edge[i].DST = int.Parse(Console.ReadLine()); ;
                    Console.WriteLine("Enter the weight");
                    graph.edge[i].W = int.Parse(Console.ReadLine()); ;
                }
                graph.KMST();
            }
        }
    }
}
