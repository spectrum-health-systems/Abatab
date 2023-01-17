// Abatab.AbatabData.Module.QuickMedOrder.cs b230117.0859
// Copyright (c) A Pretty Cool Program

namespace AbatabData.Module
{
    /// <summary>Defines the properties for the AbatabData.QuickMedOrderData object, containing the information needed for ModQuickMedOrder functionality.</summary>
    public class QuickMedOrder
    {
        /// <summary>TBD</summary>
        /// <value></value>
        public string Mode { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string AuthorizedUsers { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string ValidOrderTypes { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string DosePercentBoundary { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string DoseMilligramsBoundary { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string PrevDosePrefix { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string PrevDoseSuffix { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string DosageOneFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundDosageOneFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string CurrentDose { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string OrderTypeFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundOrderTypeFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string OrderType { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string LastOrderScheduleFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundLastOrderScheduleFieldId { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string LastOrderScheduleText { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public string LastScheduledDosage { get; set; }

        /// <summary>TBD</summary>
        /// <value></value>
        public bool FoundAllRequiredFieldIds { get; set; }
    }
}