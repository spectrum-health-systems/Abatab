// =============================================================================
// Abatab: A custom web service/framework for Avatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
//
// For details about this release, please see the local Source Code README.md:
//   Abatab/README.md
// =============================================================================

// b231107.1015

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;
using System.Reflection;
using System.Web.Services;

namespace Abatab
{
    /// <summary>Entry point for Abatab.</summary>
    /// <remarks>
    ///     - This class <i>should not be modified</i> unless there is a major change to the framework.
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab :WebService
    {
        /// <summary>Returns the current version of Abatab.</summary>
        /// <remarks>
        ///     - This method is required by Avatar!
        ///     - The version number the current development version in `YY.MM` format.
        /// </remarks>
        /// <returns>The current version of Abatab.</returns>
        [WebMethod]
        public string GetVersion() => "VERSION 23.12";

        /// <summary>The starting point for Abatab.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from myAvatar.</param>
        /// <param name="scriptParameter">The Script Parameter from myAvatar.</param>
        /// <remarks>
        ///    - This method is required by myAvatar!
        /// </remarks>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject,string scriptParameter)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Start.NewSession(abSession,scriptParameter,sentOptionObject);

                Roundhouse.ParseModule(abSession);

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