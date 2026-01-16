using Microsoft.VisualStudio.TestTools.UnitTesting;


/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Testing a default max size when given -1
        // Expected Result: Should fallback to 10
        Console.WriteLine("Test 1");
        var customerService = new CustomerService(-1);
        Assert.AreEqual(10, customerService._maxSize);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: AddNewCustomer should add a new customer into the queue
        // Expected Result: The queue should have one element
        Console.WriteLine("Test 2");
        var customerService2 = new CustomerService(5);
        customerService2.AddNewCustomer();
        Assert.AreEqual(1, customerService2._queue.Count);

                Console.WriteLine("=================");

        // Test3 
        // Scenario: If the queue is full should throw an error 
        // Expected Result: Throw an error when queue is full
        Console.WriteLine("Test 3");
        var customerService3 = new CustomerService(1);
        customerService3.AddNewCustomer();
        Assert.AreEqual(1, customerService3._queue.Count);
        customerService3.AddNewCustomer();
        Assert.AreEqual(1, customerService3._queue.Count);
        //Defects found: AddNewCustomer was checking > than maxSize instead of >=

                Console.WriteLine("=================");
        // Test4 
        // Scenario: If the queue is full should throw an error 
        // Expected Result: Throw an error when queue is full
        Console.WriteLine("Test 4");
        var customerService4 = new CustomerService(3);
        customerService4.AddNewCustomer();
        Assert.AreEqual(1, customerService4._queue.Count);
        customerService4.ServeCustomer();
        Assert.AreEqual(0, customerService4._queue.Count);
        customerService4.ServeCustomer();
        // Defect(s) Found: Serve customer was removing before getting the data,
        // and no error was shown when serve customer was called on a empty array.

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}