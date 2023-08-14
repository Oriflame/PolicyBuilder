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
}
