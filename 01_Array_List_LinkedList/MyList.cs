using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Array_List_LinkedList
{
    // custom dynamic array
    public class MyList<T>
    {
        private const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0;
        public int Capacity { get { return _data.Length; } }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }

            _data[Count] = item;
            Count++;
        }

        // index
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count - 1] = default(T);
            Count--;
        }
    }
}
