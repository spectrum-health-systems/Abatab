// Abatab.WebConfig.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using AbatabCatalog.Dossier;
using AbatabLogger;

namespace Abatab
{
    /// <summary>
    /// 
    /// </summary>
    public class Roundhouse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public static void ParseModuleComponent(SessionDetail session)
        {
            LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);

            switch (session.AbatabModule)
            {
                case "testing":
                    LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
                    AbatabTesting.Roundhouse.ParseCommandComponent(session);
                    break;

                default:
                    LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
                    break;
            }
        }
    }
}