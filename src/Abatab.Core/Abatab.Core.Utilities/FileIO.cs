// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Utility.FileIO.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using System.IO;
using System.Threading;

namespace Abatab.Core.Utility
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class FileIO
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void WriteLocal(string filePath, string fileContent, int writeDelay = 0)
        {
            Thread.Sleep(writeDelay);
            File.WriteAllText(filePath, fileContent);
        }
    }
}
