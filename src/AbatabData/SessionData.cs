/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabData.csproj                                                                                v0.91.0
 * SessionData.cs                                                                            b221009.083236
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* The SessionData properties that contain all of the information/data Abatab needs to do it's job.
 */

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    public class SessionData
    {
        // Web.config settings.
        public string AbatabMode { get; set; }
        public string AbatabRoot { get; set; }
        public string DebugMode { get; set; }
        public string DebugLogRoot { get; set; }
        public string LoggingMode { get; set; }
        public string LoggingDetail { get; set; }
        public string LoggingDelay { get; set; }
        public string AvatarFallbackUserName { get; set; }

        // Runtime settings.
        public string SessionTimestamp { get; set; }
        public string SessionLogDir { get; set; }
        public string AvatarUserName { get; set; }
        public string AbatabRequest { get; set; }
        public string AbatabModule { get; set; }
        public string AbatabCommand { get; set; }
        public string AbatabAction { get; set; }
        public string AbatabOption { get; set; }

        // OptionObjects
        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
    }
}