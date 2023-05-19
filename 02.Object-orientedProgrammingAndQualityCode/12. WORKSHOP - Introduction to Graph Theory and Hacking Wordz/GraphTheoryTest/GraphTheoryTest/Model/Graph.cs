namespace GraphTheoryTest.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Graph<T> : IEnumerable<Vertex<T>>
    {
        private VertexList<T> vertexSet;

        public Graph() : this(null)
        {

        }

        public Graph(VertexList<T> vertexSet)
        {
            if (vertexSet == null)
            {
                this.vertexSet = new VertexList<T>();
            }
            else
            {
                this.vertexSet = vertexSet;
            }
        }

        public void AddVertex(Vertex<T> vertex)
        {
            for (int i = 0; i < this.vertexSet.Count; i++)
            {
                if (this.vertexSet[i].Value.Equals(vertex.Value))
                {
                    throw new InvalidOperationException("You cannot add vertices with the same value!");
                }
            }

            this.vertexSet.Add(vertex);
        }

        public void AddVertex(T value)
        {
            this.AddVertex(new Vertex<T>(value));
        }
        //TODO: check for repeated edges or undirected 0,1 1,0
        public void AddDirectedEdge(Vertex<T> from, Vertex<T> to, int weight = 0)
        {
            if (!this.vertexSet.Contains(from) || !this.vertexSet.Contains(to))
            {
                throw new InvalidOperationException("You cannot add an edge from/to non-existing vertex!");
            }

            from.Neighbours.Add(to);
            from.Weights.Add(weight);
        }

        public void AddDirectedEdge(T from, T to, int weight = 0)
        {
            Vertex<T> vFrom = this.vertexSet.FindByValue(from);
            Vertex<T> vTo = this.vertexSet.FindByValue(to);
            this.AddDirectedEdge(vFrom, vTo);
        }

        public void AddUndirectedEdge(Vertex<T> from, Vertex<T> to, int weight = 0)
        {
            this.AddDirectedEdge(from, to);
            this.AddDirectedEdge(to, from);
        }

        public void AddUndirectedEdge(T from, T to, int weight = 0)
        {
            this.AddDirectedEdge(from, to);
            this.AddDirectedEdge(to, from);
        }

        public VertexList<T> DFS(Vertex<T> startingVertex)
        {
            if (!this.vertexSet.Contains(startingVertex))
            {
                throw new InvalidOperationException("Your starting vertex is not a member of the graph.");
            }

            return Algorithms.DFS<T>.Compute(this, startingVertex);
        }

        public List<VertexList<T>> GetAllPaths(Vertex<T> startingVertex)
        {
            if (!this.vertexSet.Contains(startingVertex))
            {
                throw new InvalidOperationException("Your starting vertex is not a member of the graph.");
            }

            return Algorithms.GetAllPaths<T>.Compute(this, startingVertex);
        }

        public Dictionary<Vertex<T>, List<VertexList<T>>> GetAllPaths()
        {
            return Algorithms.GetAllPaths<T>.Compute(this);
        }
        public bool Contains(T value)
        {
            return this.vertexSet.FindByValue(value) != null;
        }
        public bool Contains(Vertex<T> vertex)
        {
            return this.vertexSet.Contains(vertex);
        }

        public bool RemoveVertex(Vertex<T> vertexToRemove)
        {
            if (vertexToRemove == null)
            {
                return false;
            }

            this.vertexSet.Remove(vertexToRemove);

            foreach (Vertex<T> gVertex in this.vertexSet)
            {
                int index = gVertex.Neighbours.IndexOf(vertexToRemove);
                if (index != -1)
                {
                    gVertex.Neighbours.RemoveAt(index);
                    gVertex.Weights.RemoveAt(index);
                }
            }
            return true;
        }

        public bool RemoveVertex(T value)
        {
            Vertex<T> vertexToRemove = this.vertexSet.FindByValue(value);
            return this.RemoveVertex(vertexToRemove);
            
        }
        

        public IEnumerator<Vertex<T>> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.vertexSet[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get { return this.vertexSet.Count; }
        }

        public VertexList<T> Vertices
        {
            get
            {
                return this.vertexSet;
            }
        }

        public Vertex<T> this[int index]
        {
            get
            {
                return this.vertexSet[index];
            }
        }
    }
}
