<Query Kind="Program" />

void Main()
{
	var derrived = new Derrived();
}

class Base
{
	public Base()
	{
		Console.WriteLine("Base()");
		this.Init();
	}

	public virtual void Init()
	{
		Console.WriteLine("Base.Init");
	}
}

class Derrived : Base
{
	public Derrived()
	{
		Console.WriteLine("Derrived()");
		this.Init();
	}

	public override void Init()
	{
		Console.WriteLine("Derrived.Init");
	}
}