// AbatabData 22.11.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221108.081135

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// Defines the properties for the AbatabData.Session object, containing the information/data that Abatab needs to do its job.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The default behavior of Abatab. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#AbatabMode"> [more info]</see>
        /// </summary>
        /// <value>Default value is <c>enabled</c>.</value>
        public string AbatabMode { get; set; }

        /// <summary>
        /// The Abatab root directory. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#AbatabRoot">. [more info]</see>
        /// </summary>
        /// <value>Default value is <c>C:\Abatab_</c>.</value>
        public string AbatabRoot { get; set; }

        /// <summary>
        /// The current Avatar environment. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#AvatarEnvironment">. [more info]</see>
        /// </summary>
        /// <value>Default value is <c>LIVE</c>.</value>
        public string AvatarEnvironment { get; set; }

        public string AbatabFallbackUserName { get; set; }
        public Core.Debuggler DebugglerConfig { get; set; }
        public Core.Logging LoggingConfig { get; set; }
        public Module.Common ModCommonConfig { get; set; }
        public Module.Prototype ModPrototypeConfig { get; set; }
        public Module.QuickMedOrder ModQuickMedOrderConfig { get; set; }
        public Module.Testing ModTestingConfig { get; set; }
        public string SessionDateStamp { get; set; }
        public string SessionTimeStamp { get; set; }
        public string AbatabUserName { get; set; }
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