using System.Linq;
using static Algorithms.Utils;

namespace Algorithms.TestCases
{
    public class QueueCases
    {
        public static void RunEnqueueAndDequeue((QueueProvider<int> getQueue, int howMany) opt)
        {
            var queue = opt.getQueue();
            foreach (var num in Enumerable.Range(1, opt.howMany))
            {
                queue.Enqueue(num);
            }


            foreach (var _ in Enumerable.Range(1, opt.howMany))
            {
                queue.Dequeue();
            }
        }

        public static void RunIterator(QueueProvider<int> getFullQueue)
        {
            var queue = getFullQueue();
            foreach (var _ in queue)
            {
            }
        }
    }
}