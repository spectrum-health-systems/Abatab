/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * ModCommon.csproj                                                                                 v0.92.0
 * ConfirmTester.cs                                                                                   b221011.074325
 * --------------------------------------------------------------------------------------------------------
 *
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

namespace ModCommon
{
    public class Confirm
    {
        /// <summary></summary>
        /// <param name="userName"></param>
        /// <param name="testUsers"></param>
        /// <returns></returns>
        public static bool Exectution(string userName, string testUsers)
        {
            return testUsers == "none" || testUsers.Contains(userName);
        }
    }
}
