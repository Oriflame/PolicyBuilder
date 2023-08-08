namespace Oriflame.PolicyBuilder.Policies.Expressions
{
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
}
