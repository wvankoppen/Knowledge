<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
</Query>

public class Fibonacci
{
	public int N { get; private set; }
	public int FibOfN { get; private set; }
	private ManualResetEvent doneEvent;

	public Fibonacci(int n, ManualResetEvent doneEvent)
	{
		this.N = n;
		this.doneEvent = doneEvent;
	}

	// Wrapper method for use with thread pool.
	public void ThreadPoolCallback(Object threadContext)
	{
		int threadIndex = (int)threadContext;
		Console.WriteLine("thread {0} started...", threadIndex);
		Thread.Sleep(5000);
		Console.WriteLine("thread {0} result calculated...", threadIndex);
		doneEvent.Set();
	}

	// Recursive method that calculates the Nth Fibonacci number.
	public int Calculate(int n)
	{
		if (n <= 1)
		{
			return n;
		}

		return Calculate(n - 1) + Calculate(n - 2);
	}
}

void Main()
{
	const int FibonacciCalculations = 10;

	ThreadPool.SetMaxThreads(5, 51).Dump();
	
	// One event is used for each Fibonacci object
	ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];
	Fibonacci[] fibArray = new Fibonacci[FibonacciCalculations];
	Random r = new Random();

	// Configure and launch threads using ThreadPool:
	Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
	for (int i = 0; i < FibonacciCalculations; i++)
	{
		doneEvents[i] = new ManualResetEvent(false);
		Fibonacci f = new Fibonacci(r.Next(30, 50), doneEvents[i]);
		fibArray[i] = f;
		ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
	}


	// Wait for all threads in pool to calculation...

	//WaitHandle.WaitAll(doneEvents);
	foreach (var e in doneEvents)
		e.WaitOne();

	Console.WriteLine("All calculations are complete.");

	// Display the results...
	for (int i = 0; i < FibonacciCalculations; i++)
	{
		Fibonacci f = fibArray[i];
		Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
	}
}