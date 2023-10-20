<Query Kind="Program" />

void Main()
{
	var defensiveUserService = new DefensiveUserService();
	var user = defensiveUserService.GetUser(1);
	var nonExistingUser = defensiveUserService.GetUser(2233);

	var userService = new UserService();
	var otherUser = userService.GetUser(1);
	var otherNonExistingUser = userService.GetUser(2322);
	
	user.Dump();
	nonExistingUser.Dump();
	otherUser.Dump();
	otherNonExistingUser.Dump();

	// Not possible, type mismatch.
	// UserPrinter.Print(nonExistingUser);

	UserPrinter.Print(otherUser);
	try
	{
		UserPrinter.Print(otherNonExistingUser); // Nullreference exception!
	}
	catch(Exception e)
	{
		e.Dump();
	}
}

public static class UserPrinter 
{	
	public static void Print(User user) 
	{
		user.Name.Dump("User name");
	}
}

public class User
{
	public string Name { get; set; }
}

public class UserService
{
	private Dictionary<int, User> users = new Dictionary<int, User> { { 1, new User { Name = "Bill" } } };

	public User GetUser(int id)
	{
		if (this.users.ContainsKey(id))
		{
			return this.users[id];	
		}
		
		// Ugh! Who is going to deal with the null?
		return null;
	}
}


public class DefensiveUserService
{
	private Dictionary<int, User> users = new Dictionary<int, User> { { 1, new User { Name = "Bill" } } };

	public Maybe<User> GetUser(int id)
	{
		if (this.users.ContainsKey(id))
		{
			return Maybe<User>.Some(this.users[id]);
		}
		return Maybe<User>.None;
	}
}

public struct Maybe<T>
{
	readonly IEnumerable<T> values;

	public static Maybe<T> Some(T value)
	{
		if (value == null)
		{
			throw new InvalidOperationException();
		}

		return new Maybe<T>(new[] { value });
	}

	public static Maybe<T> None => new Maybe<T>(new T[0]);

	private Maybe(IEnumerable<T> values)
	{
		this.values = values;
	}

	public bool HasValue => values != null && values.Any();

	public T Value
	{
		get
		{
			if (!HasValue)
			{
				throw new InvalidOperationException("Maybe does not have a value");
			}

			return values.Single();
		}
	}
}