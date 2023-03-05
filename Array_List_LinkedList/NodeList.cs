using System;
using System.Collections.Generic;
using System.Text;

namespace Array_List_LinkedList
{
    // custom linked list
    class Node<T>
    {
        public T Data;
        public Node<T> Prev;
        public Node<T> Next;       
    }
    class NodeList<T>
    {
        public Node<T> First = null;
        public Node<T> Last = null;
        public int Count = 0;

        public Node<T> AddLast(T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = data;

            // If first node doesn't exist, add first node
            if(First == null)            
                First = newNode;            

            // If last node exist, connect last and node to add
            if (Last != null)
            {
                Last.Next = newNode;
                newNode.Prev = Last;
            }

            // admit new node to be a last node
            Last = newNode;
            Count++;

            return newNode;
        }

        public void Remove(Node<T> node)
        {
            // if node to remove is first
            if(First == node)            
                First = First.Next;            

            // if node to remove is last
            if (Last == node)            
                Last = Last.Prev;

            // if node to remove is in-between
            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;

            Count--;
        }
    }
}
