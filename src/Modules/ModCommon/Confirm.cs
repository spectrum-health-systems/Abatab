/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * ModCommon.csproj                                                                                 v0.92.0
 * ConfirmTester.cs                                                                          b221011.093856
 * --------------------------------------------------------------------------------------------------------
 *
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

namespace ModCommon
{
    public class Verify
    {
        /// <summary></summary>
        /// <param name="userName"></param>
        /// <param name="validUsers"></param>
        /// <returns></returns>
        public static bool ValidUser(string userName, string validUsers)
        {
            return validUsers.Trim().ToLower() == "all" || validUsers.ToLower().Contains(userName.ToLower());
        }
    }
}
