// b230516.0855

using System.Linq;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using Abatab.Properties;

namespace Abatab
{
    /// <summary>Loads settings from the local Web.config file.</summary>
    public static class WebConfig
    {
        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="WebConfig.cs"]/Load/*' />
        public static void Load(AbSession abSession)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            abSession.AbatabMode             = Settings.Default.AbatabMode;
            abSession.AbatabVersion          = Settings.Default.AbatabVersion;
            abSession.AbatabBuild            = Settings.Default.AbatabBuild;
            abSession.AbatabServiceRoot      = Settings.Default.AbatabServiceRoot;
            abSession.AbatabDataRoot         = Settings.Default.AbatabDataRoot;
            abSession.LoggerMode             = Settings.Default.LoggerMode;
            abSession.LoggerDelay            = Settings.Default.LoggerDelay;
            abSession.LoggerTypes            = Settings.Default.LoggerTypes;
            abSession.AvatarEnvironment      = Settings.Default.AvatarEnvironment;
            abSession.AbatabFallbackUserName = Settings.Default.AbatabFallbackUserName;
            abSession.AbatabEmailAddress     = Settings.Default.AbatabEmailAddress;
            abSession.AbatabEmailPassword    = Settings.Default.AbatabEmailPassword;
            abSession.DebugglerMode          = Settings.Default.DebugglerMode;

            abSession.ModProgNote = new ModProgNote
            {
                Mode                             = Settings.Default.ModProgNoteMode,
                Users                            = Settings.Default.ModProgNoteUsers,
                ServiceChargeCodeFieldId         = Settings.Default.ModProgNoteServiceChargeCodeFieldId,
                FlaggedServiceChargeCodePrefixes = Settings.Default.ModProgNoteFlaggedServiceChargeCodePrefixes.Cast<string>().ToList(),
                FlaggedServiceChargeCodeCodes    = Settings.Default.ModProgNoteFlaggedServiceChargeCodeCodes.Cast<string>().ToList(),
                LocationFieldId                  = Settings.Default.ModProgNoteLocationFieldId,
                ValidLocationNames               = Settings.Default.ModProgNoteValidLocationNames.Cast<string>().ToList(),
                ValidLocationCodes               = Settings.Default.ModProgNoteValidLocationCodes.Cast<string>().ToList(),
            };

            abSession.ModProto = new ModProto
            {
                Mode  = Settings.Default.ModProtoMode,
                Users = Settings.Default.ModProtoUsers
            };

            abSession.ModQMedOrdr = new ModQMedOrdr
            {
                Mode                  = Settings.Default.ModQMedOrdrMode,
                Users                 = Settings.Default.ModQMedOrdrUsers,
                OrderTypeFieldId      = Settings.Default.ModQMedOrdrOrderTypeFieldId,
                ValidOrderTypes       = Settings.Default.ModQMedOrdrValidOrderTypes,
                DosePercentBoundary   = Settings.Default.ModQMedOrdrDosePercentBoundary,
                DoseMilligramBoundary = Settings.Default.ModQMedOrdrDoseMilligramBoundary
            };

            abSession.ModTesting = new ModTesting
            {
                Mode = Settings.Default.ModTestingMode
            };
        }
    }
}