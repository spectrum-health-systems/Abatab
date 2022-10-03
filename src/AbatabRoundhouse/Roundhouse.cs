﻿/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabRoundhouse.csproj                                                                          v0.91.0
 * Roundhouse.cs                                                                             b221003.130759
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;

using AbatabLogging;
using System.Reflection;

namespace AbatabRoundhouse
{
    public class Roundhouse
    {
        public static SessionData ParseRequest(SessionData abatabSession)
        {
            switch (abatabSession.AbatabMode)
            {
                case "enabled":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    break;

                case "disabled":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    break;

                case "passthrough":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    abatabSession = AbatabOptionObject.Finalize.ForPassthrough(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            return abatabSession;
        }


    }
}
