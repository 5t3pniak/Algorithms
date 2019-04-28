using System;
using System.Linq;
using AlgorithmsLib.Queue;
using static Algorithms.TestCases.QueueCases;
using static Algorithms.utils.Utils;

namespace Algorithms
{
    class Program
    {
        private const int Iterations = 100_000_000;

        static void Main(string[] args)
        {
            Console.WriteLine("Test For LinkedListQueue: ");
            var probeForList = Measure<(QueueProvider<int>, int)>(
                RunEnqueueAndDequeue,
                (() => new QueueLinkedList<int>(), Iterations));
            Console.WriteLine($"Time Elapsed: {probeForList.Elapsed}");

            Console.WriteLine("Test For ArrayBasedQueue: ");
            var probeForArray = Measure<(QueueProvider<int>, int)>(
                RunEnqueueAndDequeue,
                (() => new ArrayBasedQueue<int>(), Iterations));
            Console.WriteLine($"Time Elapsed: {probeForArray.Elapsed}");

            Console.WriteLine("Test For LinkedListQueue Iterator: ");
            var probeForListIterator = Measure<QueueProvider<int>>(
                RunIterator,
                () => {
                    var queue = new QueueLinkedList<int>();
                    foreach (var item in Enumerable.Range(1, Iterations)) queue.Enqueue(item);
                    return queue;
                });
            Console.WriteLine($"Time Elapsed: {probeForListIterator.Elapsed}");

            Console.WriteLine("Test For ArrayBasedQueue Iterator: ");
            var probeForArrayIterator = Measure<QueueProvider<int>>(
                RunIterator,
                () => {
                    var queue = new ArrayBasedQueue<int>();
                    foreach (var item in Enumerable.Range(1, Iterations)) queue.Enqueue(item);
                    return queue;
                });
            Console.WriteLine($"Time Elapsed: {probeForArrayIterator.Elapsed}");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("<< DONE >>");
            Console.ReadKey();
        }
    }
}