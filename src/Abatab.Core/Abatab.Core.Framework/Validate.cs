// b230516.0855

using System.IO;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Core.Framework
{
    /// <summary>Summary goes here.</summary>
    public static class Validate
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        public static void Status(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            if (!Directory.Exists(abSession.SessionDataDirectory))
            {
                LogEvent.Trace("traceinternal", abSession, AssemblyName);

                Maintenance.Refresh(abSession);
            }
        }
    }
}