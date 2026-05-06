namespace Odous.Models
{
    public class TreatmentPlan
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; } = "";
        public List<TreatmentPlanItem> Items { get; set; } = new();
    }

    public class TreatmentPlanItem
    {
        public int Id { get; set; }
        public int TreatmentPlanId { get; set; }
        public string ToothNumbers { get; set; } = "";
        public string Procedure { get; set; } = "";
        public string ProcedureVariant { get; set; } = "";
        public decimal PricePerUnit { get; set; }
        public int NumberOfTeeth { get; set; }
        public decimal BasePrice { get; set; }
        public decimal DiscountAmount { get; set; } // Now in rupees, not percentage
        public decimal FinalPrice => BasePrice - DiscountAmount;
        public TreatmentPlan? TreatmentPlan { get; set; }
    }
}