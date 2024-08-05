namespace LoanCalculator.Models
{
    public class LoanResponse
    {
        public decimal BaseInterestPrecentage { get; set; }
        public decimal ExtraPeriodInterestPrecentage { get; set; }
        public decimal BaseTotalAmount { get; set; }
        public decimal ExtraPeriodTotalAmount { get; set; }
        public int ExtraPeriod { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
