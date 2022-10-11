/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabOptionObject.csproj                                                                        v0.92.0
 * WorkObj.cs                                                                               b221011.074325
 * --------------------------------------------------------------------------------------------------------
 * Logic for the WorkOptObj.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System.Reflection;

namespace AbatabOptionObject
{
    public class WorkObj
    {
        /// <summary></summary>
        /// <param name="sentOptObj"></param>
        /// <returns></returns>
        public static OptionObject2015 Build(OptionObject2015 sentOptObj)
        {
            // No Debugger.BuildDebugLog() or LogEvent.Trace() here because it isn't worth it...yet.

            /* Eventually we may want to do something more complex when building the workOptObj.
             */
            return sentOptObj;
        }
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        /// <param name="errCode"></param>
        /// <param name="errMsg"></param>
        public static void ClearErrorData(SessionData abatabSession, int errCode = 0, string errMsg = "")
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.WorkOptObj.ErrorCode = errCode;
            abatabSession.WorkOptObj.ErrorMesg = errMsg;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
