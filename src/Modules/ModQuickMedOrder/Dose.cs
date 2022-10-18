// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221018.082641

using AbatabData;
using AbatabLogging;
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
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing Abatab request..");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            var shouldExecute = ModCommon.Verify.ValidUser(abatabSession.AvatarUserName, abatabSession.ModQuickMedOrderValidUsers);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "Trailing trace log for valid user check.");

            if (shouldExecute)
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

                InitializeDoseData(abatabSession);

                AbatabOptionObject.WorkObj.ClearErrorData(abatabSession);

                LogEvent.ModQuickMedOrder(abatabSession);
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// Initializes dosing information.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void InitializeDoseData(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.ModQuickMedOrderData.PrevDosePrefix                = "Recurring Dosage:";
            abatabSession.ModQuickMedOrderData.PrevDoseSuffix                = " mgs";
            abatabSession.ModQuickMedOrderData.DosageOneFieldId              = "107";
            abatabSession.ModQuickMedOrderData.FoundDosageOneFieldId         = false;
            abatabSession.ModQuickMedOrderData.CurrentDose                   = "0.0";
            abatabSession.ModQuickMedOrderData.OrderTypeFieldId              = "121";
            abatabSession.ModQuickMedOrderData.FoundOrderTypeFieldId         = false;
            abatabSession.ModQuickMedOrderData.OrderType                     = "0";
            abatabSession.ModQuickMedOrderData.LastOrderScheduleFieldId      = "142";
            abatabSession.ModQuickMedOrderData.FoundLastOrderScheduleFieldId = false;
            abatabSession.ModQuickMedOrderData.LastOrderScheduleText         = "";
            abatabSession.ModQuickMedOrderData.FoundAllRequiredFieldIds      = false;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}