using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsLib.Queue
{
    public class QueueLinkedList<TItem> : IQueue<TItem>
    {
        private class Node
        {
            public TItem _item;
            public Node _next;
        }

        private Node _head;
        private Node _tail;

        public QueueLinkedList()
        {
            Count = 0;
            _head = _tail = new Node();
        }

        public void Enqueue(TItem item)
        {
            var newNode = new Node {_item = item};
            _tail._next = newNode;
            _tail = newNode;
            Count++;
        }

        public TItem Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            _head = _head._next;
            Count--;
            return _head._item;
        }


        public (bool Success, TItem Item) TryDequeue()
        {
            if (IsEmpty)
                return (Success: false, Item: default);

            _head = _head._next;
            Count--;
            return (true, _head._item);
        }

        public bool IsEmpty => _head == _tail;

        public int Count { get; private set; }


        public IEnumerator<TItem> GetEnumerator()
        {
            var curNode = _head;
            while (curNode != _tail)
            {
                curNode = curNode._next;
                yield return curNode._item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}