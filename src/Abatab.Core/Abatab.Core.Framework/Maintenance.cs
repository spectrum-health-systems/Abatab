// b230516.0855

using System.Collections.Generic;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Core.Framework
{
    /// <summary>Summary goes here.</summary>
    public static class Maintenance
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        public static void Refresh(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            VerifyDirectories(abSession);
            ExportCurrentSettings(abSession);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        private static void VerifyDirectories(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            List <string> frameworkDirectories = Catalog.Key.Directories.Framework(abSession);
            Utility.FileSys.VerifyDirectories(frameworkDirectories);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        private static void ExportCurrentSettings(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);
            LogEvent.CurrentSetting(abSession);
        }
    }
}