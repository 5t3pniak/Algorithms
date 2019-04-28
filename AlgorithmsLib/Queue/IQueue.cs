using System.Collections.Generic;

namespace AlgorithmsLib.Queue
{
    public interface IQueue<TItem> : IEnumerable<TItem>
    {
        void Enqueue(TItem item);
        TItem Dequeue();
        (bool Success, TItem Item) TryDequeue();
        bool IsEmpty { get; }
        int Count { get; }
    }
}