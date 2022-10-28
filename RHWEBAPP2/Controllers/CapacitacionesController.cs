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
    public class CapacitacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CapacitacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Capacitaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Capacitaciones.ToListAsync());
        }

        // GET: Capacitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitaciones = await _context.Capacitaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacitaciones == null)
            {
                return NotFound();
            }

            return View(capacitaciones);
        }

        // GET: Capacitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capacitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Nivel,Fecha_Desde,Fecha_Hasta,Institucion")] Capacitaciones capacitaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacitaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacitaciones);
        }

        // GET: Capacitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitaciones = await _context.Capacitaciones.FindAsync(id);
            if (capacitaciones == null)
            {
                return NotFound();
            }
            return View(capacitaciones);
        }

        // POST: Capacitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Nivel,Fecha_Desde,Fecha_Hasta,Institucion")] Capacitaciones capacitaciones)
        {
            if (id != capacitaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacitaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacitacionesExists(capacitaciones.Id))
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
            return View(capacitaciones);
        }

        // GET: Capacitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitaciones = await _context.Capacitaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacitaciones == null)
            {
                return NotFound();
            }

            return View(capacitaciones);
        }

        // POST: Capacitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capacitaciones = await _context.Capacitaciones.FindAsync(id);
            _context.Capacitaciones.Remove(capacitaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapacitacionesExists(int id)
        {
            return _context.Capacitaciones.Any(e => e.Id == id);
        }
    }
}
