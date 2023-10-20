<Query Kind="Program" />

void Main()
{
	// Double select shines instead of SelectMany!
	var queryExpressionExample = (
		from row in Enumerable.Range('a',3)
		from col in Enumerable.Range(1,3)
		select ((char)row,col)
	);
	
	var methodExample = 
		Enumerable.Range('a',3)
		.SelectMany(
			row => 
				Enumerable.Range(1,3), 
				(row,col) => ((char)row,col)
		);
	
	queryExpressionExample.Dump("Both outputs are same");
	methodExample.Dump("Both outputs are same");
}

// Define other methods and classes here