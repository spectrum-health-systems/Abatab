// b---------x

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

            //// Please see replacewith_DebugglerModeInfoLink for more information about DebugglerMode.
            //if (Settings.Default.DebugglerMode == "enabled")
            //{
            //    Debuggler.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            //}

            /* These are the generic Abatab settings.
             */
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
            abSession.DebugglerMode          = Settings.Default.DebugglerMode;

            /* These are Progress Note module settings that are created at runtime in Abatab.Core.Session.Build()
             */
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

            /* These are additional Prototype module settings that are created at runtime in Abatab.Core.Session.Build()
             */
            abSession.ModProto = new ModProto
            {
                Mode  = Settings.Default.ModProtoMode,
                Users = Settings.Default.ModProtoUsers
            };

            /* These are additional Quick Medication Order module settings that are created at runtime in Abatab.Core.Session.Build()
             */
            abSession.ModQMedOrdr = new ModQMedOrdr
            {
                Mode                  = Settings.Default.ModQMedOrdrMode,
                Users                 = Settings.Default.ModQMedOrdrUsers,
                OrderTypeFieldId      = Settings.Default.ModQMedOrdrOrderTypeFieldId,
                ValidOrderTypes       = Settings.Default.ModQMedOrdrValidOrderTypes,
                DosePercentBoundary   = Settings.Default.ModQMedOrdrDosePercentBoundary,
                DoseMilligramBoundary = Settings.Default.ModQMedOrdrDoseMilligramBoundary
            };

            /* These are additional Testing module settings that are created at runtime in Abatab.Core.Session.Build()
             */
            abSession.ModTesting = new ModTesting
            {
                Mode = Settings.Default.ModTestingMode
            };
        }
    }
}