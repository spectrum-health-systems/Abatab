// Abatab.WebConfig.cs
// b230225.1723
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using Abatab.Properties;

namespace Abatab
{
    public static class WebConfig
    {
        public static Dictionary<string, string> Load()
        {
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

            /* All settings in Settings.settings need to be included here.
            */

            return new Dictionary<string, string>()
            {
                { "AbatabMode",                                    Settings.Default.AbatabMode },
                { "AbatabServiceRoot",                             Settings.Default.AbatabServiceRoot },
                { "AbatabDataRoot",                                Settings.Default.AbatabDataRoot },
                { "LoggerMode",                                    Settings.Default.LoggerMode },
                { "LoggerDelay",                                   Settings.Default.LoggerDelay },
                { "LoggerTypes",                                   Settings.Default.LoggerTypes },
                { "AvatarEnvironment",                             Settings.Default.AvatarEnvironment },
                { "AbatabFallbackUserName",                        Settings.Default.AbatabFallbackUserName },
                { "ModProgressNoteMode",                           Settings.Default.ModProgressNoteMode },
                { "ModProgressNoteAuthorizedUsers",                Settings.Default.ModProgressNoteAuthorizedUsers },
                { "ModPrototypeMode",                              Settings.Default.ModPrototypeMode },
                { "ModPrototypeAuthorizedUsers",                   Settings.Default.ModPrototypeAuthorizedUsers },
                { "ModQuickMedicationOrderMode",                   Settings.Default.ModQuickMedicationOrderMode },
                { "ModQuickMedicationOrderAuthorizedUsers",        Settings.Default.ModQuickMedicationOrderAuthorizedUsers  },
                { "ModQuickMedicationOrderValidOrderTypes",        Settings.Default.ModQuickMedicationOrderValidOrderTypes },
                { "ModQuickMedicationOrderDosePercentBoundary",    Settings.Default.ModQuickMedicationOrderDosePercentBoundary },
                { "ModQuickMedicationOrderDoseMilligramBoundary",  Settings.Default.ModQuickMedicationOrderDoseMilligramBoundary },
                { "ModTestingMode",                                Settings.Default.ModTestingMode },
                { "DebugglerMode",                                 Settings.Default.DebugglerMode }
            };
        }
    }
}