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
        public decimal PricePerUnit { get; set; } = 0;
        public int NumberOfTeeth { get; set; } = 1;
        public decimal BasePrice { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal FinalPrice => BasePrice - (BasePrice * DiscountPercent / 100);
        public TreatmentPlan? TreatmentPlan { get; set; }
    }
}