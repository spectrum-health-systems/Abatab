using System.Reflection;
using Abatab.Core.Catalog;
using Abatab.Core.Logger;

namespace Abatab
{
    public class Roundhouse
    {
        public static void ParseModule(SessionProperties sessionProperties)
        {
            LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);

            switch (sessionProperties.RequestModule)
            {
                case "testing":
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);
                    Module.Testing.Roundhouse.ParseCommand(sessionProperties);
                    break;

                default:
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Should probably put something here to help exit gracefully.
                    break;
            }
        }
    }
}