using ManagingInvestor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ManagingInvestor.Data
{
    public class InvestorDbContext
    {
        public List<Investor> Investors { get; set; } = new();
        public List<Fund> Funds { get; set; } = new();

        public void Initialize() => DbInitializer.Seed(this);

    }
}
