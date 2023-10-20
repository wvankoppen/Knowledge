<Query Kind="Program" />

void Main()
{
	var dict = new Dictionary<MyObj, int>();
	var key = new MyObj { Value = "initialvalue" };

	dict.Add(key, 1);
	var initialLookupResult = dict[key];

	key.Value = "someothervalue";	
	var secondLookupResult = dict[key];
	
	initialLookupResult.Equals(secondLookupResult).Dump("Does initial lookup equals second lookup?");
	// Yes, because the hash code is not changed after assigining the property.
}

public class MyObj
{
	public string Value { get; set; }
}