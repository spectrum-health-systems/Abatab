// ModProgressNote.PlaceOfService.cs b230221.1208
// Copyright (c) A Pretty Cool Program

using System;
using System.Reflection;
using AbatabData;
using AbatabLogging;
using ScriptLinkStandard.Objects;

namespace ModProgressNote
{
    internal class PlaceOfService
    {
        public static void VerifyTelehealth(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            InitializeTelehealthPlaceOfServiceData(abatabSession);

            AbatabOptionObject.WorkObj.ClearErrorData(abatabSession);

            ParseObject(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>Initializes dosing information.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <remarks>
        /// This information is hardcoded, but should be the same for all Avatar clients.
        /// </remarks>
        private static void InitializeTelehealthPlaceOfServiceData(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            //abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidServiceChargeCodes = new List<string>
            //{
            //    "TMH90853",
            //    "AOTMH90853"
            //};

            //abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeFieldId ="51001";

            //abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidLocations = new List<string>
            //{
            //    "Telehealth Patient Home",
            //    "Telehealth Patient Loc Not Home"
            //};

            //abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeFieldId ="51004";

            // TODO - MAke specific to ProgressNotes
            //LogEvent.ModQuickMedOrder(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        private static void ParseObject(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            /* Loop through each FormObject in the OptionObject.
            */
            foreach (FormObject formObject in abatabSession.SentOptObj.Forms)
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                /* Loop through each field of the current FormObject.
                */
                foreach (FieldObject fieldObject in formObject.CurrentRow.Fields)
                {
                    if (fieldObject.FieldNumber == abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        ProcessServiceCodeField(abatabSession, fieldObject);
                    }
                    else if (fieldObject.FieldNumber == abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        ProcessLocationField(abatabSession, fieldObject);
                    }
                    else
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        // We aren't looking for whatever field we are currently on.
                    }

                    if (abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundServiceChargeCodeFieldId && abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundLocationFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

                        if (abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidServiceChargeCodes.Contains(abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue))
                        {
                            if (!abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidLocations.Contains(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue))
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

                                abatabSession.WorkOptObj.ErrorCode = 1;
                                abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"Service Charge Code {abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
                                                                     $"  - first{Environment.NewLine}" +
                                                                     $"  - second!" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"Please verify you have the correct location.";

                                //abatabSession.WorkOptObj.SetFieldValue(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId, "11");



                                var test = abatabSession.WorkOptObj.GetFieldValue(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId);

                                LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, test);

                                abatabSession.WorkOptObj.SetFieldValue(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId, "11");

                                var test2 = abatabSession.WorkOptObj.GetFieldValue(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId);

                                LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, test);

                                //LogEvent.Warning(abatabSession, "Dosing issue.");
                            }
                            else
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                            }
                        }



                        //abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundAllRequiredFieldIds = true; // TODO Maybe go straight there? Maybe continue

                        //break;
                    }

                }

                //////if (abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundAllRequiredFieldIds)
                //////{
                //////    // TODO Might want to make put this in the original check.

                //////    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                //////    break;
                //////}
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue);

            //if (abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidServiceChargeCodes.Contains(abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue))
            //{
            //    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue);
            //    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue);

            //    if (!abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidLocations.Contains(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue))
            //    {
            //        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue);
            //        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue);

            //        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            //        abatabSession.WorkOptObj.ErrorCode = 1;
            //        abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
            //                                             $"{Environment.NewLine}" +
            //                                             $"Service Charge Code {abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
            //                                             $"  - first{Environment.NewLine}" +
            //                                             $"  - second" +
            //                                             $"{Environment.NewLine}" +
            //                                             $"Please verify you have the correct location.";

            //        abatabSession.WorkOptObj.SetFieldValue(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId, "11");

            //        LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId);
            //        //LogEvent.Warning(abatabSession, "Dosing issue.");
            //    }
            //    else
            //    {
            //        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue);
            //        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue);
            //        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
            //    }
            //}
        }


        private static void ProcessServiceCodeField(Session abatabSession, FieldObject fieldObject)
        {
            // TODO Should make sure that an empty string is enough here, or if we need to consider null/whitespace...or using string.Length.
            if (fieldObject.FieldValue?.Length == 0)
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue = "";
            }
            else
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue = fieldObject.FieldValue;
            }

            abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundServiceChargeCodeFieldId = true;
        }

        private static void ProcessLocationField(Session abatabSession, FieldObject fieldObject)
        {
            // TODO Should make sure that an empty string is enough here, or if we need to consider null/whitespace...or using string.Length.
            if (fieldObject.FieldValue?.Length == 0)
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, fieldObject.FieldValue);

                abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue = null;
            }
            else
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, fieldObject.FieldValue);

                abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue = fieldObject.FieldValue;
            }

            abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundLocationFieldId = true;
        }


    }

}