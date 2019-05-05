using static Algorithms.Utils;

namespace Algorithms.TestCases
{
    public class SortingCases
    {
        public static void RunSortDescendingArray((SortingMethod<int> sortingMethod, int[] descendingArray) opt) 
            => opt.sortingMethod(opt.descendingArray);
    }
}