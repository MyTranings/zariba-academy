namespace _5._1.EventsDemo1
{
    using System;
    using System.Collections.Generic;

    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class ListWithChangedEvents
    {
        //Public event that clients can use to be notified of any change (event)
        public event ChangedEventHandler Changed;

        private List<int> myList = new List<int>();
        public int this[int index]
        {
            get
            {
                return myList[index];
            }
        }
        public int Count
        {
            get
            {
                return myList.Count;
            }
        }
        public void Add(int value)
        {
            this.myList.Add(value);
            //firing the event
            this.OnChanged();
        }

        private void OnChanged()
        {
            //if the delegate(event) has ANY method in it
            if (this.Changed!=null)
            {
                //Then execute
                this.Changed(this, EventArgs.Empty);
            }
        }
    }
}
