using System.Collections.Generic;
using AlgorithmsLib.Sorting;
using NUnit.Framework;

namespace AlgorithmsLib.Tests.Sorting
{
    public class SortingTest
    {
        [Test]
        public void Should_sort_descending_order()
        {
            var descending = new[] { 5, 4, 3, 2, 1 };

            SelectionSort.Sort(descending);

            Assert.That(descending, expression: Is.Ordered.Ascending);
        }

        [Test]
        public void Should_do_nothing_When_collection_is_empty()
        {
            var empty = new List<int>();

            SelectionSort.Sort(empty);

            Assert.That(empty, expression: Is.Empty);
        }

        [Test]
        public void Should_do_nothing_When_collection_has_1_item()
        {
            var one = new List<int>() { 1 };

            SelectionSort.Sort(one);

            Assert.That(one, Is.EquivalentTo(expected: new List<int> { 1 }));
        }
    }
}