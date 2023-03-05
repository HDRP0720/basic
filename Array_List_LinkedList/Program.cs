using System;
using System.Collections.Generic;

namespace Array_List_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {        
            int[] _data = new int[5];
            MyList<int> _data2 = new MyList<int>();
            NodeList<int> _data3 = new NodeList<int>();

            #region example of usage
            _data3.AddLast(101);
            _data3.AddLast(102);
            Node<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
            #endregion
        }
    }
}
