// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221018.082641

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// Defines the properties for the AbatabData.Session object, containing the information/data that Abatab needs to do its job.
    /// </summary>
    public class Session
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

        // Web.config: ModQuickMedOrder
        public string ModQuickMedOrderMode { get; set; }

        public string ModQuickMedOrderValidUsers { get; set; }
        public string ModQuickMedOrderDosePercentMaxInc { get; set; }

        // Set at runtime: ModQuickMedOrder
        public QuickMedOrder ModQuickMedOrderData { get; set; }

        // Web.config: ModPrototype
        public string ModPrototypeMode { get; set; }

        // Web.config: ModTesting
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