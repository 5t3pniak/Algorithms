using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AlgorithmsLib.Utils;

namespace AlgorithmsLib.Sorting
{
    public class ShellSort
    {
        public static IList<T> Sort<T>(IList<T> col) => NullGuard.Protect(SortHelper, col, Comparer<T>.Default, ProduceSimpleDivisionSeq(col.Count));

        private static IList<T> Sort<T>(IList<T> col, IComparer<T> comparer, IReadOnlyCollection<int> divisionSeq) =>
            NullGuard.Protect(SortHelper, col, comparer, divisionSeq);

        private static IList<T> SortHelper<T>(IList<T> col, IComparer<T> comparer, IEnumerable<int> divisionSeq)
        {
            int N = col.Count;

            foreach (var h in divisionSeq)
            {
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h && comparer.Compare(col[j-h], col[j]) > 0; j-=h)
                    {
                        (col[j - h], col[j]) = (col[j], col[j - h]);
                    }
                }
            }
            return col;
        }

        public static IEnumerable<int> ProduceSimpleDivisionSeq(int maxCount)
        {
            int h = 1;
            while (h < maxCount / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                yield return h;
                h /= 3;
            }
        }
            
    }
}