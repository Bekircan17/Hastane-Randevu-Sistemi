using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HastaneCostumeAPI.Data;
using HastaneCostumeAPI.Models;

namespace HastaneCostumeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IletisimAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Iletisims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iletisim>>> GetIletisim()
        {
          if (_context.Iletisim == null)
          {
              return NotFound();
          }
            return await _context.Iletisim.ToListAsync();
        }


        
    }
}
