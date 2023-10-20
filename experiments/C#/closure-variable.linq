<Query Kind="Program" />

static void Main(string[] args)
{
    var inc = GetAFunc();
	var inc2 = GetAFunc();
	
    Console.WriteLine(inc());
	Console.WriteLine(inc());
	Console.WriteLine(inc());
	Console.WriteLine();
    Console.WriteLine(inc2());
	Console.WriteLine(inc());
	Console.WriteLine(inc());
}

public static Func<int> GetAFunc()
{
    var invokeCount = 0;
    Func<int> inc = () => ++invokeCount;
  	
    return inc;
}