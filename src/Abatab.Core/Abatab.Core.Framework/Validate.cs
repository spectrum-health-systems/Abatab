// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Framework.Validate.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------


using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.IO;
using System.Reflection;

namespace Abatab.Core.Framework
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Executing assembly name for log files.
        /// </summary>
        /// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Method summary goes here.
        /// </summary>
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