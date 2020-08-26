namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface ICacheLookupSectionBuilder : IPolicySectionBuilder
    {
        ICacheLookupSectionBuilder VaryByHeader(string value);

        ICacheLookupSectionBuilder VaryByQueryParameter(string value);
    }
}