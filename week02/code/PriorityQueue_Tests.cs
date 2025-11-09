using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Push three items with different priorities out of priority order and pop them all off.
    // Expected Result: Items come off in order from highest priority to lowest priority.
    // Defect(s) Found: high priority task not being dequeued after call to Dequeue. low priority task dequeued before medium priority task.
    public void TestPriorityQueue_PopHighPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriorityTask", 1);
        priorityQueue.Enqueue("HighPriorityTask", 10);
        priorityQueue.Enqueue("MediumPriorityTask", 5);
        Assert.AreEqual("HighPriorityTask", priorityQueue.Dequeue());
        Assert.AreEqual("MediumPriorityTask", priorityQueue.Dequeue());
        Assert.AreEqual("LowPriorityTask", priorityQueue.Dequeue());


    }

    [TestMethod]
    // Scenario: Push items with the same priority and pop them all off.
    // Expected Result: Items come off in the same order they were added (FIFO).
    // Defect(s) Found: tasks coming off in reverse order.
    public void TestPriorityQueue_SamePriorityFifo()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstTask", 5);
        priorityQueue.Enqueue("SecondTask", 5);
        Assert.AreEqual("FirstTask", priorityQueue.Dequeue());
        Assert.AreEqual("SecondTask", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Pop empty queue.
    // Expected Result: Exception is thrown.
    // Defect(s) Found:
    public void TestPriorityQueue_PopEmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an exception when dequeuing from an empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}