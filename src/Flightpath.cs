// Abatab.Flightpath.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Abatab.Core.Catalog;
using Abatab.Core.Session;
using Abatab.Core.Utilities;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfigContent)
        {
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

            SessionProperties sessionProperties = Build.NewSession(sentOptionObject, scriptParameter, webConfigContent);

            var todaysDirectory = $@"{sessionProperties.AbatabDataRoot}\{sessionProperties.AvatarEnvironment}\{sessionProperties.Datestamp}";

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, todaysDirectory);

            if (!Directory.Exists(todaysDirectory))
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, todaysDirectory);
                Directory.CreateDirectory(todaysDirectory);
                Core.DataExport.SessionInformation.ToDirectory(sessionProperties, todaysDirectory);
            }

            Roundhouse.ParseModule(sessionProperties);
        }
    }
}