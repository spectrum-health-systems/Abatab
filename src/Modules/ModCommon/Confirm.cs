// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221019.101024

namespace ModCommon
{
    /// <summary>
    /// Confirms various things.
    /// </summary>
    public static class Verify
    {
        /// <summary>
        /// Confirm that a userName exists in the list of valid userNames.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="validUsers"></param>
        /// <returns></returns>
        public static bool ValidUser(string userName, string validUsers)
        {
            // TODO Add logging functionality.

            return validUsers.Trim().ToLower() == "all" || validUsers.ToLower().Contains(userName.ToLower()); // TODO More efficient way?
        }
    }
}
