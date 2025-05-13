using ManagingInvestor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ManagingInvestor.Data
{
    public class InvestorDbContext
    {
        //public InvestorDbContext(DbContextOptions<InvestorDbContext> options) : base(options) { }

        //public DbSet<Investor> Investors { get; set; }
        //public DbSet<Fund> Funds { get; set; }
        //public DbSet<InvestorFund> InvestorFunds { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<InvestorFund>()
        //        .HasKey(ifund => new { ifund.InvestorId, ifund.FundId });

        //    modelBuilder.Entity<InvestorFund>()
        //        .HasOne(i => i.Investor)
        //        .WithMany(f => f.InvestorFunds)
        //        .HasForeignKey(i => i.InvestorId);

        //    modelBuilder.Entity<InvestorFund>()
        //        .HasOne(f => f.Fund)
        //        .WithMany(i => i.InvestorFunds)
        //        .HasForeignKey(f => f.FundId);
        //}

        public List<Investor> Investors { get; set; } = new();
        public List<Fund> Funds { get; set; } = new();

        public void Initialize() => DbInitializer.Seed(this);

    }
}
