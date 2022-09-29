/* ========================================================================================================
 * Abatab v0.90.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabOptionObject v0.90.0
 * AbatabOptionObject.SessionData.cs b220929.184306
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabData.md
 * ===================================================================================================== */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabOptionObject
{
    public class Finalize
    {
        /// <summary>
        /// Finalizes an OptionObject for passthrough mode.
        /// </summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        public static SessionData ForPassthrough(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            abatabSession.FinalOptObj.ErrorCode = 0;
            abatabSession.FinalOptObj.ErrorMesg = "Abatab is in passthrough mode.";

            return abatabSession;
        }
    }
}
