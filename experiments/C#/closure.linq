<Query Kind="Program" />

void Main()
{
	Action<int, int> multiply = (x, y) =>
	 {
		 Console.WriteLine(x * y);
	 };

	Action<int> MultiplyByTwo = (z) =>
	{
		multiply(z, 2);
	};

	Action<int> MultiplyByThree = (z) =>
	{
		multiply(z, 3);
	};
	Action<int> PlusOneMultiplyByThree = (z) =>
	{
		MultiplyByThree(z + 1);
	};

	MultiplyByTwo(6);
	MultiplyByThree(6);
	PlusOneMultiplyByThree(6);
}
