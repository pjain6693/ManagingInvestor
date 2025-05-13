using ManagingInvestor.Models;

namespace ManagingInvestor.Data
{
    public static class DbInitializer
    {
        public static void Seed(InvestorDbContext context)
        {
            //    if (context.Investors.Any()) return;

            //    var funds = new[]
            //    {
            //    new Fund { Name = "Mauris LLP" },
            //    new Fund { Name = "Nullam Velit Fund" },
            //    new Fund { Name = "Ligula Aenean Fund" },
            //    new Fund { Name = "Mauris Sit Amet Fund" },
            //    new Fund { Name = "Ullamcorper Viverra Fund" }
            //};

            //    context.Funds.AddRange(funds);
            //    context.SaveChanges();

            //    var investors = new[]
            //    {
            //    new Investor {
            //        Name = "Keely Newman",
            //        Phone = "1-786-738-4711",
            //        Email = "in.magna@yahoo.com",
            //        Country = "USA",
            //        InvestorFunds = new List<InvestorFund> {
            //            new() { Fund = funds[0] },
            //            new() { Fund = funds[1] }
            //        }
            //    },
            //    new Investor {
            //        Name = "Kimberly Maldonado",
            //        Phone = "(684) 842-2371",
            //        Email = "non.lacinia@outlook.org",
            //        Country = "Spain",
            //        InvestorFunds = new List<InvestorFund> {
            //            new() { Fund = funds[1] }
            //        }
            //    },
            //    new Investor {
            //        Name = "Sean Massey",
            //        Phone = "(548) 250-4693",
            //        Email = "pharetra.quisque.ac@outlook.edu",
            //        Country = "Ireland",
            //        InvestorFunds = new List<InvestorFund> {
            //            new() { Fund = funds[0] },
            //            new() { Fund = funds[2] },
            //            new() { Fund = funds[3] }
            //        }
            //    },
            //    new Investor {
            //        Name = "Nyssa Barr",
            //        Phone = "(673) 581-3597",
            //        Email = "odio@aol.couk",
            //        Country = "Canada",
            //        InvestorFunds = new List<InvestorFund> {
            //            new() { Fund = funds[4] }
            //        }
            //    }
            //};

            //    context.Investors.AddRange(investors);
            //    context.SaveChanges();
   
            var fund1 = new Fund { Id = 1, Name = "Mauris LLP" };
            var fund2 = new Fund { Id = 2, Name = "Nullam Velit Fund" };
            var fund3 = new Fund { Id = 3, Name = "Ligula Aenean Fund" };
            var fund4 = new Fund { Id = 4, Name = "Mauris Sit Amet Fund" };
            var fund5 = new Fund { Id = 5, Name = "Ullamcorper Viverra Fund" };

            context.Funds.AddRange(new List<Fund> { fund1, fund2, fund3, fund4, fund5 });

            context.Investors.AddRange(new List<Investor>
        {
            new Investor
            {
                Id = 1,
                Name = "Keely Newman",
                Phone = "1-786-738-4711",
                Email = "in.magna@yahoo.com",
                Country = "USA",
                InvestorFunds = new List<InvestorFund>
                {
                    new() { Fund = fund1 },
                    new() { Fund = fund2 }
                }
            },
            new Investor
            {
                Id = 2,
                Name = "Kimberly Maldonado",
                Phone = "(684) 842-2371",
                Email = "non.lacinia@outlook.org",
                Country = "Spain",
                InvestorFunds = new List<InvestorFund>
                {
                    new() { Fund = fund2 }
                }
            },
            new Investor
            {
                Id = 3,
                Name = "Sean Massey",
                Phone = "(548) 250-4693",
                Email = "pharetra.quisque.ac@outlook.edu",
                Country = "Ireland",
                InvestorFunds = new List<InvestorFund>
                {
                    new() { Fund = fund1 },
                    new() { Fund = fund3 },
                    new() { Fund = fund4 }
                }
            },
            new Investor
            {
                Id = 4,
                Name = "Nyssa Barr",
                Phone = "(673) 581-3597",
                Email = "odio@aol.couk",
                Country = "Canada",
                InvestorFunds = new List<InvestorFund>
                {
                    new() { Fund = fund5 }
                }
            }
        });
        }
    }
}