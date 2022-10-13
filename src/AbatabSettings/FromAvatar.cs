// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;

namespace AbatabSettings
{
    /// <summary></summary>
    public class FromAvatar
    {
        /// <summary></summary>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSettings(OptionObject2015 sentOptObj, string scriptParameter, string debugMode, string debugLogRoot)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            List<Dictionary<string, string>> fromAvatarSettings = new List<Dictionary<string, string>>
            {
                GetScriptParameterComponents(scriptParameter, debugMode, debugLogRoot),
                GetSentOptObjComponents(sentOptObj, debugMode, debugLogRoot)
            };

            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            return Du.WithDictionary.JoinListOf(fromAvatarSettings);
        }

        /// <summary></summary>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetScriptParameterComponents(string scriptParameter, string debugMode, string debugLogRoot)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            return AbatabParser.ScriptParameter.Parse(scriptParameter);
        }

        /// <summary></summary>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetSentOptObjComponents(OptionObject2015 sentOptObj, string debugMode, string debugLogRoot)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            return new Dictionary<string, string>
            {
                { "AvatarUserName",   sentOptObj.OptionUserId },
                { "AvatarSystemCode", sentOptObj.OptionUserId },
            };
        }
    }
}
