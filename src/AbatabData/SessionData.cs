/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabData.csproj                                                                                v0.92.0
 * SessionData.cs                                                                            b221010.124123
 * --------------------------------------------------------------------------------------------------------
 * Defines the properties for the SessionData object, which contains all of the information/data that
 * Abatab needs to do its job.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    public class SessionData
    {
        // Web.config: General
        public string AbatabMode { get; set; }
        public string AbatabRoot { get; set; }
        public string DebugMode { get; set; }
        public string DebugLogRoot { get; set; }
        public string LoggingMode { get; set; }
        public string LoggingDetail { get; set; }
        public string LoggingDelay { get; set; }
        public string AvatarFallbackUserName { get; set; }

        // Web.config: ModuleDate
        public string ModDateMode { get; set; }

        // Web.config: ModuleDose
        public string ModQuickMedOrderMode { get; set; }
        public string ModQuickMedOrderPrevDosePrefix { get; set; }
        public string ModQuickMedOrderPrevDoseSuffix { get; set; }
        public string ModQuickMedOrderDosePercentMaxInc { get; set; }

        // Web.config: ModulePrototype
        public string ModPrototypeMode { get; set; }

        // Web.config: ModuleTesting
        public string ModTestingMode { get; set; }

        // Set at runtime: General
        public string SessionTimestamp { get; set; }
        public string SessionLogRoot { get; set; }
        public string AvatarUserName { get; set; }
        public string AbatabRequest { get; set; }
        public string AbatabModule { get; set; }
        public string AbatabCommand { get; set; }
        public string AbatabAction { get; set; }
        public string AbatabOption { get; set; }

        // Set at runtime: OptionObject details
        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
    }
}