namespace Oriflame.PolicyBuilder.Xml.Enums.Priorities
{
    public enum SendRequestPriority
    {
        Default = 0,
        SetUrl = -10,
        SetMethod = -9,
        SetBody = -8,
        SetHeader = -7,
        AuthenticationCertificate = -6,
    }
}
