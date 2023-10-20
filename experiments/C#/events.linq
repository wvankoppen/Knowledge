<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

public class Subscriber 
{
	private Publisher publisher;
	
	public Subscriber(Publisher pub) 
	{
		this.publisher = pub;
	}

	public void Subscribe() 
	{
		this.publisher.Event1 += this.OnEvent;
	}
	
	public void Unsubscribe() 
	{
		this.publisher.Event1 -= this.OnEvent;
	}
	
	public void UnsubscribeNull() 
	{
		this.publisher.Event1 -= null;
	}
	
	public void OnEvent (int x) 
	{
		Console.WriteLine("OnEvent " + x);
	}
}

public class Publisher
{
	public delegate void MyDelegate(int x);

	private MyDelegate handler; 
  	public event MyDelegate Event1 
	{ 
	    add 
		{ 
			handler += value; 
			Console.WriteLine ("add           " + value + " - " + handler.GetInvocationList().Length);
		} 
	    remove
		{ 
			handler -= value; 
			Console.WriteLine ("remove     " + value + " - " + handler?.GetInvocationList().Length);
		} 
	} 
	
	public event MyDelegate Event2;  
	
	public void Raise() 
	{
		if (this.Event2 != null) 
		{
			this.Event2(2);
		}
	}
	
	void DoNothing (int i)
    {
    }
    
    void DoNothing (object sender, EventArgs e)
    {
    }
}

class MainClass {
	static void Main()
    {
        var publisher = new Publisher();
		var subscriber = new Subscriber(publisher);
		subscriber.Subscribe();
		subscriber.Subscribe();
		subscriber.Subscribe();
        publisher.Raise();
		subscriber.Unsubscribe();
		subscriber.UnsubscribeNull();
		subscriber.UnsubscribeNull();
		subscriber.UnsubscribeNull();
		publisher.Raise();
    }
}