<Query Kind="Program" />

void Main()
{
	var c1 = new Coordinate();
	var c2 = new Coordinate();
	c1.x = 1;
	c1.Dump();
	(c1==c2).Dump();
}

struct Coordinate
{
	public int x { get; set;}
	public int y { get; set;}
}

