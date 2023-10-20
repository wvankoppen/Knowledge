<Query Kind="Statements">
  <NuGetReference>LinqOptimizer.CSharp</NuGetReference>
  <Namespace>Nessos.LinqOptimizer.Core</Namespace>
  <Namespace>Nessos.LinqOptimizer.CSharp</Namespace>
</Query>

var listSize = 10000000;
var stopwatch = new Stopwatch();
stopwatch.Restart();
var s = Enumerable.Range(1, listSize)
	.Select(n => n * 2)
	.Select(n => Math.Sin((2 * Math.PI * n)/1000))
	.Select(n => Math.Pow(n,2))
	.Sum();
stopwatch.Stop();
stopwatch.ElapsedMilliseconds.Dump("LINQ example of computing " + s);

/////////////////////////////////////////////////////////////////////////////////////
stopwatch.Restart();
double sum = 0;
for (int n = 1; n <= listSize; n++)
{
	var a = n * 2;
	var b = Math.Sin((2 * Math.PI * a)/1000);
	var c = Math.Pow(b,2);
	sum += c;
}
stopwatch.Stop();
stopwatch.ElapsedMilliseconds.Dump("For loop example of computing " + s);

/////////////////////////////////////////////////////////////////////////////////////
var q = Enumerable.Range(1, listSize).AsQueryExpr()
	.Select(n => n * 2)
	.Select(n => Math.Sin((2 * Math.PI * n) / 1000))
	.Select(n => Math.Pow(n, 2))
	.Sum();
q.Compile();

stopwatch.Restart();
var s2 = q.Run();
stopwatch.Stop();
stopwatch.ElapsedMilliseconds.Dump("LinqOptimizer.CSharp example of computing " + s);

/////////////////////////////////////////////////////////////////////////////////////
stopwatch.Restart();
var s3 = Enumerable.Range(1, listSize).AsParallel()
	.Select(n => n * 2)
	.Select(n => Math.Sin((2 * Math.PI * n) / 1000))
	.Select(n => Math.Pow(n, 2))
	.Sum();
stopwatch.Stop();
stopwatch.ElapsedMilliseconds.Dump("PLINQ example of computing " + s);
