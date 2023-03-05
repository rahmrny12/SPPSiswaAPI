using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPPSiswaAPI.Data;

namespace SPPSiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SPPDbContext _context;

        public AuthController(SPPDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> loginStudent(string nisn, string nis)
        {
            var siswa = await _context.Students.Where(student => student.NISN == nisn && student.NIS == nis).FirstOrDefaultAsync();

            if (siswa != null)
            {
                return Ok(siswa);
            } else
            {
                return NotFound();
            }
        }
    }
}
