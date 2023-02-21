// Abatab.ModCommon.VerifyAccess.cs b230119.0941
// Copyright (c) A Pretty Cool Program

using AbatabData;

using AbatabLogging;

namespace ModCommon
{
    /// <summary>
    ///
    /// </summary>
    public class VerifyAccess
    {
        /// <summary>TBD</summary>
        /// <param name="abatabUser"></param>
        /// <param name="validUsers"></param>
        /// <returns></returns>
        public static bool CheckIfValidUser(string abatabUser, string validUsers)
        {
            // TODO - use string comparison

            return validUsers.Trim().ToLower() == "all" || validUsers.ToLower().Contains(abatabUser.ToLower());

        }

        /// <summary>TBD</summary>
        /// <param name="abatabSession"></param>
        public static void InvalidUser(Session abatabSession)
        {
            LogEvent.Access(abatabSession, $"Invalid {abatabSession.AbatabModule} user.");
            AbatabOptionObject.FinalObj.Finalize(abatabSession);
        }
    }
}