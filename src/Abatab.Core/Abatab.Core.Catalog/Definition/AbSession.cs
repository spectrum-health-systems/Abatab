// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Definition.AbSession.cs
// Properties for the AbSession object.
// b230713.1524
// -----------------------------------------------------------------------------

using ScriptLinkStandard.Objects;
using System.Collections.Generic;

namespace Abatab.Core.Catalog.Definition
{
    /// <summary>
    /// Properties for the AbSession object.
    /// </summary>
    /// <remarks>
    /// The AbSession object contains all of the necessary information that Abatab needs to do what it does.
    /// </remarks>
    public class AbSession
    {
        /* Local settings from Web.config file */

        public string AbatabMode { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabVersion { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabBuild { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabServiceRoot { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabDataRoot { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LoggerMode { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LoggerTypes { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LoggerDelay { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AvatarEnvironment { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabFallbackUserName { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabEmailAddress { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabEmailPassword { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DebugglerMode { get; set; }

        /* Runtime settings */

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Datestamp { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string RequestModule { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string RequestCommand { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string RequestAction { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string RequestOption { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabUserName { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string SessionDataRoot { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string SessionDataDirectory { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string TraceLogDirectory { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string WarningLogDirectory { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string PublicDataRoot { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AlertLogDirectory { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DebugglerLogDirectory { get; set; }

        //OptionObject

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /* Module-specific */

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public ModProgNote ModProgNote { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public ModProto ModProto { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public ModQMedOrdr ModQMedOrdr { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public ModTesting ModTesting { get; set; }
    }

    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public class ModProgNote
    {
        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Users { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string ServiceChargeCodeFieldId { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public List<string> FlaggedServiceChargeCodePrefixes { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public List<string> FlaggedServiceChargeCodeCodes { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LocationFieldId { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public List<string> ValidLocationCodes { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public List<string> ValidLocationNames { get; set; }
    }

    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public class ModProto
    {
        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Users { get; set; }
    }

    // Quick Medication Order module

    /// <summary>
    /// Class summary goes here.
    /// </summary>

    public class ModQMedOrdr
    {
        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Users { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string OrderTypeFieldId { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string ValidOrderTypes { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LastOrderScheduleFieldId { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LastOrderScheduleText { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LastScheduledDosage { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string PreviousDosePrefix { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string PreviousDoseSuffix { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DosageOneFieldId { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string CurrentDosage { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DosePercentBoundary { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DoseMilligramBoundary { get; set; }
    }

    /// <summary>
    /// Class summary goes here.
    /// </summary>

    public class ModTesting
    {
        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string Mode { get; set; }
    }
}