// Du.WithDictionary.cs b230117.0859
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Linq;

namespace Du
{
    /// <summary>
    /// Does various things with Dictionary objects.
    /// </summary>
    public static class WithDictionary
    {
        /// <summary>
        /// Join a list of dictionaries.</summary>
        /// <param name="dictionariesToJoin"></param>
        /// <returns>A single dictionary containing all data from multiple dictionaries.</returns>
        public static Dictionary<string, string> JoinListOf(List<Dictionary<string, string>> dictionariesToJoin)
        {
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var item in dictionariesToJoin)
            {
                item.ToList().ForEach(x => wrkDictionary[x.Key] = x.Value);
            }

            return wrkDictionary;
        }
    }
}