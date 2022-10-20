﻿// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221020.093428

namespace AbatabData.Core
{
    /// <summary>
    ///
    /// </summary>
    public class Logging
    {
        public string Detail { get; set; }
        public string Mode { get; set; }
        public string EventErrorRoot { get; set; }
        public string EventLostRoot { get; set; }
        public string EventTraceRoot { get; set; }
        public string EventWarningRoot { get; set; }
        public string Root { get; set; }
        public string SessionRoot { get; set; }
        public string WriteDelay { get; set; }
    }
}
