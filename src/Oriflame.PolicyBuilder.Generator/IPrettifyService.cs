using System;
using System.Collections.Generic;
using System.Text;

namespace Oriflame.PolicyBuilder.Generator
{
    public interface IPrettifyService
    {
        string PrettifyContent(string xmlContent);
        void PrettifyFile(string path);
    }
}
