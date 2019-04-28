using System;
using System.Diagnostics;
using AlgorithmsLib.Queue;

namespace Algorithms.utils
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
    }
}