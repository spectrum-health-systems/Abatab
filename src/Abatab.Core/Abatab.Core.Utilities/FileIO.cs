// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using System.IO;
using System.Threading;

namespace Abatab.Core.Utility
{
    /// <summary>Summary goes here.</summary>
    public static class FileIO
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Utility.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void WriteLocal(string filePath, string fileContent, int writeDelay = 0)
        {
            Thread.Sleep(writeDelay);
            File.WriteAllText(filePath, fileContent);
        }
    }
}
