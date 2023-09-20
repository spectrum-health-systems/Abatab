// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Framework.Validate.cs
// Class summary goes here.
// b230810.1111
// -----------------------------------------------------------------------------


using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.IO;
using System.Reflection;

namespace Abatab.Core.Framework
{
    /// <summary>Validate Abatab framework components.</summary>
    public static class Validate
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Verify framework status.</summary>
        /// <param name="abSession">The Abatab session object.</param>
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