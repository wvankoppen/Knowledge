<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

class MainApp
{
	static void Main()
	{
		var subject = new ConcreteSubject();

		subject.Attach(new ConcreteObserver(subject, "X"));
		subject.Attach(new ConcreteObserver(subject, "Y"));
		subject.SubjectState = "tempstate";
		subject.SubjectState = "ABC";
		subject.Notify();
		
		subject.Attach(new ConcreteObserver(subject, "Z"));

		subject.SubjectState = "DEF";
		subject.Notify();
	}
}

abstract class Subject
{
	private List<Observer> observers = new List<Observer>();

	public void Attach(Observer observer)
	{
		this.observers.Add(observer);
	}

	public void Detach(Observer observer)
	{
		this.observers.Remove(observer);
	}

	public void Notify()
	{
		foreach (var observer in this.observers)
		{
			observer.Update();
		}
	}
}

class ConcreteSubject : Subject
{
	public string SubjectState { get; set; }
}

abstract class Observer
{
	public abstract void Update();
}

class ConcreteObserver : Observer
{
	private string name;
	private string observerState;

	public ConcreteObserver(ConcreteSubject subject, string name)
	{
		this.Subject = subject;
		this.name = name;
	}

	public ConcreteSubject Subject { get; private set; }

	public override void Update()
	{
		this.observerState = this.Subject.SubjectState;
		Console.WriteLine("Observer {0}'s new state is {1}", this.name, this.observerState);
	}
}
