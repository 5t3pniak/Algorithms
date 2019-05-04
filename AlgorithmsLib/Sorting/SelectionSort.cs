using System;
using System.Collections.Generic;
using AlgorithmsLib.Utils;

namespace AlgorithmsLib.Sorting
{
    public class SelectionSort
    {
        public static IList<T> Sort<T>(IList<T> col) => NullGuard.Protect(SortHelper, col, Comparer<T>.Default);

        private static IList<T> Sort<T>(IList<T> col, IComparer<T> comparer) =>
            NullGuard.Protect(SortHelper, col, comparer);

        private static IList<T> SortHelper<T>(IList<T> col, IComparer<T> comparer)
        {
            for (int i = 0; i < col.Count; i++)
            {
                var min = i;
                for (int j = i + 1; j < col.Count; j++)
                {
                    if (comparer.Compare(col[j - 1], col[j]) > 0) min = j;
                }

                (col[i], col[min]) = (col[min], col[i]);
            }

            return col;
        }
    }
}