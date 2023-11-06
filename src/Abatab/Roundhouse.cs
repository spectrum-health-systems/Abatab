// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// b231106.1009

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Parses the module component of the <see href="https://spectrum-health-systems.github.io/Abatab-Documentation-Project/glossary.html#Script_Parameter">Script Parameter</see>.
    /// </summary>
    /// <remarks>
    ///     - This class will need to be modified when a new <see href="https://spectrum-health-systems.github.io/Abatab-Documentation-Project/glossary.html#Abatab_Module">Abatab Module</see> is added.
    /// </remarks>
    public static class Roundhouse
    {
        /// <summary>
        /// Executing assembly name for log files.
        /// </summary>
        /// <remarks>
        ///     - This is defined at the start of the class so it can be easily used throughout the method when creating
        ///       log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Parses the `module` component of the `module-command-action[-option]` <see href="https://spectrum-health-systems.github.io/Abatab-Documentation-Project/glossary.html#Script_Parameter">Script Parameter</see> sent from myAvatar.
        /// </summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <remarks>
        ///     - This method <i>will need to be modified</i> when a new Module functionality is added.
        ///     - This method <i>does not need to be modified</i> when new a new command-action[-option] for an existing
        ///       module is added, since that is handled by the Roundhouse class of the individual Module.
        /// </remarks>
        public static void ParseModule(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.Testing.Roundhouse.ParseCommand(abSession);

                    break;

                case "prognote":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.ProgressNote.Roundhouse.ParseCommand(abSession);

                    break;

                case "qmedordr":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.QuickMedicationOrder.Roundhouse.ParseCommand(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    // TODO Eventually this should exit gracefully

                    break;
            }
        }
    }
}