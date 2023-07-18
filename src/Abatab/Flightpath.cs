// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Flightpath.cs
// Logic for starting/stopping an Abatab session.
// b230718.1104
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Logger;
using Abatab.Core.Session;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;
using System.Reflection;

namespace Abatab
{
    /// <summary>Logic for starting/stopping an Abatab session.</summary>
    public static class Flightpath
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Initialize a new Abatab session.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="scriptParameter">The Script Parameter sent from myAvatar. <see href="https://github.com">[More info]</see></param>
        /// <param name="sentOptionObject"></param>
        public static void InitializeAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);
            WebConfig.Load(abSession);
            Build.NewSession(sentOptionObject, scriptParameter, abSession);
            Validate.Status(abSession);
        }

        /// <summary>Finalizes an Abatab session.</summary>
        /// <param name="abSession"></param>
        public static void WrapUpAbatab(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);
            LogEvent.Session(abSession);
        }
    }
}