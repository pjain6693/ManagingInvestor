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
