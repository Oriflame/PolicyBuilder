using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Policies.Expressions
{
    public class MultiStatementExpression : Expression
    {
        public MultiStatementExpression(string statement) : base(statement)
        {
        }

        public MultiStatementExpression(IContextProperty property) : base(property.ToString())
        {
        }

        public override string ToString()
        {
            return $"@{{ {Statement} }}";
        }
    }
}
