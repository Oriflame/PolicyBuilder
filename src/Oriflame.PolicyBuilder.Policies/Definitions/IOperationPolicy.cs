namespace Oriflame.PolicyBuilder.Policies.Definitions
{
    public interface IOperationPolicy : IPolicy
    {
        /// <summary>
        /// Allows you to transform Policy object to another object with specific policy representation  
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        TResult TransformTo<TResult>() where  TResult : class;
    }
}