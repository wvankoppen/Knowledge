<Query Kind="Program">
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	new Runner().Run();
}

// This example shows how to use async-await as a specific time awaiter.
class Runner 
{
	public async void Run() 
	{
		var s = new Stopwatch();
		s.Start();
		var waitTwoSeconds = new TimeWaiter(2);
		var waitFiveSeconds = new TimeWaiter(5);
		
		await waitTwoSeconds;
		s.Elapsed.Dump();
		
		await waitTwoSeconds;
		s.Elapsed.Dump();
		
		await waitTwoSeconds;
		s.Elapsed.Dump();
		
		await waitFiveSeconds;
		s.Elapsed.Dump();
		"== FINISHED ==".Dump();
	}
}


class TimeWaiter : INotifyCompletion
{
	private int seconds;
	
	public TimeWaiter(int seconds) 
	{
		this.seconds = seconds;
	}

	public TimeWaiter GetAwaiter() 
	{
		".GetAwaiter".Dump();
		return this;
	}
	
	public void OnCompleted (Action continuation) 
	{
		".OnCompleted".Dump();
		Task.Factory.StartNew(() => 
		{ 
			Thread.Sleep(seconds * 1000);
			continuation(); 
		});
	}
	
	public bool IsCompleted
    {
        get 
		{ 
			".IsCompleted".Dump();
			return false; 
		}
    }

    public void GetResult()
    {
		".GetResult".Dump();
    }
}