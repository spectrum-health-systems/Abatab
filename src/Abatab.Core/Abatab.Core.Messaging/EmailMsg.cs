﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace Abatab.Core.Messaging
{
    public class EmailMsg
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void Send(AbSession abSession, string msgTo, string msgFrom, string acctPwd, string msgSubject, string msgBody)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            // TODO: Most of this should be stored in external settings.
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                //UseDefaultCredentials = false,
                //Credentials = new NetworkCredential(abSession.AbatabEmailAddress, abSession.AbatabEmailPassword),
                //Credentials = new NetworkCredential("abatab@spectrumhealthsystems.org", "ChrisIsSmarterThanNetsmart123"),
                EnableSsl = true,
            };

            LogEvent.Trace("trace", abSession, AssemblyName);

            //smtpClient.UseDefaultCredentials = false;

            LogEvent.Trace("trace", abSession, AssemblyName);

            //Credentials = new NetworkCredential(abSession.AbatabEmailAddress, abSession.AbatabEmailPassword),
            smtpClient.Credentials = new NetworkCredential(msgTo, acctPwd);

            LogEvent.Trace("trace", abSession, AssemblyName);

            //var emailTo = "courtney.cross@spectrumhealthsystems.org";
            LogEvent.Trace("trace", abSession, AssemblyName);

            //smtpClient.Send("abatab@spectrumhealthsystems.org", "chris.banwarth@spectrumhealthsystems.org", "I AM AVATAR!", "Yay!");
            smtpClient.Send(msgTo, msgFrom, msgBody, msgSubject);
            LogEvent.Trace("trace", abSession, AssemblyName);
            abSession.ReturnOptionObject.ToReturnOptionObject();



            LogEvent.Trace("trace", abSession, AssemblyName);
        }
    }
}
