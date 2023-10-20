<Query Kind="Program" />

public interface IWindow 
{	
	void AddControl(IControl control);
}

public interface IControl
{
}


public class MsWindow : IWindow
{
	public void AddControl(IControl control)
	{
		// CANNOT ACCESS THE HANDLE HERE on control, it is too abstract!
		// Undesired downcast needed
		var msControl = control as MsButton;
		msControl.GetHandle();
	}
}

public class MsButton : IControl
{
	public int GetHandle()
	{
		return 598325783;
	}
}


public interface IGuiFactory 
{
	IWindow CreateWindow();
	IControl CreateButton();
}

public class WindowsGuiFactory : IGuiFactory
{
	public IWindow CreateWindow()
	{
		return new MsWindow();
	}
	public IControl CreateButton()
	{
		return new MsButton();
	}
}


void Main()
{
	var windowFactory = new WindowsGuiFactory();
	var window = windowFactory.CreateWindow();
	var control = windowFactory.CreateButton();	
}