// AbatabData 24.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b230102.1026

namespace AbatabData.Core
{
    /// <summary>Properties for the logging functionality.</summary>
    public class Logging
    {
        /// <summary>The logging mode that Abatab will use when executed.</summary>
        /// <remarks>
        /// <list type="table">
        /// <listheader>
        /// <term>Setting</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><b><i>session</i></b></term>
        /// <description>Only session logs are created.</description>
        /// </item>
        /// <item>
        /// <term>trace</term>
        /// <description>Only trace logs are created.</description>
        /// </item>
        /// <item>
        /// <term>error</term>
        /// <description>Only error logs are created.</description>
        /// </item>
        /// <item>
        /// <term>warning</term>
        /// <description>Only warning logs are created.</description>
        /// </item>
        /// <item>
        /// <term>all</term>
        /// <description>All logs types are created.</description>
        /// </item>
        /// <item>
        /// <term>warning</term>
        /// <description>Do not create any log files.</description>
        /// </item>
        /// </list>
        /// * To create multiple types of logs, separate each type with a hypen (<c>"-"</c>).
        /// </remarks>
        /// <examples>
        /// * To only create session logs: <c>LoggingMode=session</c>
        /// * To create session and trace logs: <c>LoggingMode=session-trace</c>
        /// * To create session, trace, and warning logs: <c>LoggingMode=session-trace-warning</c>
        /// </examples>
        /// <value>Default value is <c>session</c></value>
        public string LoggingMode { get; set; }

        /// <summary>The detail level of log files (currently not used).</summary>
        /// <value>Currently not used.</value>
        public string Detail { get; set; }


        /// <summary>The root directory where the Abatab error logs are stored.</summary>
        /// <remarks>
        /// * At runtime the <c>EventErrorRoot</c> value is created as a sub-directory of the <c>AbatabDataRoot</c>.
        /// </remarks>
        /// <example>
        /// * If <c>AbatabDataRoot=C:\Abatab\LIVE</c>, and <c>DebugEventRoot=logs\debug</c>, then <c>DebugEventRoot</c> would be set to <c>C:\Abatab\LIVE\logs\debug</c> at runtime.
        /// </example>
        /// <value>Default value is <c>logs\debug</c></value>
        public string EventErrorRoot { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string EventLostRoot { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string EventTraceRoot { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string EventWarningRoot { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string Root { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string SessionRoot { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string WriteDelay { get; set; }
    }
}
