<Query Kind="Program" />

void Main()
{
	long x = 1;
	int y = 1;
		
	(x==y).Dump("x==y");
		
	((long)x==(long)y).Dump("((long)x==(long)y)");
	((int)x==(int)y).Dump("((int)x==(int)y)");
		
	((object)x==(object)y).Dump("((object)x==(object)y)");
	ReferenceEquals(x,y).Dump("ReferenceEquals(x,y)");	
	
	string s1 = "flyweight";
	string s2 = "flyweight";
	
	// Because of flyweight, s1 and s2 poin to the same string!
	ReferenceEquals(s1, s2).Dump("ReferenceEquals(s1, s2)");
	
	// Assignment is optimized away, hence still the same string
	s2 = s2 + "";
	ReferenceEquals(s1, s2).Dump("ReferenceEquals(s1, s2)");
	
	// String was already lowercase, but now a new string is allocated
	s2 = s2.ToLower();
	ReferenceEquals(s1, s2).Dump("ReferenceEquals(s1, s2)");
}