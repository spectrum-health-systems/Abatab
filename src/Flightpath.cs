// b---------x

using System.Reflection;
using Abatab.Core.Catalog.Definition;
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

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/StartAbatab/*' />
        public static void InitializeAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            //// Please see replacewith_DebugglerModeInfoLink for more information about DebugglerMode.
            //if (Settings.Default.DebugglerMode == "enabled")
            //{
            //    LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            //}

            WebConfig.Load(abSession);
            Build.NewSession(sentOptionObject, scriptParameter, abSession);

            Core.Framework.Validate.Status(abSession);
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/FinishAbatab/*' />
        public static void WrapUpAbatab(AbSession abSession)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            //// Please see replacewith_DebugglerModeInfoLink for more information about DebugglerMode.
            //if (Settings.Default.DebugglerMode == "enabled")
            //{
            //    LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            //}

            LogEvent.Trace("trace", abSession, AssemblyName);
            LogEvent.Session(abSession);
        }
    }
}