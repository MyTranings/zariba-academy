namespace GenericsIndexersAndOperators
{
    using System;
    public class MyList<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] items;
        public MyList()
        {
            this.Capacity = INITIAL_CAPACITY;
            this.Count = 0;
            this.items = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; } // Do some validation here

        public void Add(T item)
        {
            // Check the size
            // If the size overflows, copy array with double capacity
            this.items[this.Count] = item;
            this.Count++;
        }

        public override string ToString()
        {
            // Fix it!
            return string.Join(", ", this.items);
        }

        public static MyList<T> operator +(MyList<T> list1, MyList<T> list2)
        {
            MyList<T> result = new MyList<T>();

            if (list1.Count != list2.Count)
            {
                throw new InvalidOperationException("You cannot add lists of different length!");
            }

            for (int i = 0; i < list1.Count; i++)
            {
                // []
                // Operator.Add
                result[i] = (dynamic)list1[i] + (dynamic)list2[i];
            }

            return result;
        }

        public T this[int index]
        { 
            get 
            {
                return this.items[index];
            }

            set 
            {
                // validate 
                this.items[index] = value;
            }
        }
    }
}
