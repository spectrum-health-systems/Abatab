// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using System.Collections.Generic;

namespace Abatab.Core.Catalog.Key
{
    /// <summary>Pre-defined lists of directories.</summary>
    public static class Directories
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static List<string> Framework(AbSession abSession) => new List<string>()
        {
            abSession.AbatabDataRoot,
            abSession.SessionDataDirectory,
            abSession.PublicDataRoot,
            abSession.AlertLogDirectory,
            abSession.DebugglerLogDirectory
        };

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static List<string> Session(AbSession abSession) => new List<string>()
        {
            abSession.SessionDataDirectory,
            abSession.TraceLogDirectory,
            abSession.WarningLogDirectory
        };
    }
}