// b230516.0855

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utility;

namespace Abatab.Module.ProgressNote.Action
{
    /// <summary>Summary goes here.</summary>
    public static class VerifyLocation
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.ProgressNote.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            // TODO: These values should be in the local settings file.
            var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
            var locationValue          = abSession.SentOptionObject.GetFieldValue("50004");

            switch (abSession.RequestAction)
            {
                case "telehlth90853":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    if (ValidGroupIndividualizedNote(abSession.ModProgNote.FlaggedServiceChargeCodeCodes, serviceChargeCodeValue, abSession.ModProgNote.ValidLocationCodes, locationValue, abSession)) // remove last parameter after testing
                    {
                        LogEvent.Trace("traceinternal", abSession, AssemblyName);

                        abSession.ReturnOptionObject.ToReturnOptionObject();
                    }
                    else
                    {
                        LogEvent.Trace("traceinternal", abSession, AssemblyName);
                        LogEvent.Trace("traceinternal", abSession, AssemblyName, serviceChargeCodeValue); // Testing

                        // TODO: Quick fix
                        if (serviceChargeCodeValue != "")
                        {
                            CreateWarning(abSession, serviceChargeCodeValue);
                        }
                        else
                        {
                            _=abSession.ReturnOptionObject.ToReturnOptionObject();
                        }
                    }

                    break;

                case "telehlthwildcards":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    if (ValidIndividualCounselingNote(abSession.ModProgNote.FlaggedServiceChargeCodePrefixes, serviceChargeCodeValue, abSession.ModProgNote.ValidLocationCodes, locationValue, abSession))
                    {
                        LogEvent.Trace("traceinternal", abSession, AssemblyName);

                        abSession.ReturnOptionObject.ToReturnOptionObject();
                    }
                    else
                    {
                        LogEvent.Trace("traceinternal", abSession, AssemblyName);

                        // TODO: Quick fix
                        if (serviceChargeCodeValue != "")
                        {
                            CreateWarning(abSession, serviceChargeCodeValue);
                        }
                        else
                        {
                            _=abSession.ReturnOptionObject.ToReturnOptionObject();
                        }
                    }

                    break;

                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO - Exit gracefully.

                    break;
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.ProgressNote.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        private static bool ValidGroupIndividualizedNote(List<string> flaggedServiceChargeCodeCodes, string serviceChargeCodeValue, List<string> validLocations, string locationValue, AbSession abSession) // remove last argument after testing
        {
            //LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name); /* Can't put a trace log here. */ // TODO - Figure out a better way to do this.

            /*  IF the Service Charge Code on the form is in the list of service charge codes to check
             *      IF the location on the form is in the list of valid locations, return true
             *      IF the location on the form is not in the list of valid locations, return false
             *  IF the Service Charge Code on the form is not in the list of Service Charge Codes to check, return true.
             */

            if (flaggedServiceChargeCodeCodes.Contains(serviceChargeCodeValue))
            {
                LogEvent.Trace("traceinternal", abSession, AssemblyName, serviceChargeCodeValue);
                return validLocations.Contains(locationValue);
            }
            else
            {
                return true;
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.ProgressNote.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        private static bool ValidIndividualCounselingNote(List<string> flaggedServiceChargeCodePrefixes, string serviceChargeCodeValue, List<string> validLocations, string locationValue, AbSession abSession) // remove last argument after testing // Can't put a log event here.
        {
            //LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name); /* Can't put a trace log here. */ // TODO - Figure out a better way to do this.

            if (flaggedServiceChargeCodePrefixes.Any(codePrefix => serviceChargeCodeValue.StartsWith(codePrefix)))
            {
                LogEvent.Trace("traceinternal", abSession, AssemblyName, serviceChargeCodeValue);
                return validLocations.Contains(locationValue);
            }
            else
            {
                return true;
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.ProgressNote.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        private static void CreateWarning(AbSession abSession, string serviceChargeCodeValue)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            /* The following code will allow the user to file the note, but suggests they review the details.
            */
            var errorCode = 2;
            var errorMesg = $"WARNING!{Environment.NewLine}" +
                            $"{Environment.NewLine}" +
                            $"The current Service Charge Code ({serviceChargeCodeValue}) should probably match one of these locations:{Environment.NewLine}" +
                            $"{Environment.NewLine}" +
                            $"{ConvertCollection.ListToNewLineString(abSession.ModProgNote.ValidLocationNames)}" +
                            $"{Environment.NewLine}" +
                            $"Please click \"Cancel\" and verify you have the correct location, or \"OK\" if you are sure the location is correct.";

            /* The following code will force the user to make changes before filing the note.
            */
            //var errorCode = 1;
            //var errorMesg = $"WARNING!{Environment.NewLine}" +
            //                $"{Environment.NewLine}" +
            //                $"Service Charge Code {serviceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
            //                $"{Environment.NewLine}" +
            //                $"{Common.ListToNewLineString(abSession.ModProgressNote.ValidLocationNames)}" +
            //                $"{Environment.NewLine}" +
            //                $"Please verify you have the correct location.";

            //var alertLogName = $"{DateTime.Now:yyMMdd}-{abSession.SentOptionObject.OptionId}-{abSession.RequestModule}-{abSession.RequestCommand}-{abSession.RequestAction}-{abSession.RequestOption}";

            _=abSession.ReturnOptionObject.ToReturnOptionObject(errorCode, errorMesg);

            LogEvent.Warning(abSession);
            LogEvent.Alert(abSession, AssemblyName);
        }
    }
}