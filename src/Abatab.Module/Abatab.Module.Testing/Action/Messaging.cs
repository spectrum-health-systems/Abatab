// b230516.1115

using System.Net;
using System.Net.Mail;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing.Action
{
    public static class Messaging
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void SendEmail(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

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
            smtpClient.Credentials = new NetworkCredential("abatab@spectrumhealthsystems.org", "5cr33n5#07");

            LogEvent.Trace("trace", abSession, AssemblyName);

            var emailTo = "courtney.cross@spectrumhealthsystems.org";
            LogEvent.Trace("trace", abSession, AssemblyName);

            smtpClient.Send("abatab@spectrumhealthsystems.org", "chris.banwarth@spectrumhealthsystems.org", "I AM AVATAR!", "Yay!");
            //smtpClient.Send(emailTo, abSession.AbatabEmailAddress, "test", "This is a test");
            LogEvent.Trace("trace", abSession, AssemblyName);
            abSession.ReturnOptionObject.ToReturnOptionObject();



            LogEvent.Trace("trace", abSession, AssemblyName);
        }
    }
}