// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Utility.FileSys.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;

namespace Abatab.Core.Utility
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class FileSys
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void RefreshDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.Delete(directory);
            }

            _=Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void RefreshDirectories(List<string> directories)
        {
            foreach (string directory in directories)
            {
                RefreshDirectory(directory);
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void VerifyDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                _=Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void VerifyDirectories(List<string> directories)
        {
            foreach (string directory in directories)
            {
                VerifyDirectory(directory);
            }
        }
    }
}