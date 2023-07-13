// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using System.IO;

namespace Abatab.Core.Logger
{
    /// <summary>Summary goes here.</summary>
    public static class LogContent
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Alert(AbSession abSession, string callPath)
        {
            switch (Path.GetFileName(callPath))
            {
                case "VerifyLocation.cs":
                    return Catalog.Component.ModProgressNote.VfyLocMessage(abSession, "Alert");

                default:
                    return "Invalid";
            }
        }
    }
}