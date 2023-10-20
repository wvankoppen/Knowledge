<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Linq.Expressions</Namespace>
</Query>

void Main()
{		
	List<int> list = new List<int>() { 1, 2, 3 };

	IQueryable<int> query = (	from number in list
					            where number < 3
	            				select number).AsQueryable();
	query.Dump("query");
	
	query.AsQueryable().Dump("query.AsQueryable() ??the same as IEnumerable??");

	IQueryable emptyQueryable = Enumerable.Empty<int>().AsQueryable();
	
	emptyQueryable.Expression.Dump("emptyQueryable.Expression");
	emptyQueryable.Provider.Dump("emptyQueryable.Provider");
	emptyQueryable.ElementType.Dump("emptyQueryable.ElementType");
}