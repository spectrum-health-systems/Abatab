// Abatab ModCommon 22.11.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221109.095502

using AbatabData;
using AbatabLogging;

namespace ModCommon
{
    /// <summary>
    ///
    /// </summary>
    public class VerifyAccess
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabUser"></param>
        /// <param name="validUsers"></param>
        /// <returns></returns>
        public static bool CheckIfValidUser(string abatabUser, string validUsers)
        {
            return validUsers.Trim().ToLower() == "all" || validUsers.ToLower().Contains(abatabUser.ToLower());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abatabSession"></param>
        public static void InvalidUser(Session abatabSession)
        {
            LogEvent.Access(abatabSession, $"Invalid {abatabSession.AbatabModule} user.");
            AbatabOptionObject.FinalObj.Finalize(abatabSession);
        }
    }
}
