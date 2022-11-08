// AbatabData 22.11.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221108.134404

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// Defines the properties for the AbatabData.Session object, containing the information/data that Abatab needs to do its job.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The default behavior of Abatab. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#abatabmode"> [more info]</see>
        /// </summary>
        /// <value>Default value is <c>enabled</c>.</value>
        public string AbatabMode { get; set; }

        /// <summary>
        /// The Abatab root directory. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#abatabroot">. [more info]</see>
        /// </summary>
        /// <value>Default value is <c>C:\Abatab_</c>.</value>
        public string AbatabRoot { get; set; }

        /// <summary>
        /// The current Avatar environment. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#avatarenvironment">. [more info]</see>
        /// </summary>
        /// <value>Default value is <c>LIVE</c>.</value>
        public string AvatarEnvironment { get; set; }

        /// <summary>
        /// The current Avatar environment. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#abatabfallbackusername">. [more info]</see>
        /// </summary>
        /// <value>Default value is <c>_Abatab</c>.</value>
        public string AbatabFallbackUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Core.Debuggler DebugglerConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Core.Logging LoggingConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Module.Common ModCommonConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Module.Prototype ModPrototypeConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Module.QuickMedOrder ModQuickMedOrderConfig { get; set; }

        /// <summary>
        /// Properties for the <see href="https://spectrum-health-systems.github.io/Abatab/api/AbatabData.Module.Testing.html"> Abatab Testing Module.</see>
        /// </summary>
        /// <value>See documentation for the <see href="https://spectrum-health-systems.github.io/Abatab/api/AbatabData.Module.Testing.html"> Abatab Testing Module.</see></value>
        public Module.Testing ModTestingConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string SessionDateStamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string SessionTimeStamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AbatabUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AbatabRequest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AbatabModule { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AbatabCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AbatabAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AbatabOption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public OptionObject2015 SentOptObj { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        public OptionObject2015 WorkOptObj { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public OptionObject2015 FinalOptObj { get; set; }
    }
}