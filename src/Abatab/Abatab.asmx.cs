// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.asmx.cs
// Entry point for Abatab.
// b230713.1524
// -----------------------------------------------------------------------------

/* DEVNOTE
 * Write something about Abatab here.
 */

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;
using System.Reflection;
using System.Web.Services;

namespace Abatab
{
    /// <summary>
    /// Entry point for Abatab.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        /// <remarks>This method is required by myAvatar.</remarks>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.7";
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        /// <remarks>This method is required by myAvatar.</remarks>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Flightpath.InitializeAbatab(abSession, scriptParameter, sentOptionObject);

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