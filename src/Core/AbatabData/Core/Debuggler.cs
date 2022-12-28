// AbatabData 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221228.0852

namespace AbatabData.Core
{
    /// <summary>
    ///Properties for the logging functionality.
    /// </summary>
    public class Debuggler
    {
        /// <summary>
        /// The debug mode that Abatab will use when executed.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <listheader>
        /// <term>Setting</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><b><i>disabled</i></b></term>
        /// <description>Debugging functionality is disabled.</description>
        /// </item>
        /// <item>
        /// <term>enabled</term>
        /// <description>Debugging functionality is enabled.</description>
        /// </item>
        /// </list>
        /// * Debug mode can have a significant impact on performance, and should not be enabled in production environments.
        /// </remarks>
        /// <value>Default value is <c>disabled</c></value>
        public string DebugMode { get; set; }

        /// <summary>
        /// The root directory where the Abatab debug logs are stored.
        /// </summary>
        /// <remarks>
        /// * At runtime the <c>DebugEventRoot</c> value is created as a sub-directory of the <c>AbatabDataRoot</c>.
        /// </remarks>
        /// <example>
        /// * If <c>AbatabDataRoot=C:\Abatab\LIVE</c>, and <c>DebugEventRoot=logs\debug</c>, then <c>DebugEventRoot</c> would be set to <c>C:\Abatab\LIVE\logs\debug</c> at runtime.
        /// </example>
        /// <value>Default value is <c>logs\debug</c></value>
        public string DebugEventRoot { get; set; }
    }
}