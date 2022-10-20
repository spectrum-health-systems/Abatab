// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221020.103236

using System.IO;

namespace AbatabSystem
{
    /// <summary>
    /// Logic for general maintenance stuff.
    /// </summary>
    public static class Maintenance
    {
        /// <summary>
        /// Verifies directory exists, and create if not.
        /// </summary>
        public static void VerifyDir(string dir)
        {
            _=Directory.CreateDirectory(dir);
        }
    }
}