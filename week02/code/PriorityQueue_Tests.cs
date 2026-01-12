using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Should add 3 elements to end of the queue with random priorities.
    // Expected Result: Should be ordered in the order they were added.
    // Defect(s) Found: 
    public void TestPriorityQueue_AddElementToEndOfQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 5);
        priorityQueue.Enqueue("Task3", 3);
        Assert.AreEqual("[Task1 (Pri:1), Task2 (Pri:5), Task3 (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Should add elements and then remove in the order of priority testing dequeing.
    // Expected Result: Should FIFO for same priority, and highest priority first, removing the highest priority.
    // Defect(s) Found: Dequeue method does not remove the item from the queue after finding the highest priority. 
    // No FIFO when priorities are the same, 
    // not going until the end of the list
    public void TestPriorityQueue_DequeueElements()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 5);
        priorityQueue.Enqueue("Task3", 3);
        priorityQueue.Enqueue("Task4", 5);
        var firstOut = priorityQueue.Dequeue();
        Assert.AreEqual("Task2", firstOut);
        Assert.AreEqual("[Task1 (Pri:1), Task3 (Pri:3), Task4 (Pri:5)]", priorityQueue.ToString());
        var secondOut = priorityQueue.Dequeue();
        Assert.AreEqual("Task4", secondOut);
        Assert.AreEqual("[Task1 (Pri:1), Task3 (Pri:3)]", priorityQueue.ToString());
    }
    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException.
    public void TestPriorityQueue_EmptyDequeue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}