namespace ManagingInvestor.Models
{
    public class Investor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        //public List<InvestorFund> InvestorFunds { get; set; }
        public ICollection<InvestorFund> InvestorFunds { get; set; } = new List<InvestorFund>();
    }
}
