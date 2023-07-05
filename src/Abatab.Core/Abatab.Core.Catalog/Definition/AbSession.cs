// b230516.0855

/* DEVNOTE: Some of this doesn't follow the commenting guidelines.
 */

using System.Collections.Generic;
using ScriptLinkStandard.Objects;

namespace Abatab.Core.Catalog.Definition
{
    /// <summary>Properties for the AbSession object.</summary>
    /// <remarks>
    /// The AbSession object contains all of the necessary information that Abatab needs to do what it does.
    /// </remarks>
    public class AbSession
    {
        // local

        /// <summary>Summary goes here.</summary>
        public string AbatabMode { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabVersion { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabBuild { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabServiceRoot { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabDataRoot { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LoggerMode { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LoggerTypes { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LoggerDelay { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AvatarEnvironment { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabFallbackUserName { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabEmailAddress { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabEmailPassword { get; set; }

        /// <summary>Summary goes here.</summary>
        public string DebugglerMode { get; set; }

        // Runtime

        /// <summary>Summary goes here.</summary>
        public string Datestamp { get; set; }

        /// <summary>Summary goes here.</summary>
        public string Timestamp { get; set; }

        /// <summary>Summary goes here.</summary>
        public string RequestModule { get; set; }

        /// <summary>Summary goes here.</summary>
        public string RequestCommand { get; set; }

        /// <summary>Summary goes here.</summary>
        public string RequestAction { get; set; }

        /// <summary>Summary goes here.</summary>
        public string RequestOption { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AbatabUserName { get; set; }

        /// <summary>Summary goes here.</summary>
        public string SessionDataRoot { get; set; }

        /// <summary>Summary goes here.</summary>
        public string SessionDataDirectory { get; set; }

        /// <summary>Summary goes here.</summary>
        public string TraceLogDirectory { get; set; }

        /// <summary>Summary goes here.</summary>
        public string WarningLogDirectory { get; set; }

        /// <summary>Summary goes here.</summary>
        public string PublicDataRoot { get; set; }

        /// <summary>Summary goes here.</summary>
        public string AlertLogDirectory { get; set; }

        /// <summary>Summary goes here.</summary>
        public string DebugglerLogDirectory { get; set; }

        //OptionObject

        /// <summary>Summary goes here.</summary>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>Summary goes here.</summary>
        public OptionObject2015 ReturnOptionObject { get; set; }

        // Modules

        /// <summary>Summary goes here.</summary>
        public ModProgNote ModProgNote { get; set; }

        /// <summary>Summary goes here.</summary>
        public ModProto ModProto { get; set; }

        /// <summary>Summary goes here.</summary>
        public ModQMedOrdr ModQMedOrdr { get; set; }

        /// <summary>Summary goes here.</summary>
        public ModTesting ModTesting { get; set; }
    }

    // Progress Note module

    /// <summary>Summary goes here.</summary>
    public class ModProgNote
    {
        /// <summary>Summary goes here.</summary>
        public string Mode { get; set; }

        /// <summary>Summary goes here.</summary>
        public string Users { get; set; }

        /// <summary>Summary goes here.</summary>
        public string ServiceChargeCodeFieldId { get; set; }

        /// <summary>Summary goes here.</summary>
        public List<string> FlaggedServiceChargeCodePrefixes { get; set; }

        /// <summary>Summary goes here.</summary>
        public List<string> FlaggedServiceChargeCodeCodes { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LocationFieldId { get; set; }

        /// <summary>Summary goes here.</summary>
        public List<string> ValidLocationCodes { get; set; }

        /// <summary>Summary goes here.</summary>
        public List<string> ValidLocationNames { get; set; }
    }

    // Prototype module

    /// <summary>Summary goes here.</summary>
    public class ModProto
    {
        /// <summary>Summary goes here.</summary>
        public string Mode { get; set; }

        /// <summary>Summary goes here.</summary>
        public string Users { get; set; }
    }

    // Quick Medication Order module

    /// <summary>Summary goes here.</summary>
    public class ModQMedOrdr
    {
        /// <summary>Summary goes here.</summary>
        public string Mode { get; set; }

        /// <summary>Summary goes here.</summary>
        public string Users { get; set; }

        /// <summary>Summary goes here.</summary>
        public string OrderTypeFieldId { get; set; }

        /// <summary>Summary goes here.</summary>
        public string ValidOrderTypes { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LastOrderScheduleFieldId { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LastOrderScheduleText { get; set; }

        /// <summary>Summary goes here.</summary>
        public string LastScheduledDosage { get; set; }

        /// <summary>Summary goes here.</summary>
        public string PreviousDosePrefix { get; set; }

        /// <summary>Summary goes here.</summary>
        public string PreviousDoseSuffix { get; set; }

        /// <summary>Summary goes here.</summary>
        public string DosageOneFieldId { get; set; }

        /// <summary>Summary goes here.</summary>
        public string CurrentDosage { get; set; }

        /// <summary>Summary goes here.</summary>
        public string DosePercentBoundary { get; set; }

        /// <summary>Summary goes here.</summary>
        public string DoseMilligramBoundary { get; set; }
    }

    // Testing module.

    /// <summary>Summary goes here.</summary>
    public class ModTesting
    {
        /// <summary>Summary goes here.</summary>
        public string Mode { get; set; }
    }
}