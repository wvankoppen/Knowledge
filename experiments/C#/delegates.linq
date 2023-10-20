<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

public delegate string MyDelegate (string x);
    
public class DelegateTest
{    
    public string Name;
        
    public static string StaticMethod (string p)
    {
		".StaticMethod".Dump();
        return string.Format ("Static method: {0}", p);
    }

    public string InstanceMethod (string p)
    {
		".InstanceMethod".Dump();
        return string.Format ("{0}: {1}", this.Name, p);
    }
}

void Main()
{
	var staticMethodDelegate = new MyDelegate(DelegateTest.StaticMethod);
        
    var instance = new DelegateTest 
	{
		Name = "My instance"
	};
	
    var instanceMethodDelegate = new MyDelegate(instance.InstanceMethod);
    
	var combinedDelegate = (MyDelegate)Delegate.Combine(staticMethodDelegate, instanceMethodDelegate);
	
    staticMethodDelegate("hi").Dump("Delegate containing static method"); 
	instanceMethodDelegate("hi").Dump("Delegate containing instance method"); 
	combinedDelegate("hi").Dump("Delegate containing combi of static and instance method (both delegate run, last returns)"); 
}