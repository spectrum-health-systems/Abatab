// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.WebConfig.cs: Logic for the local Web.config file.
// https://spectrum-health-systems.github.io/Abatab-Documentation-Project/source-code/abatab/abatab.webconfig.html
// b231106.1013
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using Abatab.Properties;
using System.Linq;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Logic for the local Web.config file.
    /// </summary>
    public static class WebConfig
    {
        /// <summary>
        /// Loads the configuration settings from the local Web.config file.
        /// </summary>
        /// <param name="abSession">The Abatab session object.</param>
        public static void Load(AbSession abSession)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            abSession.AbatabMode             = Settings.Default.AbatabMode;
            abSession.AbatabVersion          = Settings.Default.AbatabVersion;
            abSession.AbatabBuild            = Settings.Default.AbatabBuild;
            abSession.AbatabServiceRoot      = Settings.Default.AbatabServiceRoot;
            abSession.AbatabDataRoot         = Settings.Default.AbatabDataRoot;
            abSession.LoggerMode             = Settings.Default.LoggerMode;
            abSession.LoggerDelay            = Settings.Default.LoggerDelay;
            abSession.LoggerTypes            = Settings.Default.LoggerTypes;
            abSession.AvatarEnvironment      = Settings.Default.AvatarEnvironment;
            abSession.AbatabFallbackUserName = Settings.Default.AbatabFallbackUserName;
            abSession.AbatabEmailAddress     = Settings.Default.AbatabEmailAddress;
            abSession.AbatabEmailPassword    = Settings.Default.AbatabEmailPassword;
            abSession.DebugglerMode          = Settings.Default.DebugglerMode;

            abSession.ModProgNote = new ModProgNote
            {
                Mode                             = Settings.Default.ModProgNoteMode,
                Users                            = Settings.Default.ModProgNoteUsers,
                ServiceChargeCodeFieldId         = Settings.Default.ModProgNoteServiceChargeCodeFieldId,
                FlaggedServiceChargeCodePrefixes = Settings.Default.ModProgNoteFlaggedServiceChargeCodePrefixes.Cast<string>().ToList(),
                FlaggedServiceChargeCodeCodes    = Settings.Default.ModProgNoteFlaggedServiceChargeCodeCodes.Cast<string>().ToList(),
                LocationFieldId                  = Settings.Default.ModProgNoteLocationFieldId,
                ValidLocationNames               = Settings.Default.ModProgNoteValidLocationNames.Cast<string>().ToList(),
                ValidLocationCodes               = Settings.Default.ModProgNoteValidLocationCodes.Cast<string>().ToList(),
            };

            abSession.ModProto = new ModProto
            {
                Mode  = Settings.Default.ModProtoMode,
                Users = Settings.Default.ModProtoUsers
            };

            abSession.ModQMedOrdr = new ModQMedOrdr
            {
                Mode                  = Settings.Default.ModQMedOrdrMode,
                Users                 = Settings.Default.ModQMedOrdrUsers,
                OrderTypeFieldId      = Settings.Default.ModQMedOrdrOrderTypeFieldId,
                ValidOrderTypes       = Settings.Default.ModQMedOrdrValidOrderTypes,
                DosePercentBoundary   = Settings.Default.ModQMedOrdrDosePercentBoundary,
                DoseMilligramBoundary = Settings.Default.ModQMedOrdrDoseMilligramBoundary
            };

            abSession.ModTesting = new ModTesting
            {
                Mode = Settings.Default.ModTestingMode
            };
        }
    }
}