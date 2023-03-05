using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPPSiswaAPI.Data;
using SPPSiswaAPI.Models;

namespace SPPSiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly SPPDbContext _context;

        public HistoriesController(SPPDbContext context)
        {
            _context = context;
        }

        [HttpGet("TotalPayment")]
        public async Task<IActionResult> getTotalPayment(string nisn)
        {
            int count = await _context.Histories.Where(history => history.NISN == nisn && history.TglBayar != null).CountAsync();
            return Ok(count);
        }

        [HttpGet("TotalDebt")]
        public async Task<IActionResult> getTotalDebt(string nisn)
        {
            int count = await _context.Histories.Where(history => history.NISN == nisn && history.TglBayar == null).CountAsync();
            return Ok(count);
        }

        [HttpGet("Years")]
        public async Task<IActionResult> getYears()
        {
            List<SPP> spp = await _context.SPP
                .OrderBy(spp => spp.Tahun)
                .ToListAsync();
            return Ok(spp);
        }

        [HttpPost]
        public async Task<IActionResult> getHistories(string nisn, string tahun, bool? status_bayar)
        {
            List<History> histories;
            if (status_bayar == true)
            {
                histories = await _context.Histories
                        .Where(history => history.NISN == nisn && history.TglBayar != null && history.TahunDibayar == tahun)
                        .ToListAsync();
            } else if (status_bayar == false)
            {
                histories = await _context.Histories
                        .Where(history => history.NISN == nisn && history.TglBayar == null && history.TahunDibayar == tahun)
                        .ToListAsync();
            } else
            {
                histories = await _context.Histories
                        .Where(history => history.NISN == nisn && history.TahunDibayar == tahun)
                        .ToListAsync();
            }

            if (histories != null)
            {
                return Ok(histories);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("RecentHistories")]
        public async Task<IActionResult> getRecentHistories(string nisn)
        {
            List<History> histories;
            histories = await _context.Histories
                .Where(history => history.NISN == nisn && history.TglBayar != null)
                .OrderByDescending(history => history.TglBayar)
                .Take(5)
                .ToListAsync();

            if (histories != null)
            {
                return Ok(histories);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
