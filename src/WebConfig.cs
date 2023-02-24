using System.Collections.Generic;
using System.Reflection;
using Abatab.Core.Logger;
using Abatab.Properties;

namespace Abatab
{
    public class WebConfig
    {
        public static Dictionary<string, string> Load()
        {
            /* For testing/debugging only */
            LogEvent.Debuggler($@"C:\AbatabData\UAT\debuggler\", Assembly.GetExecutingAssembly().GetName().Name);

            return new Dictionary<string, string>()
            {
                { "AbatabMode",                                    Settings.Default.AbatabMode },
                { "AbatabServiceRoot",                             Settings.Default.AbatabServiceRoot },
                { "AbatabDataRoot",                                Settings.Default.AbatabDataRoot },
                { "LoggerMode",                                    Settings.Default.LoggerMode },
                { "LoggerDelay",                                   Settings.Default.LoggerDelay },
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
                { "ModQuickMedicationOrderDoseMilligramsBoundary", Settings.Default.ModQuickMedicationOrderDoseMilligramsBoundary },
                { "TestingMode",                                   Settings.Default.ModTestingMode },
                { "DebugglerMode",                                 Settings.Default.DebugglerMode }
            };
        }
    }
}