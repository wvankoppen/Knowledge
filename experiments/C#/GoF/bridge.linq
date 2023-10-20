<Query Kind="Program" />

static void Main()
{
	Abstraction abstraction = new RefinedAbstraction();

	abstraction.Implementor = new ConcreteImplementorA();
	abstraction.Operation();

	abstraction.Implementor = new ConcreteImplementorB();
	abstraction.Operation();
}


class Abstraction
{
	protected Implementor implementor;

	public Implementor Implementor
	{
		set { implementor = value; }
	}

	public virtual void Operation()
	{
		implementor.Operation();
	}
}

class RefinedAbstraction : Abstraction
{
	public override void Operation()
	{
		implementor.Operation();
	}
}

abstract class Implementor
{
	public abstract void Operation();
}


class ConcreteImplementorA : Implementor
{
	public override void Operation()
	{
		Console.WriteLine("ConcreteImplementorA Operation");
	}
}

class ConcreteImplementorB : Implementor
{
	public override void Operation()
	{
		Console.WriteLine("ConcreteImplementorB Operation");
	}
}
