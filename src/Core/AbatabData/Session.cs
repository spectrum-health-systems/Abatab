// AbatabData 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221219.0925

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// Contains Abatab session properties.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The mode that Abatab will use when executed.
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
        /// <list type="bullet">
        /// <item>If this is set to <c>AbatabMode=enabled</c>, you are still able to disable specific modules via their corresponding mode setting.</item>
        /// <item>The <c>AbatabMode=passthrough</c> mode is intended for development, not production.</item>
        /// </list>
        /// </remarks>
        /// <value>Default value is <c>enabled</c></value>
        public string AbatabMode { get; set; }

        /// <summary>
        /// The root directory where the Abatab web service has been deployed.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>At runtime the <c>AvatarEnvironment</c> value is added to the end of <c>AbatabRoot</c> to form the complete path.</item>
        /// </list>
        /// </remarks>
        /// <example>
        /// If <c>AbatabRoot=C:\Abatab_</c>, and <c>AvatarEnvironment=LIVE</c>, then <c>AbatabRoot</c> would be set to <c>C:\Abatab_LIVE</c> at runtime.
        /// </example>
        /// <value>Default value is <c>C:\Abatab_</c></value>
        public string AbatabRoot { get; set; }

        /// <summary>
        /// The root directory where the Abatab data is stored.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>At runtime the <c>AvatarEnvironment</c> value is created as a sub-directory of the <c>AbatabDataRoot</c>.</item>
        /// <item>This is the directory where exported data/logs should be stored.</item>
        /// </list>
        /// </remarks>
        /// <example>
        /// If <c>AbatabDataRoot=C:\Abatab</c>, and <c>AvatarEnvironment=LIVE</c>, then <c>AbatabDataRoot</c> would be set to <c>C:\Abatab\LIVE</c> at runtime.
        /// </example>
        /// <value>Default value is <c>C:\Abatab</c></value>
        public string AbatabDataRoot { get; set; }

        /// <summary>
        /// The Avatar environment that Abatab will reference when executed.
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
        public string AvatarEnvironment { get; set; }

        /// <summary>
        /// The fallback username for Abatab.
        /// </summary>
        /// <remarks>
        /// * If <c>sentOptObj.OptionUserId</c> does not contain a valid username, <c>AbatabFallbackUserName</c> will be used.
        /// </remarks>
        /// <value>Default value is <c>_Abatab</c></value>
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
        /// The Abatab username.
        /// </summary>
        /// <remarks>
        /// * This should be set to the value in <c>sentOptObj.OptionUserId</c>
        /// * If the value in <c>sentOptObj.OptionUserId</c> is not valid, this will be set to <see href="AbatabData.Session.html#AbatabData_Session_AbatabFallbackUserName">AbatabFallbackUserName</see>.
        /// </remarks>
        /// <value>Set at runtime</value>
        public string AbatabUserName { get; set; }

        /// <summary>
        /// The Script Parameter that Avatar sends to Abatab.
        /// </summary>
        /// <remarks>
        /// * Script Parameter syntax is <c>MODULE-COMMAND-ACTION[-OPTION]</c>
        /// * More information about the Script Parameter can be found <see href="../man/manAppendix.html#script-parameter">here.</see>
        /// </remarks>
        /// <example>
        /// <code>
        /// QuickMedOrder-Dose-VerifyAmount
        /// </code>
        /// </example>
        /// <value>Set at runtime</value>
        public string ScriptParameter { get; set; }

        /// <summary>
        /// The Module component of the Script Parameter.
        /// </summary>
        /// <remarks>
        /// * This is the first component of the <see href="AbatabData.Session.html#AbatabData_Session_ScriptParameter">Script Parameter</see>.
        /// </remarks>
        /// <example>
        /// * The Script Parameter <c>QuickMedOrder-Dose-VerifyAmount</c> uses the <c>QuickMedOrder</c> module.
        /// </example>
        /// <value>Set at runtime</value>
        public string AbatabModule { get; set; }

        /// <summary>
        /// The Command component of the Script Parameter.
        /// </summary>
        /// <remarks>
        /// * This is the second component of the <see href="AbatabData.Session.html#AbatabData_Session_ScriptParameter">Script Parameter</see>.
        /// </remarks>
        /// <example>
        /// * The Script Parameter <c>QuickMedOrder-Dose-VerifyAmount</c> contains the <c>Dose</c> command.
        /// </example>
        /// <value>Set at runtime</value>
        public string AbatabCommand { get; set; }

        /// <summary>
        /// The **Action component** of the Script Parameter.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>This is the third component of the <see href="AbatabData.Session.html#AbatabData_Session_ScriptParameter">Script Parameter</see>.</item>
        /// </list>
        /// </remarks>
        /// <example>
        /// The Script Parameter <c>QuickMedOrder-Dose-VerifyAmount</c> contains the <c>VerifyAmount</c> action.
        /// </example>
        /// <value>Set at runtime.</value>
        public string AbatabAction { get; set; }

        /// <summary>
        /// The (optional) Option component of the Script Parameter.
        /// </summary>
        /// <remarks>
        /// * This is the fourth component of the <see href="AbatabData.Session.html#AbatabData_Session_ScriptParameter">Script Parameter</see>.
        /// * This is an optional component.
        /// </remarks>
        /// <example>
        /// * The Script Parameter <c>QuickMedOrder-Dose-VerifyAmount-PrintToScreen</c> contains the <c>PrintToScreen</c> action.
        /// </example>
        /// <value>Set at runtime</value>
        public string AbatabOption { get; set; }

        /// <summary>
        /// The OptionObject that Avatar sends to Abatab.
        /// </summary>
        /// <remarks>
        /// * This OptionObject is not modified by Abatab.
        /// * More information about the OptionObjects can be found <see href="../man/manAppendix.html#optionobject">here.</see>
        /// </remarks>
        /// <value>Set at runtime</value>
        public OptionObject2015 SentOptObj { get; set; }

        /// <summary>
        /// The OptionObject that Abatab (potentially) modifies during a session.
        /// </summary>
        /// <remarks>
        /// * This OptionObject starts out as a copy of <c>SentOptObj</c>.
        /// * This OptionObject is potentially modified by Abatab.
        /// * More information about the OptionObjects can be found <see href="../man/manAppendix.html#optionobject">here.</see>
        /// </remarks>
        /// <value>Set at runtime</value>

        public OptionObject2015 WorkOptObj { get; set; }

        /// <summary>
        /// The OptionObject that Abatab sends back to Avatar.
        /// </summary>
        /// <remarks>
        /// * This OptionObject is a copy of <c>WorkOptObj</c>.
        /// * More information about the OptionObjects can be found <see href="../man/manAppendix.html#optionobject">here.</see>
        /// </remarks>
        /// <value>Set at runtime</value>
        public OptionObject2015 FinalOptObj { get; set; }
    }
}