// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.IO;
using System.Reflection;

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