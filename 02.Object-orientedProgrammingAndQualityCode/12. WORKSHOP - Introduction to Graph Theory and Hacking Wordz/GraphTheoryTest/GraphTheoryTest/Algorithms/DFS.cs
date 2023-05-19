namespace GraphTheoryTest.Algorithms
{
    using GraphTheoryTest.Model;

    public static class DFS<T>
    {
        private static VertexList<T> dfsList;

        public static VertexList<T> Compute(Graph<T> graph, Vertex<T> startingVertex)
        {
            dfsList = new VertexList<T>();
            dfsList.Add(startingVertex);
            DepthFirstSearch(startingVertex);

            return dfsList;
        }

        private static Vertex<T> DepthFirstSearch(Vertex<T> vertex)
        {
            foreach (var neighbour in vertex.Neighbours)
            {
                if (!dfsList.Contains(neighbour))
                {
                    dfsList.Add(neighbour);
                    DepthFirstSearch(neighbour);
                }
            }

            return vertex;
        }
    }
}
