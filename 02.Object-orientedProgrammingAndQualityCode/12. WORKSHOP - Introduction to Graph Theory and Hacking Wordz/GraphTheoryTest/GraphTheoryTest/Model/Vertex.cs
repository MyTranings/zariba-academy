namespace GraphTheoryTest.Model
{
    using System.Collections.Generic;

    public class Vertex<T>
    {
        private List<int> weights;
        private T data;
        private VertexList<T> neighbours;

        public Vertex()
        {
        }

        public Vertex(T value):this(value,new VertexList<T>())
        {
        }

        public Vertex(T value, VertexList<T> neighbours)
        {
            this.data = value;
            this.neighbours = neighbours;
        }

        public T Value
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public VertexList<T> Neighbours
        {
            get
            {
                return this.neighbours;
            }
            set
            {
                this.neighbours = value;
            }
        }

        public List<int> Weights
        {
            get
            {
                if (this.weights == null)
                {
                    this.weights = new List<int>();
                }
                return this.weights;
            }
        }
    }
}
