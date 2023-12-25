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
    public class DoktorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doktors
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Index()
        {
              return _context.Doktor != null ? 
                          View(await _context.Doktor.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Doktor'  is null.");
        }
        public async Task<IActionResult> IndexUser()
        {
            return _context.Doktor != null ?
                        View(await _context.Doktor.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Doktor'  is null.");
        }
        public async Task<IActionResult> IndexUserIngilizce()
        {
            return _context.Doktor != null ?
                        View(await _context.Doktor.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Doktor'  is null.");
        }

        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        [Authorize(Roles = "yetkili")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Doktors/Create
        [Authorize(Roles = "yetkili")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorId,DoktorAdi,DoktorSoyadi,uzmanlikAlani,DoktorTelefon")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }
        [Authorize(Roles = "yetkili")]
        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // POST: Doktors/Edit/5
        [Authorize(Roles = "yetkili")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorId,DoktorAdi,DoktorSoyadi,uzmanlikAlani,DoktorTelefon")] Doktor doktor)
        {
            if (id != doktor.DoktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorId))
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
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doktor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doktor'  is null.");
            }
            var doktor = await _context.Doktor.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktor.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
          return (_context.Doktor?.Any(e => e.DoktorId == id)).GetValueOrDefault();
        }
    }
}
