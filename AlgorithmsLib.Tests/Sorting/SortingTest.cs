using System;
using System.Collections.Generic;
using AlgorithmsLib.Sorting;
using NUnit.Framework;
using static Algorithms.Utils;

namespace AlgorithmsLib.Tests.Sorting
{
    public abstract class SortingTest
    {
        protected  abstract SortingMethod<int> SortingMethod { get; }


        [Test]
        public void Should_sort_descending_order()
        {
            var descending = new[] { 5, 4, 3, 2, 1 };

            SortingMethod(descending);

            Assert.That(descending, expression: Is.Ordered.Ascending);
        }

        [Test]
        public void Should_do_nothing_When_collection_is_empty()
        {
            var empty = new List<int>();

            SortingMethod(empty);

            Assert.That(empty, expression: Is.Empty);
        }

        [Test]
        public void Should_do_nothing_When_collection_has_1_item()
        {
            var one = new List<int>() { 1 };

            SortingMethod(one);

            Assert.That(one, Is.EquivalentTo(expected: new List<int> { 1 }));
        }
    }


    public class SelectionSortTests : SortingTest
    {
        protected override SortingMethod<int> SortingMethod => SelectionSort.Sort;
    }

    public class InsertionSortTests : SortingTest
    {
        protected override SortingMethod<int> SortingMethod => InsertionSort.Sort;
    }
}