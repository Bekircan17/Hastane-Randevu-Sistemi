using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSau.Data;
using HastaneRandevuSau.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HastaneRandevuSau.Controllers
{
    [Authorize]
    public class IletisimsController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public IletisimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Iletisims
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Index()
        {
              return _context.Iletisim != null ? 
                          View(await _context.Iletisim.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Iletisim'  is null.");
        }

        // GET: Iletisims/Details/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Iletisim == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisim
                .FirstOrDefaultAsync(m => m.IletisimId == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // GET: Iletisims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iletisims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IletisimId,RandevuNumarasi,Mesaj,IletisimNumarasi")] Iletisim iletisim)
        {
           
                _context.Add(iletisim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }
        public IActionResult CreateUserIngilizce()
        {
            return View();
        }

        // POST: Iletisims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserIngilizce([Bind("IletisimId,RandevuNumarasi,Mesaj,IletisimNumarasi")] Iletisim iletisim)
        {
          
                _context.Add(iletisim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         
        }
        [Authorize(Roles = "yetkili")]
        // GET: Iletisims/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Iletisim == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisim.FindAsync(id);
            if (iletisim == null)
            {
                return NotFound();
            }
            return View(iletisim);
        }

        // POST: Iletisims/Edit/5
        [Authorize(Roles = "yetkili")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IletisimId,RandevuNumarasi,Mesaj,IletisimNumarasi")] Iletisim iletisim)
        {
            if (id != iletisim.IletisimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IletisimExists(iletisim.IletisimId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }

        // GET: Iletisims/Delete/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Iletisim == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisim
                .FirstOrDefaultAsync(m => m.IletisimId == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // POST: Iletisims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Iletisim == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Iletisim'  is null.");
            }
            var iletisim = await _context.Iletisim.FindAsync(id);
            if (iletisim != null)
            {
                _context.Iletisim.Remove(iletisim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IletisimExists(string id)
        {
          return (_context.Iletisim?.Any(e => e.IletisimId == id)).GetValueOrDefault();
        }
    }
}
