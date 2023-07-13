// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Utility.ConvertCollection.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Abatab.Core.Utility
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class ConvertCollection
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static List<string> ArrayToList(string[] arrayToConvert)
        {
            var list = new List<string>();

            foreach (var item in arrayToConvert)
            {
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string ListToString(List<string> listToConvert)
        {
            /* QUESTION
             * Do we need this abstraction?
             */
            return string.Join(", ", listToConvert);
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
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