/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabData.csproj                                                                                v0.91.0
 * SessionData.cs                                                                            b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    public class SessionData
    {
        // web.config settings.
        public string AbatabMode { get; set; }
        public string DebugMode { get; set; }
        public string LoggingMode { get; set; }
        public string LoggingDetails { get; set; }
        public string AbatabRoot { get; set; }
        public string AvatarFallbackUserName { get; set; }

        // Runtime settings.
        public string SessionLogDirectory { get; set; }
        public string AvatarUserName { get; set; }
        public string AbatabRequest { get; set; }
        public string AbatabModule { get; set; }
        public string AbatabCommand { get; set; }
        public string AbatabAction { get; set; }
        public string AbatabOption { get; set; }

        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
    }
}
