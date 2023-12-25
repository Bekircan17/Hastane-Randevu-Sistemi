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

    public class RandevusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Randevus
        [Authorize(Roles = "yetkili")]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Randevu.Include(r => r.Doktor);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexUser()
        {
            var applicationDbContext = _context.Randevu.Include(r => r.Doktor);
            return View(await applicationDbContext.ToListAsync());
        }
         public async Task<IActionResult> IndexUserIngilizce()
        {
            var applicationDbContext = _context.Randevu.Include(r => r.Doktor);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Randevus/Details/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevu == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevu
                .Include(r => r.Doktor)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Randevus/Create
        public IActionResult Create()
        {
            ModelState.Remove("DoktorId");

            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi");
            return View();
        }

        // POST: Randevus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuId,TcNo,HastaAdi,HastaSoyAdi,IletisimNumarası,DoktorId,RandevuAyi,RandevuGunu,RandevuSaati")] Randevu randevu)
        {

            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", randevu.DoktorId);
            _context.Add(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult CreateUserEnglish()
        {
            ModelState.Remove("DoktorId");

            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi");
            return View();
        }

        // POST: Randevus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserEnglish([Bind("RandevuId,TcNo,HastaAdi,HastaSoyAdi,IletisimNumarası,DoktorId,RandevuAyi,RandevuGunu,RandevuSaati")] Randevu randevu)
        {

            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", randevu.DoktorId);
            _context.Add(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // GET: Randevus/Edit/5
        [Authorize(Roles = "yetkili")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevu == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevu.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", randevu.DoktorId);
            return View(randevu);
        }

        // POST: Randevus/Edit/5
        [Authorize(Roles = "yetkili")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuId,TcNo,HastaAdi,HastaSoyAdi,IletisimNumarası,DoktorId,RandevuAyi,RandevuGunu,RandevuSaati")] Randevu randevu)
        {
            if (id != randevu.RandevuId)
            {
                return NotFound();
            }

            ViewData["DoktorId"] = new SelectList(_context.Doktor, "DoktorId", "DoktorAdi", randevu.DoktorId);
            try
            {
                _context.Update(randevu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandevuExists(randevu.RandevuId))
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
        [Authorize(Roles = "yetkili")]
        // GET: Randevus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevu == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevu
                .Include(r => r.Doktor)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }
        // POST: Randevus/Delete/5
        [Authorize(Roles = "yetkili")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Randevu'  is null.");
            }
            var randevu = await _context.Randevu.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevu.Remove(randevu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return (_context.Randevu?.Any(e => e.RandevuId == id)).GetValueOrDefault();
        }
    }
}
