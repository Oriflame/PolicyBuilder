using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Policies.Expressions
{
    public class SingleStatementExpression : Expression
    {
        public SingleStatementExpression(string statement) : base(statement)
        {
        }

        public SingleStatementExpression(IContextProperty property) : base(property.ToString())
        {
        }

        public override string ToString()
        {
            return $"@({Statement})";
        }
    }
}
