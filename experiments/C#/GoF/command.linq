<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

class MainApp
{
	static void Main()
	{
		var user = new User();
		Console.WriteLine("Current value = 0");
		user.Compute('+', 100);
		user.Compute('-', 50);
		user.Compute('*', 10);
		user.Compute('/', 2);

		user.Undo(4);
		user.Redo(3);
	}
}

interface ICommand
{
	void Execute();
	void Undo();
}

class CalculatorCommand : ICommand
{
	private char _operator;
	private int _operand;
	private Calculator _calculator;

	public CalculatorCommand(Calculator calculator, char @operator, int operand)
	{
		this._calculator = calculator;
		this._operator = @operator;
		this._operand = operand;
	}

	public char Operator
	{
		set { _operator = value; }
	}

	public int Operand
	{
		set { _operand = value; }
	}

	public void Execute()
	{
		_calculator.Operation(_operator, _operand);
	}

	public void Undo()
	{
		_calculator.Operation(Undo(_operator), _operand);
	}

	private char Undo(char @operator)
	{
		switch (@operator)
		{
			case '+': return '-';
			case '-': return '+';
			case '*': return '/';
			case '/': return '*';
			default:
				throw new ArgumentException("@operator");
		}
	}
}

class Calculator
{
	private int _currentValue = 0;

	public void Operation(char @operator, int operand)
	{
		switch (@operator)
		{
			case '+': _currentValue += operand; break;
			case '-': _currentValue -= operand; break;
			case '*': _currentValue *= operand; break;
			case '/': _currentValue /= operand; break;
		}
		Console.WriteLine("Current value = {0,3} (as a result of {1} {2})", _currentValue, @operator, operand);
	}
}

class User
{
	private Calculator _calculator = new Calculator();
	private List<ICommand> _commandHistory = new List<ICommand>();
	private int _currentCommandNr = 0;

	public void Redo(int levels)
	{
		Console.WriteLine("\n---- Redo {0} levels ", levels);
		
		_commandHistory
			.Take(levels)
			.ToList()
			.ForEach(c => c.Execute());
	}

	public void Undo(int levels)
	{
		Console.WriteLine("\n---- Undo {0} levels ", levels);

		_commandHistory
			.TakeLast(levels)
			.Reverse()
			.ToList()
			.ForEach(c => c.Undo());
	}

	public void Compute(char @operator, int operand)
	{
		var command = new CalculatorCommand(_calculator, @operator, operand);
		command.Execute();

		_commandHistory.Add(command);
		_currentCommandNr++;
	}
}

public static class Extensions
{
	public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection, int n)
	{
		if (collection == null)
			throw new ArgumentNullException("collection");
		if (n < 0)
			throw new ArgumentOutOfRangeException("n", "n must be 0 or greater");

		var temp = new LinkedList<T>();

		foreach (var value in collection)
		{
			temp.AddLast(value);
			if (temp.Count > n)
				temp.RemoveFirst();
		}

		return temp;
	}
}