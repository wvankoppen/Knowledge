<Query Kind="Program" />

interface IExpressionVisitor
{
	void Visit(Literal literal);
	void Visit(Addition literal);
}

interface IExpression
{
	void Accept(IExpressionVisitor visitor);
}

class Literal : IExpression
{
	internal double Value { get; set; }

	public Literal(double value)
	{
		this.Value = value;
	}
	public void Accept(IExpressionVisitor visitor)
	{
		visitor.Visit(this);
	}
}

class Addition : IExpression
{
	internal IExpression Left { get; set; }
	internal IExpression Right { get; set; }

	public Addition(IExpression left, IExpression right)
	{
		this.Left = left;
		this.Right = right;
	}

	public void Accept(IExpressionVisitor visitor)
	{
		visitor.Visit(this);
	}
}

// Visitor for printing math expressions
class MathExpressionPrinter : IExpressionVisitor
{
	private StringBuilder sb;

	public MathExpressionPrinter(StringBuilder sb)
	{
		this.sb = sb;
	}

	public void Visit(Literal literal)
	{
		sb.Append(literal.Value);
	}

	public void Visit(Addition addition)
	{
		sb.Append("(");
		addition.Left.Accept(this);
		sb.Append("+");
		addition.Right.Accept(this);
		sb.Append(")");
	}
}

// Visitor for printing text expressions
class TextExpressionPrinter : IExpressionVisitor
{
	private StringBuilder sb;

	public TextExpressionPrinter(StringBuilder sb)
	{
		this.sb = sb;
	}

	public void Visit(Literal literal)
	{
		sb.Append(literal.Value);
	}

	public void Visit(Addition addition)
	{
		sb.Append("");
		addition.Left.Accept(this);
		sb.Append(" plus ");
		addition.Right.Accept(this);
		sb.Append("      ");
	}
}


class Program
{
	static void Main(string[] args)
	{
		// emulate 1+2+3
		var expression = new Addition(
		  new Addition(
			new Literal(1),
			new Literal(2)
		  ),
		  new Literal(3)
		);
		var sb = new StringBuilder();

		expression.Accept(new MathExpressionPrinter(sb));
		sb.Append("\n");
		expression.Accept(new TextExpressionPrinter(sb));
		
		sb.ToString().Dump("Output of the visitors");
	}
}