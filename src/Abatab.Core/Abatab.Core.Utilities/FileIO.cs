// b230516.0855

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
