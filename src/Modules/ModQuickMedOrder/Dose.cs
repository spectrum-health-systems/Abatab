// Abatab ModQuickMedOrder 0.95.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221031.163946

using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Reflection;

namespace ModQuickMedOrder
{
    /// <summary>
    /// Dose logic for the QuickMedOrder module.
    /// </summary>
    public static class Dose
    {
        /// <summary>
        /// Verifies that the dose increase percentage is within bounds.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void VerifyUnderMaxPercentIncrease(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            //var shouldExecute = ModCommon.Verify.ValidUser(abatabSession.AvatarUserName, abatabSession.ModQuickMedOrderConfig.ValidUsers);
            //LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            //if (shouldExecute)
            //{
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            InitializeDoseData(abatabSession);

            AbatabOptionObject.WorkObj.ClearErrorData(abatabSession);

            ComparePercentage(abatabSession);

            //LogEvent.ModQuickMedOrder(abatabSession);
            //}

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Initializes dosing information.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <remarks>
        /// This information is hardcoded, but should be the same for all Avatar clients.
        /// </remarks>
        private static void InitializeDoseData(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
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
            abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText         = "0.0";
            abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds      = false;

            LogEvent.ModQuickMedOrder(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSession"></param>
        private static void ComparePercentage(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            /* Loop through each field of every form in the original SentOptionObject from Avatar, and do
             * something special if we land on "abatabSession.ModQuickMedOrderConfig.DosageOneFieldId" or
             * "abatabSession.ModQuickMedOrderConfig.LastOrderScheduleFieldId".
             */
            foreach (FormObject formObject in abatabSession.SentOptObj.Forms)
            {
                // TODO This will create *tons* of log files, and should probably be it's own class of trace.
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                foreach (FieldObject fieldObject in formObject.CurrentRow.Fields)
                {
                    // TODO This will create *tons* of log files, and should probably be it's own class of trace.
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    if (fieldObject.FieldNumber == abatabSession.ModQuickMedOrderConfig.DosageOneFieldId)
                    {
                        ProcessDosageOneField(abatabSession, fieldObject);
                    }
                    else if (fieldObject.FieldNumber == abatabSession.ModQuickMedOrderConfig.OrderTypeFieldId)
                    {
                        ProcessOrderTypeField(abatabSession, fieldObject);
                    }
                    else if (fieldObject.FieldNumber == abatabSession.ModQuickMedOrderConfig.LastOrderScheduleFieldId)
                    {
                        ProcessLastScheduledOrderField(abatabSession, fieldObject);
                    }
                    else
                    {
                        // TODO This trace file should stay, and we might want to add a description to the msg. Maybe this is an error log.
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        // Something may have gone wrong.
                    }

                    if (abatabSession.ModQuickMedOrderConfig.FoundDosageOneFieldId && abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId && abatabSession.ModQuickMedOrderConfig.FoundLastOrderScheduleFieldId)
                    {
                        // TODO This trace file should stay, and we might want to add a description to the msg.
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds = true;
                        // TODO Maybe go straight there? Maybe continue?
                        break;
                    }
                }

                if (abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds)
                {
                    // TODO This trace file should stay, and we might want to add a description to the msg.
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    // TODO Might want to make put this in the original check.
                    break;
                }
            }

            /* OrderType 4 is recurring. Other order types may be added in the future.
             */
            if (abatabSession.ModQuickMedOrderConfig.OrderType == "4")
            {
                /* Before we continue, we need to:
                 *  1. Make sure there is a current dose (it's not blank)
                 *  2. Get the previous dose. if there is one
                 */
                if (abatabSession.ModQuickMedOrderConfig.CurrentDose == "")
                {
                    WarningMissingCurrentDoseValue(abatabSession);
                }
                else if (abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText == "")
                {
                    WarningMissingPreviousDoseValue(abatabSession);
                }
                else
                {
                    // TODO This trace file should stay, and we might want to add a description to the msg.
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    var lastOrderScheduledLines = abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText.Split('\n');

                    // TODO This trace file should stay, and we might want to add a description to the msg.
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    foreach (var line in lastOrderScheduledLines)
                    {
                        // TODO This trace file should stay, and we might want to add a description to the msg.
                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                        LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText);

                        if (line.Contains(abatabSession.ModQuickMedOrderConfig.PrevDosePrefix) && line.Contains(abatabSession.ModQuickMedOrderConfig.PrevDoseSuffix))
                        {
                            // TODO This trace file should stay, and we might want to add a description to the msg.
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            var actualDose = line.Replace(abatabSession.ModQuickMedOrderConfig.PrevDosePrefix, "");
                            actualDose     = actualDose.Replace(abatabSession.ModQuickMedOrderConfig.PrevDoseSuffix, "");

                            abatabSession.ModQuickMedOrderConfig.LastScheduledDosage = actualDose;
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, actualDose);

                        }

                        // TODO This trace file should stay, and we might want to add a description to the msg.
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
                            // TODO This trace file should stay, and we might want to add a description to the msg.
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            double milligramDifference = (currDoseAsNumber - prevDoseAsNumber);
                            double basePercentage = prevDoseAsNumber / milligramDifference;
                            double percentDifference = 100.0 - basePercentage;
                            //decimal decimalDifference = Convert.ToDecimal(percentDifference);




                            // TODO This trace file should stay, and we might want to add a description to the msg.
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                            var debugMsg2_ = $"[{prevDoseAsNumber}] [{currDoseAsNumber}] [{milligramDifference}] [{basePercentage}] [{percentDifference}]";
                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, debugMsg2_);

                            // TODO Should be converted when setup.
                            var maxPercentIncrease = Convert.ToDouble(abatabSession.ModQuickMedOrderConfig.DoseMaxPercentIncrease);

                            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, maxPercentIncrease.ToString());

                            //if (basePercentage >= maxPercentIncrease)
                            if (percentDifference >= maxPercentIncrease)
                            {
                                // TODO This trace file should stay, and we might want to add a description to the msg.
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                                var niceString = string.Format("{0:0}", percentDifference);

                                var debugMsg3_ = $"[{prevDoseAsNumber}] [{currDoseAsNumber}] [{milligramDifference}] [{basePercentage}] [{percentDifference}] [{niceString}]";
                                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, debugMsg3_);

                                abatabSession.WorkOptObj.ErrorCode = 4;
                                abatabSession.WorkOptObj.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                                     $"The percentage increase is too high.{Environment.NewLine}" +
                                                                     $"{Environment.NewLine}" +
                                                                     $"The previous dose was: {prevDoseAsNumber}mg{Environment.NewLine}" +
                                                                     $"The current dose is: {currDoseAsNumber}mg{Environment.NewLine}" +
                                                                     $"That is a difference of: {niceString}%{Environment.NewLine}" +
                                                                     $"Are you sure you want to submit?";
                            }
                            else
                            {
                                // Everything is fine?
                            }
                        }
                        else
                        {
                            // Something goes here?
                        }
                    }
                }
            }
            else
            {
                // Not a currently valid OrderType
            }



        }


        /// <summary>
        ///
        /// </summary>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSession"></param>
        /// <param name="fieldObject"></param>
        private static void ProcessOrderTypeField(Session abatabSession, FieldObject fieldObject)
        {
            // TODO This trace file should stay, and we might want to add a description to the msg.
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            // TODO What if there is nothing in the field?
            abatabSession.ModQuickMedOrderConfig.OrderType = fieldObject.FieldValue;

            abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId = true;
        }

        /// <summary>
        ///
        /// </summary>
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

        /// <summary>
        ///
        /// </summary>
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

        /// <summary>
        ///
        /// </summary>
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