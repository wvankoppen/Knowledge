<Query Kind="Program" />

// Combine factory with state pattern to easen its use!

public interface IPerson
{
	string FirstName { get; }
	string LastName { get; }
}

public class Person : IPerson
{
	public string FirstName { get; }
	public string LastName { get; }
	
	public Person(string firstname, string lastname)
	{
		this.FirstName = firstname;
		this.LastName = lastname;
	}
}

public interface IEmptyHolder
{
	IFirstnameHolder WithFirstname(string firstname);
}

public interface IFirstnameHolder
{
	ILastnameHolder WithLastname(string firstname);
}

public interface ILastnameHolder
{
	IPerson Build();
}

public class PersonBuilder : IEmptyHolder, IFirstnameHolder, ILastnameHolder
{
	private string firstname;
	private string lastname;

	public static IEmptyHolder Create()
	{
		return new PersonBuilder();
	}

	public IPerson Build()
	{
		return new Person(this.firstname, this.lastname);
	}

	public IFirstnameHolder WithFirstname(string firstname)
	{
		this.firstname = firstname;
		return this;
	}

	public ILastnameHolder WithLastname(string lastname)
	{
		this.lastname = lastname;
		return this;
	}
}


void Main()
{
	var person = PersonBuilder
							.Create()
							.WithFirstname("wouter")
							.WithLastname("van Koppen")
							.Build();
	person.Dump();
}

// Define other methods and classes here
