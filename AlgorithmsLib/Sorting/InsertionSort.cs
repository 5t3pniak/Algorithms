using System.Collections.Generic;
using AlgorithmsLib.Utils;

namespace AlgorithmsLib.Sorting
{
    public class InsertionSort
    {
        public static IList<T> Sort<T>(IList<T> col) => NullGuard.Protect(SortHelper, col, Comparer<T>.Default);

        private static IList<T> Sort<T>(IList<T> col, IComparer<T> comparer) =>
            NullGuard.Protect(SortHelper, col, comparer);

        private static IList<T> SortHelper<T>(IList<T> col, IComparer<T> comparer)
        {
            for (int i = 0; i < col.Count; i++)
            {
                for (int j = i; j > 0 ; j--)
                {
                    if (comparer.Compare(col[j - 1], col[j]) > 0)
                        (col[j - 1], col[j]) = (col[j], col[j - 1]);
                    else
                        break;
                }
            }

            return col;
        }
    }
}