// b230516.0855

using System.IO;
using Abatab.Core.Catalog.Definition;

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