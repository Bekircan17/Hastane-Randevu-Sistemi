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

namespace HastaneRandevuSau.Controllers
{
    [Authorize]
    public class DoktorCalismasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorCalismasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoktorCalismas
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DoktorCalisma.Include(d => d.Doktor);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexUser()
        {
            var applicationDbContext = _context.DoktorCalisma.Include(d => d.Doktor);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexUserIngilizce()
        {
            var applicationDbContext = _context.DoktorCalisma.Include(d => d.Doktor);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: DoktorCalismas/Details/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoktorCalisma == null)
            {
                return NotFound();
            }

            var doktorCalisma = await _context.DoktorCalisma
                .Include(d => d.Doktor)
                .FirstOrDefaultAsync(m => m.CalismaId == id);
            if (doktorCalisma == null)
            {
                return NotFound();
            }

            return View(doktorCalisma);
        }

        // GET: DoktorCalismas/Create
        [Authorize(Roles = "yetkili")]
        public IActionResult Create()
        {
            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi");
            return View();
        }

        // POST: DoktorCalismas/Create
        [Authorize(Roles = "yetkili")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalismaId,DoktorId,Gun,mesaiAraligi")] DoktorCalisma doktorCalisma)
        {
            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", doktorCalisma.DoktorId);
            _context.Add(doktorCalisma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }

        // GET: DoktorCalismas/Edit/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoktorCalisma == null)
            {
                return NotFound();
            }

            var doktorCalisma = await _context.DoktorCalisma.FindAsync(id);
            if (doktorCalisma == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", doktorCalisma.DoktorId);
            return View(doktorCalisma);
        }

        // POST: DoktorCalismas/Edit/5
        [Authorize(Roles = "yetkili")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalismaId,DoktorId,Gun,mesaiAraligi")] DoktorCalisma doktorCalisma)
        {
            if (id != doktorCalisma.CalismaId)
            {
                return NotFound();
            }

            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", doktorCalisma.DoktorId);
            try
                {
                    _context.Update(doktorCalisma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorCalismaExists(doktorCalisma.CalismaId))
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

        // GET: DoktorCalismas/Delete/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoktorCalisma == null)
            {
                return NotFound();
            }

            var doktorCalisma = await _context.DoktorCalisma
                .Include(d => d.Doktor)
                .FirstOrDefaultAsync(m => m.CalismaId == id);
            if (doktorCalisma == null)
            {
                return NotFound();
            }

            return View(doktorCalisma);
        }

        // POST: DoktorCalismas/Delete/5
        [Authorize(Roles = "yetkili")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoktorCalisma == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DoktorCalisma'  is null.");
            }
            var doktorCalisma = await _context.DoktorCalisma.FindAsync(id);
            if (doktorCalisma != null)
            {
                _context.DoktorCalisma.Remove(doktorCalisma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorCalismaExists(int id)
        {
            return (_context.DoktorCalisma?.Any(e => e.CalismaId == id)).GetValueOrDefault();
        }
    }
}
