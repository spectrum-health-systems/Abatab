// Abatab.AbatabSystem.Maintenance.cs b230119.0941
// Copyright (c) A Pretty Cool Program

using System.IO;

namespace AbatabSystem
{
    /// <summary>Logic for general maintenance stuff.</summary>
    public static class Maintenance
    {
        /// <summary>Verifies directory exists, and create if not.</summary>
        public static void VerifyDir(string dir)
        {
            _=Directory.CreateDirectory(dir);
        }
    }
}