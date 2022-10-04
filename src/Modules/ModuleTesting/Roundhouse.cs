/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * ModuleTesting.csproj                                                                             v0.91.0
 * Roundhouse.cs                                                                             b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleTesting
{
    public class Roundhouse
    {
        public static SessionData ParseCommand(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            switch (abatabSession.AbatabCommand)
            {
                case "commanda":
                    ParseCommandA(abatabSession);
                    break;

                case "commandb":
                    ParseCommandB(abatabSession);
                    break;

                case "datadump":
                    ParseDataDump(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        private static SessionData ParseCommandA(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            switch (abatabSession.AbatabAction)
            {
                case "actiona1":
                    CommandA.ActionA1(abatabSession);
                    break;

                case "actiona2":
                    CommandA.ActionA2(abatabSession);
                    break;

                case "actiona3":
                    CommandA.ActionA3(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        private static SessionData ParseCommandB(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            switch (abatabSession.AbatabAction)
            {
                case "actionb1":
                    CommandB.ActionB1(abatabSession);
                    break;

                case "actionb2":
                    CommandB.ActionB2(abatabSession);
                    break;

                case "actionb3":
                    CommandB.ActionB3(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        private static SessionData ParseDataDump(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            switch (abatabSession.AbatabAction)
            {
                case "sessiondata":
                    DataDump.SessionData(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }
    }
}
