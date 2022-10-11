/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * ModQuickMedOrder.csproj                                                                          v0.92.0
 * Dose.cs                                                                                   b221011.093856
 * --------------------------------------------------------------------------------------------------------
 *
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModQuickMedOrder
{
    public class Dose
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        public static void VerifyUnderMaxPercentIncrease(SessionData abatabSession)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing Abatab request..");
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




        /// <summary></summary>
        /// <returns></returns>
        private static void InitializeDoseData(SessionData abatabSession)
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
