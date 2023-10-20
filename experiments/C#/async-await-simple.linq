<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Console.WriteLine(DateTime.Now + " started");

var a = Task.Delay(1000);
await a;

Console.WriteLine(DateTime.Now + " ended");