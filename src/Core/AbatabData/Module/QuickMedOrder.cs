// AbatabData 22.12.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221129.0806

namespace AbatabData.Module
{
    /// <summary>
    /// Defines the properties for the AbatabData.QuickMedOrderData object, containing the information needed for ModQuickMedOrder functionality.
    /// </summary>
    public class QuickMedOrder
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Mode { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string AuthorizedUsers { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string ValidOrderTypes { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string DosePercentBoundary { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string DoseMilligramsBoundary { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string PrevDosePrefix { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string PrevDoseSuffix { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string DosageOneFieldId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool FoundDosageOneFieldId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string CurrentDose { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string OrderTypeFieldId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool FoundOrderTypeFieldId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string OrderType { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string LastOrderScheduleFieldId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool FoundLastOrderScheduleFieldId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string LastOrderScheduleText { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string LastScheduledDosage { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool FoundAllRequiredFieldIds { get; set; }
    }
}