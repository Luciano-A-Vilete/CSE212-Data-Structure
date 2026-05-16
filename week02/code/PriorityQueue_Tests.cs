using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 4 items with distinct priorities, with the highest
    // priority added LAST. Dequeue all of them.
    //   Enqueue: Bob(3), Tim(1), Sue(2), Joe(4)
    // Expected Result: Joe, Bob, Sue, Tim
    // Defect(s) Found: (1) Loop bound 'index < _queue.Count - 1' skipped the
    //   last element, so Joe (highest, at the back) was never selected.
    //   (2) Dequeue never removed the selected item, so repeated dequeues
    //   returned the same value.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Tim", 1);
        priorityQueue.Enqueue("Sue", 2);
        priorityQueue.Enqueue("Joe", 4);

        Assert.AreEqual("Joe", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items where several share the same highest priority,
    // to verify FIFO order is kept among ties.
    //   Enqueue: Bob(5), Tim(5), Sue(2), Joe(5)
    // Expected Result: Bob, Tim, Joe, Sue
    // Defect(s) Found: Comparison used '>=', selecting the LAST item with the
    //   highest priority instead of the FIRST, breaking FIFO order for ties.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 2);
        priorityQueue.Enqueue("Joe", 5);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Joe", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message
    //   "The queue is empty."
    // Defect(s) Found: None - the empty-queue check was implemented correctly.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }
}