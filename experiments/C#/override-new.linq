<Query Kind="Program" />

public class Base
{
	public bool DoSomething()
	{
		return false;
	}

	public virtual bool DoOther()
	{
		return false;
	}
}

public class Derrived : Base
{
	public new bool DoSomething()
	{
		return true;
	}

	public override bool DoOther()
	{
		return true;
	}
}

public class Test
{
	public static void Main()
	{
		Base test = new Derrived();
		Console.WriteLine(test.DoSomething());
		Console.WriteLine(((Derrived)test).DoSomething());

		Console.WriteLine(test.DoOther());
		Console.WriteLine(((Derrived)test).DoOther());
	}
}