using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.ApiExample.Settings
{
    public class HostConfig
    {
        public string HostUri { get; set; }

        public string ApiName { get; set; }

        public string Title { get; set; }

        public string Folder { get; set; }
    }

    public class HostConfigs
    {
        public IEnumerable<HostConfig> HostsCollection { get; set; }
    }
}