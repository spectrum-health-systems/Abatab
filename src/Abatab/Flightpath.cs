// b230615.1008

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Logger;
using Abatab.Core.Session;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Handles high-level program flow.</summary>
    public static class Flightpath
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/InitializeAbatab/*' />
        public static void InitializeAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            WebConfig.Load(abSession);

            Build.NewSession(sentOptionObject, scriptParameter, abSession);

            Validate.Status(abSession);
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/WrapUpAbatab/*' />
        public static void WrapUpAbatab(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);
            LogEvent.Session(abSession);
        }
    }
}