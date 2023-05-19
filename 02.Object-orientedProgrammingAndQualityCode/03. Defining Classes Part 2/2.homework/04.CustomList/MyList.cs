namespace CustomList
{
    using System;

    public class MyList<T> : ICloneable
    {
        private const int INITIAL_CAPCITY = 4;
        private T[] items;
        private int capacity;

        public MyList()
        {
            this.Capacity = INITIAL_CAPCITY;
            this.Count = 0;
            this.items = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The capacity of the list must be positive number");
                }

                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("There is no element with that index!");
                }

                this.items[index] = value;
            }
        }

        public void Remove(int index)
        {
            if (index > 0 && this.Count >= this.items.Length)
            {
                throw new ArgumentOutOfRangeException("There is no element with that index!");
            }

            for (int i = index; i < this.Count; i++)
            {
                if (i + 1 <= this.Count)
                {
                    this.items[i] = this.items[i + 1];
                }
            }

            this.Count--;
        }

        public void InsertElement(int index, T val)
        {
            if (index < 0 && index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of rage!");
            }

            this.Add(this.items[this.Count]);

            for (int i = this.Count - 1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = val;
        }

        public void Add(T item)
        {
            if (this.Count >= this.items.Length)
            {
                this.items = this.Clone();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = (dynamic)0;
            }

            this.Count = 0;
        }

        public int FindIndex(dynamic val)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((dynamic)this.items[i] == val)
                {
                    return i;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            string arrayString = string.Empty;

            for (int i = 0; i < this.Count; i++)
            {
                arrayString += Convert.ToString(this.items[i]);

                if (i < this.Count - 1)
                {
                    arrayString += ", ";
                }
            }

            return arrayString;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        private T[] Clone()
        {
            this.Capacity *= 2;
            T[] newItems = new T[this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                newItems[i] = this.items[i];
            }

            return newItems;
        }
    }
}
