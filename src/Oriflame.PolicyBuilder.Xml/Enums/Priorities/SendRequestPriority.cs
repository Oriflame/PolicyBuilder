namespace Oriflame.PolicyBuilder.Xml.Enums.Priorities
{
    public enum SendRequestPriority
    {
        Lowest = int.MaxValue,
        SetUrl = 1,
        SetMethod = 2,
        SetHeader = 3,
        SetBody = 4,
        AuthenticationCertificate = 5,
    }
}
