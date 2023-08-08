namespace Oriflame.PolicyBuilder.Policies.Expressions
{
    public class MultiStatementExpression : Expression
    {
        public MultiStatementExpression(string statement) : base(statement)
        {
        }

        public override string ToString()
        {
            return $"@{{ {Statement} }}";
        }
    }
}
