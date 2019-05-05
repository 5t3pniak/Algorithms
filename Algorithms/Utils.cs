using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlgorithmsLib.Queue;

namespace Algorithms
{
    public static class Utils
    {
        public static Stopwatch Measure<T>(Action<T> testCase, T setUp)
        {
            var timer = new Stopwatch();
            timer.Start();
            testCase(setUp);
            timer.Stop();
            return timer;
        }

        public delegate IQueue<TItem> QueueProvider<TItem>();

        public delegate IList<TItem> SortingMethod<TItem>(IList<TItem> indexedCollection);
    }
}