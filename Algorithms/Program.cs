using System;
using System.Linq;
using Algorithms.TestCases;
using AlgorithmsLib.Queue;
using AlgorithmsLib.Sorting;
using static Algorithms.TestCases.QueueCases;
using static Algorithms.Utils;

namespace Algorithms
{
    class Program
    {
        private const int Iterations = 100_000;

        static void Main(string[] args)
        {
            CheckSorting();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("<< DONE >>");
            Console.ReadKey();
        }

        private static void CheckSorting()
        {
            Console.WriteLine("Test For Sorting SelectionSort: ");
            var probeForSelectionSort = Measure<(SortingMethod<int>, int[])>(
                SortingCases.RunSortDescendingArray,
                (SelectionSort.Sort, Enumerable.Range(1, Iterations).OrderByDescending(x => x).ToArray()));
            Console.WriteLine($"Time Elapsed: {probeForSelectionSort.Elapsed}");

            Console.WriteLine("Test For Sorting InsertionSort: ");
            var probeForInsertionSort = Measure<(SortingMethod<int>, int[])>(
                SortingCases.RunSortDescendingArray,
                (InsertionSort.Sort, Enumerable.Range(1, Iterations).OrderByDescending(x => x).ToArray()));
            Console.WriteLine($"Time Elapsed: {probeForInsertionSort.Elapsed}");
        }

        private static void CheckQueues()
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
                () =>
                {
                    var queue = new QueueLinkedList<int>();
                    foreach (var item in Enumerable.Range(1, Iterations)) queue.Enqueue(item);
                    return queue;
                });
            Console.WriteLine($"Time Elapsed: {probeForListIterator.Elapsed}");

            Console.WriteLine("Test For ArrayBasedQueue Iterator: ");
            var probeForArrayIterator = Measure<QueueProvider<int>>(
                RunIterator,
                () =>
                {
                    var queue = new ArrayBasedQueue<int>();
                    foreach (var item in Enumerable.Range(1, Iterations)) queue.Enqueue(item);
                    return queue;
                });
            Console.WriteLine($"Time Elapsed: {probeForArrayIterator.Elapsed}");
        }
    }
}