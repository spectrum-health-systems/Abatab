// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221020.101121

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// Defines the properties for the AbatabData.Session object, containing the information/data that Abatab needs to do its job.
    /// </summary>
    public class Session
    {
        public string Mode { get; set; }
        public string Root { get; set; }
        public string AvatarFallbackUserName { get; set; }
        public Core.Debuggler DebugglerConfig { get; set; }
        public Core.Logging LoggingConfig { get; set; }
        public Module.Common ModCommonConfig { get; set; }
        public Module.Prototype ModPrototypeConfig { get; set; }
        public Module.QuickMedOrder ModQuickMedOrderConfig { get; set; }
        public Module.Testing ModTestingConfig { get; set; }
        public string SessionDateStamp { get; set; }
        public string SessionTimeStamp { get; set; }
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