// Abatab ModQuickMedOrder 0.95.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221027.080504

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
            abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds      = false;

            LogEvent.ModQuickMedOrder(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        private static void ComparePercentage(Session abatabSession)
        {

        }

    }
}