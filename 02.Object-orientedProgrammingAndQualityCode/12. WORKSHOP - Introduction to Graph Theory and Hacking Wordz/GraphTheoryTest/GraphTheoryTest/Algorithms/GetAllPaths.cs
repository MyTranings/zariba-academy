namespace GraphTheoryTest.Algorithms
{
    using GraphTheoryTest.Model;
    using System.Collections.Generic;
    using System.Linq;
    public static class GetAllPaths<T>
    {
        private static List<VertexList<T>> allPathsWithStartVertex;
        private static VertexList<T> iteratorList;
        private static Dictionary<Vertex<T>,List<VertexList<T>>> allPaths;

        public static List<VertexList<T>> Compute( Graph<T> graph, Vertex<T> startingVertex)
        {
            iteratorList = new VertexList<T>();
            allPathsWithStartVertex = new List<VertexList<T>>();
            iteratorList.Add(startingVertex);
            DepthFirstSearch(startingVertex);
            return allPathsWithStartVertex
                .OrderBy(x => x.Count)
                .ToList();
        }
        public static Dictionary<Vertex<T>,List<VertexList<T>>> Compute(Graph<T> graph)
        {
            allPaths = new Dictionary<Vertex<T>,List<VertexList<T>>>();
            foreach (var vertex in graph)
            {
                allPaths.Add(vertex, Compute(graph, vertex));
            }

            return allPaths;
        }
        private static Vertex<T> DepthFirstSearch(Vertex<T> vertex)
        {
            foreach (var neighbour in vertex.Neighbours)
            {
                if (!iteratorList.Contains(neighbour))
                {
                    iteratorList.Add(neighbour);
                    DepthFirstSearch(neighbour);
                }
            }

            allPathsWithStartVertex.Add(iteratorList.Clone());
            iteratorList.RemoveAt(iteratorList.Count - 1);
            return vertex;
        }
    }
}
