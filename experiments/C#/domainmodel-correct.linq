<Query Kind="Program" />

void Main()
{
	var user = new User(new PersonalFirstName("Wouter"), new PersonalLastName("van Koppen"));
	new UserPrinter().Print(user);
}

public class UserPrinter 
{
	public void Print(User user) 
	{
		("first letter: " + user.LastName.StartingLetter).Dump();
	}
}

public class User 
{
	public PersonalFirstName FirstName {get; private set;}
	public PersonalLastName LastName {get; private set;}
	
	public User(PersonalFirstName firstname, PersonalLastName lastname) 
	{
		this.FirstName = firstname;
		this.LastName = lastname;
	}
}

public class PersonalFirstName 
{
	public string Name {get; private set;}
	
	public PersonalFirstName(string name) 
	{
		this.Name = name;
	}
}


public class PersonalLastName 
{
	public string Name {get; private set;}
	
	public string StartingLetter 
	{
		get 
		{
			// This logic must be implemented inside PersonalLastName!
			if (Name.StartsWith("van")) 
			{
				return new string(this.Name[4],1);
			}
			else 
			{
				return new string(this.Name[0],1);
			}
		}
	}
	
	public PersonalLastName(string name) 
	{
		this.Name = name;
	}
}