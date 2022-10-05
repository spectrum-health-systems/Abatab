﻿/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * Abatab.Roundhouse.cs                                                                      b221005.090329
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    public class Roundhouse
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        public static void ParseRequest(SessionData abatabSession)
        {
            switch (abatabSession.AbatabModule)
            {
                case "date":
                    // TBD
                    break;

                case "dose":
                    // TBD
                    break;

                case "testing":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ModuleTesting.Roundhouse.ParseCommand(abatabSession);
                    //abatabSession = AbatabOptionObject.Finalize.ForPassthrough(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            //return abatabSession;
        }
    }
}