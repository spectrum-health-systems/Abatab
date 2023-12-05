// b231106.1013

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab
{
    /// <summary>Logic for stopping an Abatab session.</summary>
    public class Stop
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - Define this now so it can be used throughout the class.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Finalizes an Abatab session.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        public static void ExistingSession(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            LogEvent.Session(abSession);
        }
    }
}