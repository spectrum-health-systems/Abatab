/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * ModuleTesting.csproj                                                                             v0.91.0
 * ModuleTesting.CommandC.cs                                                                 b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleTesting
{
    public class CommandC
    {
        public static void ActionC1(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
        }

        public static void ActionC2(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
        }

        public static void ActionC3(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
        }
    }
}
