﻿using System;
using System.Linq;
using AlgorithmsLib.Queue;
using NUnit.Framework;

namespace AlgorithmsLib.Tests.Queue
{
    [TestFixture]
    public class QueueArrayBasedTests
    {
        [Test]
        public void SHOULD_be_empty_on_init()
        {
            var queue = new ArrayBasedQueue<int>();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0,queue.Count);
        }

        [Test]
        public void SHOULD_be_empty_WHEN_same_number_of_enqueues_and_dequeues_is_called()
        {
            var queue = new ArrayBasedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Count);
        }

        [Test]
        public void SHOULD_work_in_fifo_order()
        {
            var queue = new ArrayBasedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var dequeued1 = queue.Dequeue();
            var dequeued2 = queue.Dequeue();
            var dequeued3 = queue.Dequeue();
            
            Assert.AreEqual(1, dequeued1);
            Assert.AreEqual(2, dequeued2);
            Assert.AreEqual(3, dequeued3);
        }

        [Test]
        public void SHOULD_work_in_fifo_order1()
        {
            var queue = new ArrayBasedQueue<int>();

            queue.Enqueue(1);
            var dequeued1 = queue.Dequeue();
            queue.Enqueue(2);
            var dequeued2 = queue.Dequeue();
            queue.Enqueue(3);
            var dequeued3 = queue.Dequeue();
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(1, dequeued1);
            Assert.AreEqual(2, dequeued2);
            Assert.AreEqual(3, dequeued3);
        }

        [Test]
        public void SHOULD_throw_invalid_operation_WHEN_queue_is_empty_and_dequeued_is_called()
        {
            var queue = new ArrayBasedQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void SHOULD_not_iterate_WHEN_queue_is_empty()
        {
            var list = Enumerable.Empty<int>().ToList();
            var queue = new ArrayBasedQueue<int>();

            foreach (var item in queue)
                list.Add(item);

            Assert.IsTrue(queue.IsEmpty);
            Assert.IsTrue(queue.Count == 0);
            Assert.IsEmpty(list);
        }

        [Test]
        public void SHOULD_iterate_from_head_to_tail_WHEN_queue_is_not_empty()
        {
            var list = Enumerable.Empty<int>().ToList();
            var queue = new ArrayBasedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            foreach (var item in queue)
                list.Add(item);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list[3]);
        }
    }
}