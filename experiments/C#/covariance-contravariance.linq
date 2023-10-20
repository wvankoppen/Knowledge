<Query Kind="Program" />

void Main()
{
	// Covariance
	Action<Base> actionBase = (target) => { Console.WriteLine(target.GetType().Name); };
	Action<Derived> actionDerived = actionBase;
	actionDerived(new Derived());
	
	IEnumerable<Base> elements1 = new List<Derived>();
	
	// Contravariance
	Func<Derived> funcBase = () => { return new Derived(); };
	Func<Base> funcDerived = funcBase;
	Console.WriteLine(funcDerived().GetType().Name);
	
	// Invariance
	// IList<Base> elements2 = new List<Derived>(); // Disallowed. List is invariant: I.e. covariant nor contravariant.
}

class Base {}

class Derived : Base {}