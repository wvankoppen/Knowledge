<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

public class Program
{
	static void Main(string[] args)
	{
		int controlDigit = ControlDigitAlgorithms.ForSalesDepartment.GetControlDigit(12345);

		Console.WriteLine(controlDigit);
	}
}

public class ControlDigitAlgorithm
{
	private Func<long, IEnumerable<int>> GetDigitsOf { get; }
	private IEnumerable<int> MultiplyingFactors { get; }
	private int Modulo { get; }

	public ControlDigitAlgorithm(Func<long, IEnumerable<int>> getDigitsOf, IEnumerable<int> multiplyingFactors, int modulo)
	{
		this.GetDigitsOf = getDigitsOf;
		this.MultiplyingFactors = multiplyingFactors;
		this.Modulo = modulo;
	}

	public int GetControlDigit(long number) =>
			this.GetDigitsOf(number)
				.Zip(this.MultiplyingFactors, (a, b) => a * b)
				.Sum()
			% this.Modulo;
}

static class Int64Extensions
{
	public static IEnumerable<int> DigitsFromLowest(this long number)
	{
		do
		{
			yield return (int)number % 10;
			number /= 10;
		}
		while (number > 0);
	}

	public static IEnumerable<int> DigitsFromHighest(this long number) =>
		number.DigitsFromLowest().Reverse();
}

static class ControlDigitAlgorithms
{
	public static ControlDigitAlgorithm ForAccountingDepartment =>
		new ControlDigitAlgorithm(x => x.DigitsFromHighest(), MultiplyingFactors, 7);

	public static ControlDigitAlgorithm ForSalesDepartment =>
		new ControlDigitAlgorithm(x => x.DigitsFromLowest(), MultiplyingFactors, 9);

	private static IEnumerable<int> MultiplyingFactors
	{
		get
		{
			int factor = 3;
			while (true)
			{
				yield return factor;
				factor = 4 - factor;
			}
		}
	}
}