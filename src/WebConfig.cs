// Abatab.WebConfig.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Session;
using Abatab.Core.Utility;
using Abatab.Properties;

namespace Abatab
{
    /// <summary>Summary goes here.</summary>
    public static class WebConfig
    {
        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="WebConfig.cs"]/Load/*' />
        public static void Load(AbSession abSession)
        {
            /* INFO: Debuggler statement here, since a Trace log won't work. Helpful for development.
             */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            abSession.AbatabMode              = Settings.Default.AbatabMode;
            abSession.AbatabVersion           = Settings.Default.AbatabVersion;
            abSession.AbatabBuild             = Settings.Default.AbatabBuild;
            abSession.AbatabServiceRoot       = Settings.Default.AbatabServiceRoot;
            abSession.AbatabDataRoot          = Settings.Default.AbatabDataRoot;
            abSession.LoggerMode              = Settings.Default.LoggerMode;
            abSession.LoggerDelay             = Settings.Default.LoggerDelay;
            abSession.LoggerTypes             = Settings.Default.LoggerTypes;
            abSession.AvatarEnvironment       = Settings.Default.AvatarEnvironment;
            abSession.AbatabFallbackUserName  = Settings.Default.AbatabFallbackUserName;
            abSession.DebugglerMode           = Settings.Default.DebugglerMode;
            abSession.ModProgressNote         = new ModProgressNote
            {
                Mode            = Settings.Default.ModProgressNoteMode,
                AuthorizedUsers = Settings.Default.ModProgressNoteAuthorizedUsers
            };
            abSession.ModPrototype            = new ModPrototype
            {
                Mode            = Settings.Default.ModPrototypeMode,
                AuthorizedUsers = Settings.Default.ModPrototypeAuthorizedUsers
            };
            abSession.ModQuickMedicationOrder = new ModQuickMedicationOrder
            {
                Mode                  = Settings.Default.ModQuickMedicationOrderMode,
                AuthorizedUsers       = Settings.Default.ModQuickMedicationOrderAuthorizedUsers,
                ValidOrderTypes       = Settings.Default.ModQuickMedicationOrderValidOrderTypes,
                DosePercentBoundary   = Settings.Default.ModQuickMedicationOrderDosePercentBoundary,
                DoseMilligramBoundary = Settings.Default.ModQuickMedicationOrderDoseMilligramBoundary
            };
            abSession.ModTesting              = new ModTesting
            {
                Mode = Settings.Default.ModTestingMode
            };
        }
    }
}