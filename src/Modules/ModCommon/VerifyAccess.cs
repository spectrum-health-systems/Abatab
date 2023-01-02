﻿// Abatab ModCommon 24.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b230102.1026

using AbatabData;
using AbatabLogging;

namespace ModCommon
{
    /// <summary>TBD</summary>
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
