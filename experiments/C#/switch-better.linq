<Query Kind="Program" />

// BAD: Closed-open example
void Main3()
{
	bool isStopRequested = false;

	while (!isStopRequested)
	{
		string userInput = Console.ReadLine();
		switch (userInput)
		{
			case "s":
				Console.WriteLine("Stop");
				isStopRequested = true;
				break;
			case "d":
				Console.WriteLine("Do it!");
				break;
			case "o":
				Console.WriteLine("Do the other!");
				break;
			default:
				Console.WriteLine("Invalid choice!");
				break;
		}
	}
}

// BETTER: Open-closed example
void Main()
{
	bool isStopRequested = false;
		
	var chooser = new Chooser(() => { Console.WriteLine("Unknown action!"); });
	chooser.Add("s", () => { Console.WriteLine("Stop!"); isStopRequested = true; });
	chooser.Add("d", () => { Console.WriteLine("Do it!"); });
	chooser.Add("o", () => { Console.WriteLine("Do the other!"); });
	
	while (!isStopRequested) 
	{
		string userInput = Console.ReadLine();
		chooser.Choose(userInput);
	}
}

class Chooser 
{
	Dictionary<string, Action> choices;
	Action fallback;

	public Chooser(Action fallback) 
	{
		this.fallback = fallback;
		choices = new Dictionary<string, Action>();
	}
	
	public void Add(string name, Action action) 
	{
		this.choices.Add(name, action);
	}
	
	public void Choose(string name) 
	{
		Action act;
		if (!this.choices.TryGetValue(name, out act))
		{
			act = fallback;
		}
		act();
	}
}