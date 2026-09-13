using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with distinct priorities and dequeue all.
    // Expected Result: Highest priority (Carl) is dequeued first, then Brian, then Alex.
    // Defect(s) Found: The priority search skipped the last item in the queue,
    // and the >= comparison caused later items with equal priority to be selected.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alex", 1);
        priorityQueue.Enqueue("Brian", 2);
        priorityQueue.Enqueue("Carl", 3);

        Assert.AreEqual("Carl", priorityQueue.Dequeue());
        Assert.AreEqual("Brian", priorityQueue.Dequeue());
        Assert.AreEqual("Alex", priorityQueue.Dequeue());

        //Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The earliest inserted item with that priority (Brian) is dequeued first. 
    // Defect(s) Found: >= comparison removed later item instead of earlier one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alex", 1);
        priorityQueue.Enqueue("Brian", 5);
        priorityQueue.Enqueue("Carl", 5);
        priorityQueue.Enqueue("Daniel", 3);

        Assert.AreEqual("Brian", priorityQueue.Dequeue());
        Assert.AreEqual("Carl", priorityQueue.Dequeue());
        Assert.AreEqual("Daniel", priorityQueue.Dequeue());
        Assert.AreEqual("Alex", priorityQueue.Dequeue());


       // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None after fix.
    [TestMethod]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    // Scenario: Ensure adds to the back (FIFO order maintained for equal priorities)
// Expected Result: For equal priorities, remove in order of insertion.
// Defect(s) Found: The >= comparison caused the later item with equal priority
// to be selected instead of maintaining FIFO order.
[TestMethod]
public void TestPriorityQueue_MaintainsFIFOForEqualPriorities()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("X", 10);
    priorityQueue.Enqueue("Y", 10);
    priorityQueue.Enqueue("Z", 10);

    Assert.AreEqual("X", priorityQueue.Dequeue());
    Assert.AreEqual("Y", priorityQueue.Dequeue());
    Assert.AreEqual("Z", priorityQueue.Dequeue());
}

}