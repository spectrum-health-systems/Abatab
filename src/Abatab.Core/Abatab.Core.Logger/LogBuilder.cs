// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;

namespace Abatab.Core.Logger
{
    /// <summary>Summary goes here.</summary>
    internal static class LogBuilder
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string BuildAlert(AbSession abSession, string assemblyName, string callPath, string callMember)
        {
            switch (assemblyName)
            {
                case "Abatab.Module.ProgressNote":
                    return LogContent.Alert(abSession, callPath);

                default:
                    return "INVALID";
            }
        }
    }
}