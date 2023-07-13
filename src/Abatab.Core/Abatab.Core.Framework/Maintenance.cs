// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Collections.Generic;
using System.Reflection;

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