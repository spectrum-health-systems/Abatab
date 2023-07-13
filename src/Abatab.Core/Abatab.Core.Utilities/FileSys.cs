// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using System.Collections.Generic;
using System.IO;

namespace Abatab.Core.Utility
{
    /// <summary>Summary goes here.</summary>
    public static class FileSys
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        public static void RefreshDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.Delete(directory);
            }

            _=Directory.CreateDirectory(directory);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        public static void RefreshDirectories(List<string> directories)
        {
            foreach (string directory in directories)
            {
                RefreshDirectory(directory);
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        public static void VerifyDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                _=Directory.CreateDirectory(directory);
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Framework.xmldoc' path='XMLDoc/Class[@name="ClassName.cs"]/MethodName/*' />
        public static void VerifyDirectories(List<string> directories)
        {
            foreach (string directory in directories)
            {
                VerifyDirectory(directory);
            }
        }
    }
}