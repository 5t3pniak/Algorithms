using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsLib.Queue
{
    public class ArrayBasedQueue<TItem> : IQueue<TItem>
    {
        private TItem[] _array;
        private int _head;
        private int _tail;
        private int Capacity = 2;

        public ArrayBasedQueue()
        {
            _array = new TItem[Capacity + 1];
            _head = 0;
            _tail = 0;
        }


        public void Enqueue(TItem item)
        {
            if (Count == Capacity)
                ResizeArray(_array, 2, Capacity);


            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
        }

        private void ResizeArray(TItem[] array, double factor, int newTail)
        {
            var dstArray = new TItem[(int) (Capacity * factor) + 1];
            for (int curSrc = _head, curDst = 0;
                curSrc != _tail;
                curSrc = (curSrc + 1) % _array.Length, curDst++)
            {
                dstArray[curDst] = array[curSrc];
            }

            _head = 0;
            _tail = newTail;
            Capacity = dstArray.Length - 1;
            _array = dstArray;
        }

        public TItem Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            if (Count < _array.Length / 4)
                ResizeArray(_array, 0.5, Count);

            var toReturn = _array[_head];
            _array[_head] = default;
            _head = (_head + 1) % _array.Length;

            return toReturn;
        }


        public (bool Success, TItem Item) TryDequeue()
        {
            if (IsEmpty)
                return (Success: false, Item: default);

            if (Count < _array.Length / 4)
                ResizeArray(_array, 0.5, Count);

            var toReturn = _array[_head];
            _array[_head] = default;
            _head = (_head + 1) % _array.Length;

            return (Success: true, toReturn);
        }

        public bool IsEmpty => _head == _tail;

        public int Count => (_tail - _head + _array.Length) % _array.Length;

        public IEnumerator<TItem> GetEnumerator()
        {
            var current = _head;
            while (current < _tail)
            {
                yield return _array[current];
                current++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}