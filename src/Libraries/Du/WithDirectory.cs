﻿// Du
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221019.101024

using System.IO;

namespace Du
{
    /// <summary>
    /// Does various things with system directories.
    /// </summary>
    public static class WithDirectory
    {
        /// <summary>
        /// Verifies a directory exists, and creates it if it does not.
        /// </summary>
        public static void VerifyDir(string dir)
        {
            _=Directory.CreateDirectory(dir);
        }
    }
}