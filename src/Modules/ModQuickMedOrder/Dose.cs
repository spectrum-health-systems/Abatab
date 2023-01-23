// Abatab.ModQuickMedOrder.Dose.cs b230123.1258
// Copyright (c) A Pretty Cool Program

using AbatabData;

using AbatabLogging;

using NTST.ScriptLinkService.Objects;

using System;
using System.Reflection;

namespace ModQuickMedOrder
{
    /// <summary>Dose logic for the QuickMedOrder module.</summary>

    public static class Dose
    {
        /// <summary>Verifies that the dose increase percentage is within bounds.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void VerifyAmount(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            InitializeDoseData(abatabSession);

            AbatabOptionObject.WorkObj.ClearErrorData(abatabSession);

            CheckPercentage(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>Initializes dosing information.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <remarks>
        /// This information is hardcoded, but should be the same for all Avatar clients.
        /// </remarks>
        private static void InitializeDoseData(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            abatabSession.ModQuickMedOrderConfig.PrevDosePrefix                = "Recurring Dosage:";
            abatabSession.ModQuickMedOrderConfig.PrevDoseSuffix                = " mgs";
            abatabSession.ModQuickMedOrderConfig.DosageOneFieldId              = "107";
            abatabSession.ModQuickMedOrderConfig.FoundDosageOneFieldId         = false;
            abatabSession.ModQuickMedOrderConfig.CurrentDose                   = "0.0";
            abatabSession.ModQuickMedOrderConfig.OrderTypeFieldId              = "121";
            abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId         = false;
            abatabSession.ModQuickMedOrderConfig.OrderType                     = "0";
            abatabSession.ModQuickMedOrderConfig.LastOrderScheduleFieldId      = "142";
            abatabSession.ModQuickMedOrderConfig.FoundLastOrderScheduleFieldId = false;
            abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText         = "";
            abatabSession.ModQuickMedOrderConfig.LastScheduledDosage           = "0.0";
            abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds      = false;

            LogEvent.ModQuickMedOrder(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        private static void CheckPercentage(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            // TODO This should probably be moved to ModCommon so other functionality can use it.

            /* Loop through each field of every form in the original SentOptionObject from Avatar, and do
            * something special if we land on "abatabSession.ModQuickMedOrderConfig.DosageOneFieldId" or
            * "abatabSession.ModQuickMedOrderConfig.LastOrderScheduleFieldId".
            */
            foreach (FormObject formObject in abatabSession.SentOptObj.Forms)
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                foreach (FieldObject fieldObject in formObject.CurrentRow.Fields)
                {
                    /* Creating a trace log here would significantly impact performance, since hundreds of files would be created, so instead we will use a
                    * debug log. This way trace log functionality won't be impacted elsewhere.
                    */
                    LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

                    if (fieldObject.FieldNumber == abatabSession.ModQuickMedOrderConfig.DosageOneFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        ProcessDosageOneField(abatabSession, fieldObject);
                    }
                    else if (fieldObject.FieldNumber == abatabSession.ModQuickMedOrderConfig.OrderTypeFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        // TODO

                        ProcessOrderTypeField(abatabSession, fieldObject);
                    }
                    else if (fieldObject.FieldNumber == abatabSession.ModQuickMedOrderConfig.LastOrderScheduleFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        ProcessLastScheduledOrderField(abatabSession, fieldObject);
                    }
                    else
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        // We aren't looking for whatever field we are currently on.
                    }

                    if (abatabSession.ModQuickMedOrderConfig.FoundDosageOneFieldId && abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId && abatabSession.ModQuickMedOrderConfig.FoundLastOrderScheduleFieldId)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds = true; // TODO Maybe go straight there? Maybe continue?

                        break;
                    }
                }

                if (abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds)
                {
                    // TODO Might want to make put this in the original check.

                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    break;
                }
            }

            // TODO Break this out.
            // TODO Add the OrderType to Web.config
            /* OrderType 4 is recurring. Other order types may be added in the future.
             */
            if (abatabSession.ModQuickMedOrderConfig.OrderType == "4")
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                if (abatabSession.ModQuickMedOrderConfig.CurrentDose == "")
                {
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    WarningMissingCurrentDoseValue(abatabSession);
                }
                else if (abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText == "")
                {
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    WarningMissingPreviousDoseValue(abatabSession);
                }
                else
                {
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    var lastOrderScheduledLines = abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText.Split('\n');

                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    foreach (var line in lastOrderScheduledLines)
                    {
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText);

                        if (line.Contains(abatabSession.ModQuickMedOrderConfig.PrevDosePrefix) && line.Contains(abatabSession.ModQuickMedOrderConfig.PrevDoseSuffix))
                        {
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            var actualDose = line.Replace(abatabSession.ModQuickMedOrderConfig.PrevDosePrefix, "");
                            actualDose     = actualDose.Replace(abatabSession.ModQuickMedOrderConfig.PrevDoseSuffix, "");

                            abatabSession.ModQuickMedOrderConfig.LastScheduledDosage = actualDose;
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, actualDose);

                        }

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        var debugMsg1a_ = $"{abatabSession.ModQuickMedOrderConfig.LastScheduledDosage} - {abatabSession.ModQuickMedOrderConfig.CurrentDose}";

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, debugMsg1a_);

                        // TODO Should these be in the QMO settings?
                        var prevDoseAsNumber = Convert.ToDouble(abatabSession.ModQuickMedOrderConfig.LastScheduledDosage);
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, prevDoseAsNumber.ToString());

                        var currDoseAsNumber = Convert.ToDouble(abatabSession.ModQuickMedOrderConfig.CurrentDose);
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, currDoseAsNumber.ToString());

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        var debugMsg1b_ = $"{prevDoseAsNumber} - {currDoseAsNumber}";

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, debugMsg1b_);


                        if ((prevDoseAsNumber != currDoseAsNumber) && (prevDoseAsNumber !=0 && currDoseAsNumber != 0))
                        {
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            //double maxPercentChange = prevDoseAsNumber * 1.25;

                            double percentDifference = Math.Abs(((prevDoseAsNumber - currDoseAsNumber) / prevDoseAsNumber) * 100);

                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            //var debugMsg2_ = $"[{prevDoseAsNumber}] [{currDoseAsNumber}] [{milligramDifference}] [{basePercentage}] [{percentDifference}]";
                            //LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, debugMsg2_);

                            // TODO Should be converted when setup.
                            var percentBoundary    = Convert.ToDouble(abatabSession.ModQuickMedOrderConfig.DosePercentBoundary);
                            var milligramsBoundary = Convert.ToDouble(abatabSession.ModQuickMedOrderConfig.DoseMilligramsBoundary);

                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, percentBoundary.ToString());

                            //var currentMinusPrevious = Math.Abs(currDoseAsNumber - prevDoseAsNumber);
                            //var previousMinusCurrent = Math.Abs(prevDoseAsNumber - currDoseAsNumber);

                            var overage  = Math.Abs(currDoseAsNumber - prevDoseAsNumber);
                            var underage = Math.Abs(prevDoseAsNumber - currDoseAsNumber);

                            var differ = Math.Abs(currDoseAsNumber - prevDoseAsNumber);

                            var outsideBoundary = false;

                            // REINSTATE LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, $"[TRACE_02] {percentBoundary} | {milligramsBoundary} | {currentMinusPrevious} | {previousMinusCurrent} | {outsideBoundary} |   ");

                            //var warningId = $"[ Warning ID: {abatabSession.SessionDateStamp}.{abatabSession.SessionTimeStamp}-{percentBoundary}.{percentDifference}-{milligramsBoundary}.{currentMinusPrevious}.{previousMinusCurrent} ]";

                            //var warningId = $"[ Warning ID: {abatabSession.SessionDateStamp}.{abatabSession.SessionTimeStamp}-{percentBoundary}.{percentDifference}-{milligramsBoundary}.{overage}.{underage} ]";
                            var warningId = $"[ Warning ID: {abatabSession.SessionDateStamp}.{abatabSession.SessionTimeStamp}-{percentBoundary}.{percentDifference}-{milligramsBoundary}.{differ} ]{Environment.NewLine}" +
                                            $"[ {abatabSession.LoggingConfig.SessionRoot} ]";

                            //if (currentMinusPrevious >= milligramsBoundary || previousMinusCurrent <= milligramsBoundary)
                            //{
                            //    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            //    outsideBoundary = true;
                            //}
                            //if (overage >= milligramsBoundary || underage <= milligramsBoundary)
                            if (differ >= milligramsBoundary)
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                outsideBoundary = true;
                            }
                            //else if (percentDifference < (Convert.ToDouble(abatabSession.ModQuickMedOrderConfig.DosePercentBoundary) * 100))
                            else if (percentDifference >= percentBoundary)
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                outsideBoundary = true;
                            }

                            //if (currDoseAsNumber >= maxPercentChange || currDoseAsNumber <= maxPercentChange)
                            if (outsideBoundary)
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                //var percentDifference = ((currDoseAsNumber - prevDoseAsNumber) / prevDoseAsNumber) * 100;

                                //var niceString = string.Format("{0:0.#}", percentDifference);
                                //var niceString = string.Format("{0:0.#}", percentDifference);

                                // REINSTATE LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, $"[TRACE_02] {percentBoundary} | {milligramsBoundary} | {currentMinusPrevious} | {previousMinusCurrent} | {outsideBoundary} |   ");

                                //var debugMsg3_ = $"[{prevDoseAsNumber}] [{currDoseAsNumber}] [{percentDifference}] [{maxPercentChange}] [{niceString}]";
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                abatabSession.WorkOptObj.ErrorCode = 4;
                                abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"The current dose is significantly different than the previous dose.{Environment.NewLine}" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"The previous dose was: {prevDoseAsNumber}mg(s){Environment.NewLine}" +
                                                                     $"The current dose is: {currDoseAsNumber}mg(s){Environment.NewLine}" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"Are you sure you want to submit?" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"{warningId}";
                            }
                            else
                            {
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                // Percentage isn't greater
                                // TODO Maybe make this == or something.
                            }
                        }
                        else
                        {
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            // Dosages are the same
                            // TODO More efficient way to do this?
                        }
                    }
                }
            }
            else
            {
                // Not a currently valid OrderType (4)
            }
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        /// <param name="fieldObject"></param>
        private static void ProcessDosageOneField(Session abatabSession, FieldObject fieldObject)
        {
            // TODO This trace file should stay, and we might want to add a description to the msg.
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            // TODO Should make sure that an empty string is enough here, or if we need to consider null/whitespace...or using string.Length.
            if (fieldObject.FieldValue?.Length == 0)
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                abatabSession.ModQuickMedOrderConfig.CurrentDose = "";
            }
            else
            {
                // TODO This trace file should stay, and we might want to add a description to the msg.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                abatabSession.ModQuickMedOrderConfig.CurrentDose = fieldObject.FieldValue;
            }

            /* TODO This is the shorter version of the code above. More compact, less opportunity to troubleshoot due to fewer logs. Leaving this
             * here for the time being to remind myself we may want to use this instead.
             */
            ////abatabSession.ModQuickMedOrderConfig.CurrentDose =fieldObject.FieldValue?.Length == 0
            ////    ? ""
            ////    : fieldObject.FieldValue;

            abatabSession.ModQuickMedOrderConfig.FoundDosageOneFieldId = true;
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        /// <param name="fieldObject"></param>
        private static void ProcessOrderTypeField(Session abatabSession, FieldObject fieldObject)
        {
            // TODO This trace file should stay, and we might want to add a description to the msg.
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            // TODO What if there is nothing in the field?
            abatabSession.ModQuickMedOrderConfig.OrderType = fieldObject.FieldValue;

            abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId = true;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, $"[TRACE_02]: OrderType = {fieldObject.FieldValue}/{abatabSession.ModQuickMedOrderConfig.OrderType} | FoundOrderTypeFieldId = {abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId}");
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        /// <param name="fieldObject"></param>
        private static void ProcessLastScheduledOrderField(Session abatabSession, FieldObject fieldObject)
        {
            // TODO This trace file should stay, and we might want to add a description to the msg.
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            // TODO What if there is nothing in the field?
            abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText = fieldObject.FieldValue;

            abatabSession.ModQuickMedOrderConfig.FoundLastOrderScheduleFieldId = true;
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        private static void WarningMissingPreviousDoseValue(Session abatabSession)
        {
            // TODO This trace file should stay, and we might want to add a description to the msg.
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            abatabSession.WorkOptObj.ErrorCode = 4;
            abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                 $"It has been detected that there has not previously been an order in this episode.{Environment.NewLine}" +
                                                 $"{Environment.NewLine}" +
                                                 $"Are you sure you want to submit?";
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        private static void WarningMissingCurrentDoseValue(Session abatabSession)
        {
            // TODO This trace file should stay, and we might want to add a description to the msg.
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            abatabSession.WorkOptObj.ErrorCode = 1;
            abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                 $"Dosage 1 field cannot be empty.{Environment.NewLine}";
        }
    }
}