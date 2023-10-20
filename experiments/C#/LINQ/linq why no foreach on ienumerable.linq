<Query Kind="Program" />

public static class Extensions
{
	public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
	{
		foreach (T item in sequence)
		{
			action(item);
		}
	}
}

// Why no IEnumerable<T>.forEach()?
// Because it collides with the functional nature of the other methods who are side-effect free.
// ForEach is by default side-effect.
// .Select can also cause side effects, but only when invoking methods on reference types.
void Main()
{
	IEnumerable<StringBuilder> items = new List<StringBuilder> { new StringBuilder("item1"), new StringBuilder("item2") };

	items.ForEach(e => e = e.Append(" postfix"));

	items.ForEach(e => Console.WriteLine(e.ToString()));
	Console.WriteLine("\n");

	items = items.Select(e => e.Append(" postfix"));

	items.ForEach(e => Console.WriteLine(e.ToString()));
}
