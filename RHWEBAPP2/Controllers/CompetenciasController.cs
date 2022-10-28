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
    public class CompetenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Competencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competencias.ToListAsync());
        }

        // GET: Competencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // GET: Competencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] Competencias competencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competencias);
        }

        // GET: Competencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias.FindAsync(id);
            if (competencias == null)
            {
                return NotFound();
            }
            return View(competencias);
        }

        // POST: Competencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] Competencias competencias)
        {
            if (id != competencias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciasExists(competencias.Id))
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
            return View(competencias);
        }

        // GET: Competencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // POST: Competencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competencias = await _context.Competencias.FindAsync(id);
            _context.Competencias.Remove(competencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasExists(int id)
        {
            return _context.Competencias.Any(e => e.Id == id);
        }
    }
}
