// AbatabData 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221212.0810

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// This class defines the properties for the Abatab session, built from the local Web.config file, and at runtime.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The current Abatab mode.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <listheader>
        /// <term>Setting</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><b><i>enabled</i></b></term>
        /// <description>All Abatab functionality is (potentially) available.</description>
        /// </item>
        /// <item>
        /// <term>disabled</term>
        /// <description>Abatab functionality is not available.</description>
        /// </item>
        /// <item>
        /// <term>passthrough</term>
        /// <description>All functionality is available, but no changes are made to Avatar.</description>
        /// </item>
        /// </list>
        /// * If Abatab is <c>enabled</c>, you are still able to disable specific functionality.
        /// * The <c>passthrough</c> mode is intended for development, not production.
        /// </remarks>
        /// <value>Default value is <c>enabled</c></value>
        public string AbatabMode { get; set; }

        /// <summary>
        /// The root directory where the Abatab web service has been deployed.
        /// </summary>
        /// <remarks>
        /// * At runtime The `AvatarEnvironment` value is added to the end of `AbatabRoot` to form the complete path.
        /// </remarks>
        /// <example>
        /// If <c>AbatabRoot</c> is <i>"C:\Abatab_"</i>, and <c>AvatarEnvironment</c> is <i>"LIVE"</i>, the root directory at runtime would be <c>C:\Abatab_LIVE</c>.
        /// </example>
        /// <value>Default value is <c>C:\Abatab_</c></value>
        public string AbatabRoot { get; set; }

        /// <summary>
        /// The root directory where the Abatab data is stored.
        /// </summary>
        /// <remarks>
        /// * At runtime The `AvatarEnvironment` value is created as a sub-directory of the `AbatabDataRoot`.
        /// * This is the directory where exported data/logs should be stored.
        /// </remarks>
        /// <example>
        /// If <c>AbatabDataRoot</c> is <i>"C:\Abatab"</i>, and <c>AvatarEnvironment</c> is <i>"LIVE"</i>, the root directory at runtime would be <c>C:\Abatab\LIVE</c>.
        /// </example>
        /// <value>Default value is <c>C:\Abatab</c></value>
        public string AbatabDataRoot { get; set; }

        /// <summary>
        /// The Avatar environment that will use Abatab.
        /// </summary>
        /// <value>Default value is <c>LIVE</c>.</value>
        public string AvatarEnvironment { get; set; }

        /// <summary>
        /// The current Avatar environment.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <listheader>
        /// <term>Environment name</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><b><i>LIVE</i></b></term>
        /// <description>The Avatar production environment.</description>
        /// </item>
        /// <item>
        /// <term>UAT</term>
        /// <description>The Avatar testing environment.</description>
        /// </item>
        /// <item>
        /// <term>SBOX</term>
        /// <description>The Avatar sandbox environment.</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <value>Default value is <c>LIVE</c></value>
        public string AbatabFallbackUserName { get; set; }

        /// <summary>
        /// Properties for the debugging functionality.
        /// </summary>
        /// <value>&lt;-- Click for more info</value>
        public Core.Debuggler DebugglerConfig { get; set; }

        /// <summary>
        /// Properties for the logging functionality.
        /// </summary>
        /// <value>&lt;-- Click for more info</value>
        public Core.Logging LoggingConfig { get; set; }

        /// <summary>
        /// Properties for the Common module.
        /// </summary>
        /// <value>&lt;-- Click for more info</value>
        public Module.Common ModCommonConfig { get; set; }


        /// <summary>
        /// Properties for the Prototype module.
        /// </summary>
        /// <value>&lt;-- Click for more info</value>
        public Module.Prototype ModPrototypeConfig { get; set; }

        /// <summary>
        /// Properties for the QuickMedOrder module.
        /// </summary>
        /// <value>&lt;-- Click for more info</value>
        public Module.QuickMedOrder ModQuickMedOrderConfig { get; set; }

        /// <summary>
        /// Properties for the Testing module.
        /// </summary>
        /// <value>&lt;-- Click for more info</value>
        public Module.Testing ModTestingConfig { get; set; }

        /// <summary>
        /// The session date.
        /// </summary>
        /// <remarks>
        /// * Uses the following syntax: <c>yyMMdd</c>
        /// </remarks>
        /// <value>Set at runtime</value>
        public string SessionDateStamp { get; set; }

        /// <summary>
        /// The session time.
        /// </summary>
        /// <remarks>
        /// * Uses the following syntax: <c>HHmmss</c>
        /// </remarks>
        /// <value>Set at runtime</value>
        public string SessionTimeStamp { get; set; }

        /// <summary>
        /// The Abatab user name
        /// </summary>
        /// <value>Set at runtime</value>
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