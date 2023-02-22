using System.Reflection;
using AbatabCatalog.Dossier;
using AbatabLogger;

namespace Abatab
{
    public class Roundhouse
    {
        public static void ParseScriptParameter(SessionDetail session)
        {
            switch (session.AbatabModule)
            {
                case "testing":
                    LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
                    AbatabTesting.Roundhouse.ParseRequest(session);
                    break;

                default:
                    LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
                    break;
            }
        }


    }
}