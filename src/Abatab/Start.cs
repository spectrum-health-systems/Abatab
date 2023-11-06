// -----------------------------------------------------------------------------
// Abatab.Start.cs: Start a new Abatab session.
// https://spectrum-health-systems.github.io/Abatab-Documentation-Project/source-code/abatab/abatab.start.html
// b231106.1013
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Session;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;
using System.Reflection;

namespace Abatab
{
    /// <summary>Logic for starting an Abatab session.</summary>
    public static class Start
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Initialize a new Abatab session.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="scriptParameter">The Script Parameter sent from myAvatar.</param>
        /// <param name="sentOptionObject">The OptionObject sent from myAvatar.</param>
        public static void NewSession(AbSession abSession,string scriptParameter,OptionObject2015 sentOptionObject)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            WebConfig.Load(abSession);

            Build.NewSession(sentOptionObject,scriptParameter,abSession);

            Validate.Status(abSession);
        }
    }
}