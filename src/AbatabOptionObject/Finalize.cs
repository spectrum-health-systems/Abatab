/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabOptionObject.csproj                                                                        v0.91.0
 * Finalize.cs                                                                               b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Finalize an OptionObject so it can be returned to Avatar
 */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabOptionObject
{
    public class Finalize
    {
        /// <summary>Finalizes an OptionObject for passthrough mode.</summary>
        /// <param name="abatabSession"></param>
        public static SessionData ForPassthrough(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.FinalOptObj.ErrorCode = 0;
            abatabSession.FinalOptObj.ErrorMesg = "ParseTest";

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

            return abatabSession;
        }
    }
}
