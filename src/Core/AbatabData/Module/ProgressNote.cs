// Abatab.AbatabData.Module.ProgressNote.cs b230215.0956
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;

namespace AbatabData.Module
{
    public class ProgressNote
    {
        /// <summary>TBD</summary>
        /// <value></value>
        public string Mode { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string AuthorizedUsers { get; set; }
        public Telehealth TelehealthConfig { get; set; }
    }

    public class Telehealth
    {
        /// <summary>TBD</summary>
        /// <value></value>
        public List<string> ValidServiceChargeCodes { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string ServiceChargeCodeFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundServiceChargeCodeFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string ServiceChargeCodeValue { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public List<string> ValidLocations { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string LocationFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundLocationFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string LocationValue { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundAllRequiredFieldIds { get; set; }
    }


}