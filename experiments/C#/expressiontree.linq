<Query Kind="Program" />

void Main()
{
 	Func<int,int,int> addDel = (a,b) => a + b;
	addDel.Dump("Add delegate");
	addDel(1,2).Dump();
	
	Expression<Func<int,int,int>> addExp = (a,b) => a + b;
	addExp.Dump("Add expression tree");
	
	var addDel2 = addExp.Compile();
	addDel2(1,2).Dump();
}

