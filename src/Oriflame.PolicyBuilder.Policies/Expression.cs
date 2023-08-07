namespace Oriflame.PolicyBuilder.Policies
{
    public abstract class Expression
    {
        protected string Statement { get; set; }

        protected Expression(string statement)
        {
            Statement = statement;
        }

        public static implicit operator string(Expression expression)
        {
            return expression.ToString();
        }

        public abstract string ToString();
    }

    public class SingleStatementExpression : Expression
    {
        public SingleStatementExpression(string statement) : base(statement)
        {
        }

        public override string ToString()
        {
            return $"@({Statement})";
        }
    }

    public class MultiStatementExpression : Expression
    {
        public MultiStatementExpression(string statement) : base(statement)
        {
        }

        public override string ToString()
        {
            return $"@{{{Statement}}}";
        }
    }
}
