﻿// bb240318.1418

using System.Reflection;

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab
{
    /// <summary>Stop the current Abatab session.</summary>
    /// <remarks>
    /// Stops stuff.
    /// </remarks>
    public class Stop
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        /// - The executing assembly is defined at the start of the class so it can be easily used throughout the method
        /// when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Finalizes an Abatab session.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        public static void ExistingSession(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            LogEvent.Session(abSession);
        }
    }
}