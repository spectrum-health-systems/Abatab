// =============================================================================
// Abatab: A custom web service/framework for Avatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
//
// For details about this release, please see the local Source Code README.md:
//   Abatab/README.md
// =============================================================================

// b240318.1355

using System.Reflection;
using System.Web.Services;

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using Abatab.Properties;

using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>The entry class for Abatab.</summary>
    /// <remarks>
    /// - This class is designed to be static, and should not be modified.
    /// - For more information about why this class is designed the way it is, please read about <see href="https://github.com/spectrum-health-systems/Abatab-Documentation-Project/blob/main/Development/the-methedology-behind-abatab.md">the methodology behind Abatab</see>.
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>Returns the current version of Abatab.</summary>
        /// <remarks>
        /// - This method is required by Avatar.
        /// - The version number the current development version in `YY.MM` format.
        /// </remarks>
        /// <returns>The current version of Abatab.</returns>
        [WebMethod]
        public string GetVersion() => "VERSION 24.3";

        /// <summary>The starting method for Abatab.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from myAvatar.</param>
        /// <param name="sentScriptParameter">The Script Parameter sent from myAvatar.</param>
        /// <remarks>
        /// This method is required by Avatar.
        /// </remarks>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Start.NewSession(abSession, sentScriptParameter, sentOptionObject);

                Roundhouse.SendToModule(abSession);

                Stop.ExistingSession(abSession);
            }
            else
            {
                Debuggler.PrimevalLog("disabled");
            }

            return abSession.ReturnOptionObject;
        }
    }
}