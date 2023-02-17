// ModProgressNote.PlaceOfService.cs b230217.1002
// Copyright (c) A Pretty Cool Program

using AbatabData;

using AbatabLogging;

using ScriptLinkStandard.Objects;

using System;
using System.Reflection;

namespace ModProgressNote
{
    internal class PlaceOfService
    {
        public FormObject FormPlaceholder { get; set; }
        public FieldObject FieldPlaceholder { get; set; }
        public string FieldNumberPlaceholder { get; set; }



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

            // TODO - Make specific to ProgressNotes
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

                        //var FormPlaceholder = formObject;
                        //var FieldPlaceholder = fieldObject;
                        //var FieldNumberPlaceholder = fieldObject.FieldNumber ;

                        ProcessLocationField(abatabSession, fieldObject);
                    }
                    else
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        // We aren't looking for whatever field we are currently on.
                    }

                    if (abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundServiceChargeCodeFieldId && abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundLocationFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundAllRequiredFieldIds = true; // TODO Maybe go straight there? Maybe continue?

                        break;
                    }
                }

                if (abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundAllRequiredFieldIds)
                {
                    // TODO Might want to make put this in the original check.

                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    break;
                }
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue); // REMOVE
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue); // REMOVE

            if (abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidServiceChargeCodes.Contains(abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue); // REMOVE
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue); // REMOVE

                if (!abatabSession.ModProgressNoteConfig.TelehealthConfig.ValidLocations.Contains(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue))
                {
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue); // REMOVE
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue); // REMOVE

                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    // This is the fix for the location sticking around
                    //abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue = "T110";

                    foreach (FormObject formObject in abatabSession.WorkOptObj.Forms)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        /* Loop through each field of the current FormObject.
                        */
                        foreach (FieldObject fieldObject in formObject.CurrentRow.Fields)
                        {
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.WorkOptObj.GetFieldValue(fieldObject.FieldNumber));

                            if (fieldObject.FieldNumber == abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId)
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                //abatabSession.WorkOptObj.SetFieldValue(fieldObject.FieldNumber, "");
                                //abatabSession.WorkOptObj.SetFieldValue(formObject.CurrentRow.Fields.fieldObject.FieldNumber, "T102");
                                //abatabSession.WorkOptObj.SetFieldValue(abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationFieldId, "T110"); //T102

                                abatabSession.WorkOptObj.SetFieldValue(fieldObject.FieldNumber, "T102");

                                LogEvent.TraceMsg(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.WorkOptObj.GetFieldValue(fieldObject.FieldNumber));
                                //ObjThing.ToJson();
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                //fieldObject.FieldValue = "T110";
                            }
                            else
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                // We aren't looking for whatever field we are currently on.
                            }
                        }

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    }



                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    abatabSession.WorkOptObj.ErrorCode = 3;
                    abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                         $"{Environment.NewLine}" +
                                                         $"Service Charge Code {abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue} must have a location of \"Telehealth Patient Home\" or \"Telehealth Patient Loc Not Home\"";

                    // TODO - Implement this
                    //LogEvent.Warning(abatabSession, "Dosing issue.");
                }
                else
                {
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.ServiceChargeCodeValue); // REMOVE
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue); // REMOVE
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                }
            }
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

                abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue = "";
            }
            else
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, fieldObject.FieldValue);

                abatabSession.ModProgressNoteConfig.TelehealthConfig.LocationValue = fieldObject.FieldValue;
            }

            abatabSession.ModProgressNoteConfig.TelehealthConfig.FoundLocationFieldId = true;
        }


    }
}
