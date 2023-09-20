// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// For more information, please see the Abatab Documenation Project
// https://spectrum-health-systems.github.io/Abatab-Documentation-Project/

// -----------------------------------------------------------------------------
// Abatab.asmx.cs
// Entry point for Abatab.
// b230920.1206
// -----------------------------------------------------------------------------

/* DEVNOTE
 * The development version of Abatab is not intended for use in production
 * environments. Please visit the Abatab Community Release repository:
 * https://github.com/spectrum-health-systems/Abatab-Community-Release
 */

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;
using System.Reflection;
using System.Web.Services;

namespace Abatab
{
    /// <summary>Entry point for Abatab.</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab :WebService
    {
        /// <summary>Returns the current version of Abatab.</summary>
        /// <remarks>This method is required by myAvatar.</remarks>
        /// <returns>The current version of Abatab.</returns>
        [WebMethod]
        public string GetVersion() => "VERSION 23.8";

        /// <summary>The starting point for Abatab!</summary>
        /// <param name="sentOptionObject">The OptionObject sent from myAvatar.</param>
        /// <param name="scriptParameter">The Script Parameter sent from myAvatar.</param>
        /// <remarks>This method is required by myAvatar.</remarks>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject,string scriptParameter)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Flightpath.InitializeAbatab(abSession,scriptParameter,sentOptionObject);
                Roundhouse.ParseModule(abSession);
                Flightpath.WrapUpAbatab(abSession);
            }
            else
            {
                Debuggler.PrimevalLog("disabled");
            }

            return abSession.ReturnOptionObject;
        }
    }
}