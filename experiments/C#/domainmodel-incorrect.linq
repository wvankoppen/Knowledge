<Query Kind="Program" />

void Main()
{
	var user = new User("wouter", "van koppen");
	new UserPrinter().Print(user);
}

public class UserPrinter 
{
	public void Print(User user) 
	{
		("first letter: " + user.LastName[0]).Dump();
	}
}

public class User 
{
	public string FirstName {get; private set;}
	public string LastName {get; private set;}
	
	public User(string firstname, string lastname) 
	{
		this.FirstName = firstname;
		this.LastName = lastname;
	}
}
