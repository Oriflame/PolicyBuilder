namespace Oriflame.PolicyBuilder.Xml.Enums.Priorities
{
    public enum SendRequestPriority
    {
        Lowest = int.MaxValue,
        SetUrl = 1,
        SetMethod = 2,
        SetBody = 3,
        SetHeader = 4,
        AuthenticationCertificate = 5,
    }
}
