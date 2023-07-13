// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using System;
using System.Collections.Generic;

namespace Abatab.Core.Utility
{
    public static class ConvertCollection
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Utility.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static List<string> ArrayToList(string[] arrayToConvert)
        {
            var list = new List<string>();

            foreach (var item in arrayToConvert)
            {
                list.Add(item);
            }

            return list;
        }


        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Utility.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string ListToString(List<string> listToConvert)
        {
            // REVIEW: Remove this abstraction?
            return string.Join(", ", listToConvert);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Utility.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string ListToNewLineString(List<string> listToConvert)
        {
            var toReturn = "";

            foreach (var item in listToConvert)
            {
                toReturn += $"{item}{Environment.NewLine}";
            }

            return toReturn;
        }
    }
}