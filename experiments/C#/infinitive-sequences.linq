<Query Kind="Statements" />

IEnumerable<int> GetFactors()
{
	while (true)
	{
		yield return 1;
		yield return 3;
	}
}

IEnumerable<int> PopulateSeries()
{
	int start = 0;
	while (true)
	{
		yield return start++;
	}
}


PopulateSeries().Zip(GetFactors(), (x, y) => new Tuple<int,int>(x,y)).TakeWhile(t => t.Item1 < 10).Dump();