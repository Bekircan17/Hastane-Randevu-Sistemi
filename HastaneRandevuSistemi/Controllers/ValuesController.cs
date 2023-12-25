using HastaneRandevuSau.Data;
using HastaneRandevuSau.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<ActionResult<IEnumerable<Doktor>>> GetDoktor()
        {
            if(_context.Doktor == null)
            {
                return NotFound();


            }

            var methodSyntax= _context.Doktor.Where(x=>x.DoktorAdi =="Alperen").ToListAsync();
            



            return await methodSyntax;
        }

     

    }
}
