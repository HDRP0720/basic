using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _05_PriorityQueue
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T data)
        {
            // Insert data at the end of heap array
            _heap.Add(data);

            int currentIndex = _heap.Count - 1;
            while (currentIndex > 0)
            {                
                // Check next value is greater than current value
                int nextIndex = (currentIndex - 1) / 2;
                if (_heap[currentIndex].CompareTo(_heap[nextIndex]) < 0 ) break;

                // Swap current and next value
                T temp = _heap[currentIndex];
                _heap[currentIndex] = _heap[nextIndex];
                _heap[nextIndex] = temp;

                currentIndex = nextIndex;
            }
        }
        public T Pop()
        {
            // Set the return value
            T ret = _heap[0];
            
            // Move last value of the tree to the top
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int currentIndex = 0;
            while (true)
            {
                int leftIndex = 2 * currentIndex + 1;
                int rightIndex = 2 * currentIndex + 2;

                int nextIndex = currentIndex;

                // Check teh lower left value is greater than the next value -> move to the lower left
                if (leftIndex <= lastIndex && _heap[nextIndex].CompareTo(_heap[leftIndex]) < 0 )
                    nextIndex = leftIndex;

                // Check teh lower right value is greater than the next value -> move to the lower right
                if (rightIndex <= lastIndex && _heap[nextIndex].CompareTo(_heap[rightIndex]) < 0 )
                    nextIndex = rightIndex;

                // Check the current value is greater than lower left/right values
                if (nextIndex == currentIndex) break;

                // Swap current and next value
                T temp = _heap[currentIndex];
                _heap[currentIndex] = _heap[nextIndex];
                _heap[nextIndex] = temp;

                currentIndex = nextIndex;
            }

            return ret;
        }
        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int ID { get; set; }

        public int CompareTo(Knight other)
        {
            if (ID == other.ID) return 0;

            return ID > other.ID ? 1 : -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> q = new PriorityQueue<int>();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);
            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }

            PriorityQueue<Knight> qKnight = new PriorityQueue<Knight>();
            qKnight.Push(new Knight() { ID = 20 });
            qKnight.Push(new Knight() { ID = 30 });
            qKnight.Push(new Knight() { ID = 40 });
            qKnight.Push(new Knight() { ID = 10 });
            qKnight.Push(new Knight() { ID = 05 });
            while (qKnight.Count() > 0)
            {
                Console.WriteLine(qKnight.Pop().ID);
            }
        }
    }
}
