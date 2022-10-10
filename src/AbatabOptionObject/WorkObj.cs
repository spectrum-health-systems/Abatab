/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabOptionObject.csproj                                                                        v0.92.0
 * WorkObj.cs                                                                               b221010.124123
 * --------------------------------------------------------------------------------------------------------
 * Logic for the WorkOptObj.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using NTST.ScriptLinkService.Objects;

namespace AbatabOptionObject
{
    public class WorkObj
    {
        public static OptionObject2015 Build(OptionObject2015 sentOptObj)
        {
            // No Debugger.BuildDebugLog() or LogEvent.Trace() here because it isn't worth it...yet.

            /* Eventually we may want to do something more complex when building the workOptObj.
             */
            return sentOptObj;
        }

        public static void ClearErrorData(SessionData abatabSession, int errCode = 0, string errMsg = "")
        {
            abatabSession.WorkOptObj.ErrorCode = errCode;
            abatabSession.WorkOptObj.ErrorMesg = errMsg;
        }
    }
}
