using AbatabData;
using AbatabLogging;

namespace ModuleTesting
{
    public class DataDump
    {
        public static void SessionData(SessionData abatabSession)
        {
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            LogEvent.SessionData(abatabSession);
        }
    }
}
