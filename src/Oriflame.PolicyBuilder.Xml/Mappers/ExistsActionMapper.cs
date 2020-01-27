using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Xml.Mappers
{
    public static class ExistsActionMapper
    {
        public static string Map(ExistsAction? existsAction)
        {
            switch (existsAction)
            {
                case ExistsAction.Skip:
                    return "skip";
                case ExistsAction.Append:
                    return "append";
                case ExistsAction.Delete:
                    return "delete";
                case ExistsAction.Override:
                default:
                    return "override";
            }
        }
    }
}
