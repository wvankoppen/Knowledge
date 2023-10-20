<Query Kind="Program" />

void Main()
{
	int x = unchecked((int.MaxValue+1));
	long y = unchecked(int.MinValue);
	x.Dump();
	y.Dump();
}

// Define other methods and classes here