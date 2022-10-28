using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RHWEBAPP2.Data;
using RHWEBAPP2.Models;

namespace RHWEBAPP2.Controllers
{
    public class IdiomasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdiomasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Idiomas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Idiomas.ToListAsync());
        }

        // GET: Idiomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomas = await _context.Idiomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomas == null)
            {
                return NotFound();
            }

            return View(idiomas);
        }

        // GET: Idiomas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Idiomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] Idiomas idiomas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idiomas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(idiomas);
        }

        // GET: Idiomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomas = await _context.Idiomas.FindAsync(id);
            if (idiomas == null)
            {
                return NotFound();
            }
            return View(idiomas);
        }

        // POST: Idiomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] Idiomas idiomas)
        {
            if (id != idiomas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idiomas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomasExists(idiomas.Id))
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
            return View(idiomas);
        }

        // GET: Idiomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomas = await _context.Idiomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomas == null)
            {
                return NotFound();
            }

            return View(idiomas);
        }

        // POST: Idiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idiomas = await _context.Idiomas.FindAsync(id);
            _context.Idiomas.Remove(idiomas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomasExists(int id)
        {
            return _context.Idiomas.Any(e => e.Id == id);
        }
    }
}
