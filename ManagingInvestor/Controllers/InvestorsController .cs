using ManagingInvestor.Data;
using ManagingInvestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagingInvestor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestorsController : ControllerBase
    {
        //private readonly InvestorDbContext _context;

        //public InvestorsController(InvestorDbContext context)
        //{
        //    _context = context;
        //}

        //// 1. Get all investors with their funds
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var investors = await _context.Investors
        //        .Include(i => i.InvestorFunds)
        //        .ThenInclude(ifund => ifund.Fund)
        //        .ToListAsync();

        //    return Ok(investors);
        //}

        //// 2. Get single investor with their funds
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var investor = await _context.Investors
        //        .Include(i => i.InvestorFunds)
        //        .ThenInclude(ifund => ifund.Fund)
        //        .FirstOrDefaultAsync(i => i.Id == id);

        //    if (investor == null) return NotFound();
        //    return Ok(investor);
        //}

        //// 3. Add fund to investor
        //[HttpPost("{investorId}/add-fund")]
        //public async Task<IActionResult> AddFundToInvestor(int investorId, [FromBody] string fundName)
        //{
        //    var investor = await _context.Investors.Include(i => i.InvestorFunds).FirstOrDefaultAsync(i => i.Id == investorId);
        //    var fund = await _context.Funds.FirstOrDefaultAsync(f => f.Name == fundName);

        //    if (investor == null || fund == null) return NotFound();

        //    if (!investor.InvestorFunds.Any(f => f.FundId == fund.Id))
        //    {
        //        investor.InvestorFunds.Add(new InvestorFund { InvestorId = investor.Id, FundId = fund.Id });
        //        await _context.SaveChangesAsync();
        //    }

        //    return Ok();
        //}

        //// 4. Create new investor
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] Investor investor)
        //{
        //    _context.Investors.Add(investor);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetById), new { id = investor.Id }, investor);
        //}

        //// 5. Delete investor
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var investor = await _context.Investors.FindAsync(id);
        //    if (investor == null) return NotFound();

        //    _context.Investors.Remove(investor);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        private readonly InvestorDbContext _context;

        public InvestorsController(InvestorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetAll()
        {
            return Ok(_context.Investors.Select(i => new
            {
                i.Name,
                i.Phone,
                i.Email,
                i.Country,
                Funds = i.InvestorFunds.Select(f => f.Fund.Name)
            }));
        }

        [HttpGet("{name}")]
        public ActionResult<object> Get(string name)
        {
            var investor = _context.Investors.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (investor == null) return NotFound();

            return Ok(new
            {
                investor.Name,
                investor.Phone,
                investor.Email,
                investor.Country,
                Funds = investor.InvestorFunds.Select(f => f.Fund.Name)
            });
        }

        [HttpPost("{name}/addfund")]
        public IActionResult AddFund(string name, [FromQuery] string fundName)
        {
            var investor = _context.Investors.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            var fund = _context.Funds.FirstOrDefault(f => f.Name.Equals(fundName, StringComparison.OrdinalIgnoreCase));

            if (investor == null || fund == null) return NotFound();

            if (!investor.InvestorFunds.Any(f => f.FundId == fund.Id))
            {
                investor.InvestorFunds.Add(new InvestorFund { Fund = fund });
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult AddInvestor([FromBody] Investor investor)
        {
            investor.Id = _context.Investors.Max(i => i.Id) + 1;
            _context.Investors.Add(investor);
            return CreatedAtAction(nameof(Get), new { name = investor.Name }, investor);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var investor = _context.Investors.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (investor == null) return NotFound();
            _context.Investors.Remove(investor);
            return NoContent();
        }
    }

}
