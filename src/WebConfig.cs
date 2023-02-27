// Abatab.WebConfig.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utilities;
using Abatab.Properties;

namespace Abatab
{
    public static class WebConfig
    {
        public static void Load(AbSession abSession)
        {
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

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

            abSession.ModProgressNote = new ModProgressNote
            {
                Mode            = Settings.Default.ModProgressNoteMode,
                AuthorizedUsers = Settings.Default.ModProgressNoteAuthorizedUsers
            };

            abSession.ModPrototype = new ModPrototype
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

            abSession.ModTesting = new ModTesting
            {
                Mode = Settings.Default.ModTestingMode
            };

            abSession.DebugglerMode                                 = Settings.Default.DebugglerMode;

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

        }
    }
}