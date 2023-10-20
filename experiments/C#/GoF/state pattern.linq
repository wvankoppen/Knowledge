<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

class MainApp
{
	static void Main()
	{
		var c = new TcpConnection();

		c.Open();
		c.Acknowledge();
		c.Close();
	}
}

abstract class TCPState
{
	public abstract void Open(TcpConnection connection);
	public abstract void Close(TcpConnection connection);
	public abstract void Acknowledge(TcpConnection connection);
}

class TCPEstablished : TCPState
{
	public override void Acknowledge(TcpConnection connection) 
	{	
	}

	public override void Close(TcpConnection connection)
	{
		connection.State = new TCPClosed();
	}

	public override void Open(TcpConnection connection)
	{
		throw new InvalidOperationException();
	}
}

class TCPListen : TCPState
{
	public override void Acknowledge(TcpConnection connection)
	{
		connection.State = new TCPEstablished();
	}

	public override void Close(TcpConnection connection)
	{
		connection.State = new TCPClosed();
	}

	public override void Open(TcpConnection connection)
	{
	}
}

class TCPClosed : TCPState
{
	public override void Acknowledge(TcpConnection connection)
	{
		throw new InvalidOperationException();
	}

	public override void Close(TcpConnection connection)
	{
	}

	public override void Open(TcpConnection connection)
	{
		connection.State = new TCPListen();
	}
}

class TcpConnection
{
	private TCPState state;

	public TcpConnection()
	{
		this.State = new TCPListen();
	}

	public TCPState State
	{
		get { return this.state; }
		set
		{
			this.state = value;
			Console.WriteLine("New state: " + this.state.GetType().Name);
		}
	}

	public void Open()
	{
		this.state.Open(this);
	}

	public void Close()
	{
		this.state.Close(this);
	}

	public void Acknowledge()
	{
		this.state.Acknowledge(this);
	}
}