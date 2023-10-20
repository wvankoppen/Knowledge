<Query Kind="Statements" />

Func<Func<int, int>, Func<int, int>> once =
		f => x => f(x);

Func<Func<int, int>, Func<int, int>> twice =
		f => x => f(f(x));

Func<Func<int, int>, Func<int, int>> thrice =
		f => x => f(f(f(x)));

Func<int, int> plusThree = x => x + 3;


Console.WriteLine(once(plusThree)(7));
Console.WriteLine(twice(plusThree)(7));
Console.WriteLine(thrice(plusThree)(7));