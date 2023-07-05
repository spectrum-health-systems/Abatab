// b230516.0855

using System.Collections.Generic;
using Abatab.Core.Catalog.Definition;

namespace Abatab.Core.Catalog.Key
{
    /// <summary>Pre-defined lists of directories.</summary>
    public static class Directories
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static List<string> Framework(AbSession abSession) => new List<string>()
        {
            abSession.AbatabDataRoot,
            abSession.SessionDataDirectory,
            abSession.PublicDataRoot,
            abSession.AlertLogDirectory,
            abSession.DebugglerLogDirectory
        };

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static List<string> Session(AbSession abSession) => new List<string>()
        {
            abSession.SessionDataDirectory,
            abSession.TraceLogDirectory,
            abSession.WarningLogDirectory
        };
    }
}