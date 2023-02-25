// Abatab.Flightpath.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.IO;
using Abatab.Core.Catalog;
using Abatab.Core.Framework;
using Abatab.Core.Session;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfigContent)
        {
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

            SessionProperties sessionProperties = Build.NewSession(sentOptionObject, scriptParameter, webConfigContent);

            if (!Directory.Exists(sessionProperties.SessionDataRoot))
            {
                Refresh.Daily(sessionProperties);
            }

            //if (!File.Exists($@"{sessionProperties.AbatabDataRoot}\{sessionProperties.AvatarEnvironment}\{sessionProperties.Datestamp}\Abatab.settings"))
            //{
            //    Core.DataExport.SessionInformation.ToDaily(sessionProperties, $@"{sessionProperties.AbatabDataRoot}\{sessionProperties.AvatarEnvironment}\{sessionProperties.Datestamp}\Abatab.settings");
            //}

            Roundhouse.ParseModule(sessionProperties);
        }
    }
}