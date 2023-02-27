// Abatab.WebConfig.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using Abatab.Core.Catalog.Definition;
using Abatab.Properties;

namespace Abatab
{
    public static class WebConfig
    {
        public static void Load(AbSession abSession)
        {
            abSession.AbatabMode                                    = Settings.Default.AbatabMode;
            abSession.AbatabVersion                                 = Settings.Default.AbatabVersion;
            abSession.AbatabBuild                                   = Settings.Default.AbatabBuild;
            abSession.AbatabServiceRoot                             = Settings.Default.AbatabServiceRoot;
            abSession.AbatabDataRoot                                = Settings.Default.AbatabDataRoot;
            abSession.LoggerMode                                    = Settings.Default.LoggerMode;
            abSession.LoggerDelay                                   = Settings.Default.LoggerDelay;
            abSession.LoggerTypes                                   = Settings.Default.LoggerTypes;
            abSession.AvatarEnvironment                             = Settings.Default.AvatarEnvironment;
            abSession.AbatabFallbackUserName                        = Settings.Default.AbatabFallbackUserName;
            abSession.ModProgressNote.Mode                          = Settings.Default.ModProgressNoteMode;
            abSession.ModProgressNote.AuthorizedUsers               = Settings.Default.ModProgressNoteAuthorizedUsers;
            abSession.ModPrototype.Mode                             = Settings.Default.ModPrototypeMode;
            abSession.ModPrototype.AuthorizedUsers                  = Settings.Default.ModPrototypeAuthorizedUsers;
            abSession.ModQuickMedicationOrder.Mode                  = Settings.Default.ModQuickMedicationOrderMode;
            abSession.ModQuickMedicationOrder.AuthorizedUsers       = Settings.Default.ModQuickMedicationOrderAuthorizedUsers;
            abSession.ModQuickMedicationOrder.ValidOrderTypes       = Settings.Default.ModQuickMedicationOrderValidOrderTypes;
            abSession.ModQuickMedicationOrder.DosePercentBoundary   = Settings.Default.ModQuickMedicationOrderDosePercentBoundary;
            abSession.ModQuickMedicationOrder.DoseMilligramBoundary = Settings.Default.ModQuickMedicationOrderDoseMilligramBoundary;
            abSession.ModTesting.Mode                               = Settings.Default.ModTestingMode;
            abSession.DebugglerMode                                 = Settings.Default.DebugglerMode;
        }
    }
}