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
    public class Experiencia_LaboralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Experiencia_LaboralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Experiencia_Laboral
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experiencia_Laboral.ToListAsync());
        }

        // GET: Experiencia_Laboral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia_Laboral = await _context.Experiencia_Laboral
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experiencia_Laboral == null)
            {
                return NotFound();
            }

            return View(experiencia_Laboral);
        }

        // GET: Experiencia_Laboral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiencia_Laboral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,Puesto_Ocupado,Fecha_Desde,Fecha_Hasta,Salario")] Experiencia_Laboral experiencia_Laboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencia_Laboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiencia_Laboral);
        }

        // GET: Experiencia_Laboral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia_Laboral = await _context.Experiencia_Laboral.FindAsync(id);
            if (experiencia_Laboral == null)
            {
                return NotFound();
            }
            return View(experiencia_Laboral);
        }

        // POST: Experiencia_Laboral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,Puesto_Ocupado,Fecha_Desde,Fecha_Hasta,Salario")] Experiencia_Laboral experiencia_Laboral)
        {
            if (id != experiencia_Laboral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencia_Laboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Experiencia_LaboralExists(experiencia_Laboral.Id))
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
            return View(experiencia_Laboral);
        }

        // GET: Experiencia_Laboral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia_Laboral = await _context.Experiencia_Laboral
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experiencia_Laboral == null)
            {
                return NotFound();
            }

            return View(experiencia_Laboral);
        }

        // POST: Experiencia_Laboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiencia_Laboral = await _context.Experiencia_Laboral.FindAsync(id);
            _context.Experiencia_Laboral.Remove(experiencia_Laboral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Experiencia_LaboralExists(int id)
        {
            return _context.Experiencia_Laboral.Any(e => e.Id == id);
        }
    }
}
