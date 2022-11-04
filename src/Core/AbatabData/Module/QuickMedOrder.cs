// AbatabData 0.97.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221104.075753

namespace AbatabData.Module
{
    /// <summary>
    /// Defines the properties for the AbatabData.QuickMedOrderData object, containing the information needed for ModQuickMedOrder functionality.
    /// </summary>
    public class QuickMedOrder
    {
        public string Mode { get; set; }
        public string ValidUsers { get; set; }
        public string DoseMaxPercentIncrease { get; set; }
        public string PrevDosePrefix { get; set; }
        public string PrevDoseSuffix { get; set; }
        public string DosageOneFieldId { get; set; }
        public bool FoundDosageOneFieldId { get; set; }
        public string CurrentDose { get; set; }
        public string OrderTypeFieldId { get; set; }
        public bool FoundOrderTypeFieldId { get; set; }
        public string OrderType { get; set; }
        public string LastOrderScheduleFieldId { get; set; }
        public bool FoundLastOrderScheduleFieldId { get; set; }
        public string LastOrderScheduleText { get; set; }
        public string LastScheduledDosage { get; set; }
        public bool FoundAllRequiredFieldIds { get; set; }
    }
}