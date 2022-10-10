/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabOptionObject.csproj                                                                        v0.91.0
 * FinalObj.cs                                                                               b221010.115103
 * --------------------------------------------------------------------------------------------------------
 * Logic for the FinalOptObj.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabOptionObject
{
    public class FinalObj
    {
        /// <summary>Finalizes an OptionObject for passthrough mode.</summary>
        /// <param name="abatabSession">Abatab session settings.</param>
        public static void BuildPassthrough(SessionData abatabSession)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Finalizing finalOptObj");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.FinalOptObj.ErrorCode = 0;
            abatabSession.FinalOptObj.ErrorMesg = "For passthrough mode.";

            abatabSession.FinalOptObj.EntityID        = abatabSession.SentOptObj.EntityID;
            abatabSession.FinalOptObj.EpisodeNumber   = abatabSession.SentOptObj.EpisodeNumber;
            abatabSession.FinalOptObj.Facility        = abatabSession.SentOptObj.Facility;
            abatabSession.FinalOptObj.OptionId        = abatabSession.SentOptObj.OptionId;
            abatabSession.FinalOptObj.OptionStaffId   = abatabSession.SentOptObj.OptionStaffId;
            abatabSession.FinalOptObj.OptionUserId    = abatabSession.SentOptObj.OptionUserId;
            abatabSession.FinalOptObj.SystemCode      = abatabSession.SentOptObj.SystemCode;
            abatabSession.FinalOptObj.ServerName      = abatabSession.SentOptObj.ServerName;
            abatabSession.FinalOptObj.NamespaceName   = abatabSession.SentOptObj.NamespaceName;
            abatabSession.FinalOptObj.ParentNamespace = abatabSession.SentOptObj.ParentNamespace;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}