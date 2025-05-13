namespace ManagingInvestor.Models
{
    public class InvestorFund
    {
        public int InvestorId { get; set; }
        public Investor Investor { get; set; }

        public int FundId { get; set; }
        public Fund Fund { get; set; }
    }
}
