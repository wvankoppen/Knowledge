<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

abstract class Expression
{
}

class Literal : Expression
{
    public double Value { get; }

    public Literal(double value)
    {
        this.Value = value;
    }
}

class Addition : Expression
{
    internal Expression Left { get; }
    internal Expression Right { get; }

    public Addition(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }
}

// Visitor for printing math expressions
class MathExpressionPrinter
{
    public void Print(Literal literal, StringBuilder sb)
    {
        sb.Append(literal.Value);
    }

    public void Print(Addition addition, StringBuilder sb)
    {
        sb.Append("(");
        Print((dynamic)addition.Left, sb);
        sb.Append("+");
        Print((dynamic)addition.Right, sb);
        sb.Append(")");
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
		
        new MathExpressionPrinter().Print((dynamic)expression, sb);
        sb.ToString().Dump("Output of the visitors");
    }
}