namespace ManagingInvestor.Models
{
    public class Fund
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<InvestorFund> InvestorFunds { get; set; }
        public ICollection<InvestorFund> InvestorFunds { get; set; } = new List<InvestorFund>();
    }
}
