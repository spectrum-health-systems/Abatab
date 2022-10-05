/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabOptionObject.csproj                                                                        v0.91.0
 * Finalize.cs                                                                               b221005.090329
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

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
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.FinalOptObj.ErrorCode = 0;
            abatabSession.FinalOptObj.ErrorMesg = "Abatab is in passthrough mode.";

            return abatabSession;
        }
    }
}
