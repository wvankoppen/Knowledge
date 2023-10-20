<Query Kind="Statements" />


var x = new Lazy<string>(() => { Console.WriteLine("Instantiate!"); return "Very expensive constructor";});

Console.WriteLine("Not yet instantiated.");
Console.WriteLine(x.Value);