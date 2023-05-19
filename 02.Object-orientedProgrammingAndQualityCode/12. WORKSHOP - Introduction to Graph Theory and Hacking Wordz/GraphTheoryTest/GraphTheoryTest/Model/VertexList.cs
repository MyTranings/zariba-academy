namespace GraphTheoryTest.Model
{
    using System;
    using System.Collections.ObjectModel;

    public class VertexList<T> : Collection<Vertex<T>>,ICloneable
    {
        public VertexList() : base()
        {
        }

        public VertexList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Vertex<T>));
            }
        }

        public object Select { get; internal set; }

        public VertexList<T> Clone()
        {
            VertexList<T> newList = new VertexList<T>();
            for (int i = 0; i < this.Count; i++)
            {
                newList.Add(this[i]);
            }
            return newList;
        }

        public Vertex<T> FindByValue(T value)
        {
            foreach (Vertex<T> vertex in this.Items)
            {
                if (vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
