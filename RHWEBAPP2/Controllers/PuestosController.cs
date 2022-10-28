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
    public class PuestosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PuestosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Puestos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Puestos.ToListAsync());
        }

        // GET: Puestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // GET: Puestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NivelDeRiesgo,Nivel_Minimo_Salario,Nivel_Maximo_Salario,Estado")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestos);
        }

        // GET: Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos.FindAsync(id);
            if (puestos == null)
            {
                return NotFound();
            }
            return View(puestos);
        }

        // POST: Puestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NivelDeRiesgo,Nivel_Minimo_Salario,Nivel_Maximo_Salario,Estado")] Puestos puestos)
        {
            if (id != puestos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestosExists(puestos.Id))
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
            return View(puestos);
        }

        // GET: Puestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestos = await _context.Puestos.FindAsync(id);
            _context.Puestos.Remove(puestos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestosExists(int id)
        {
            return _context.Puestos.Any(e => e.Id == id);
        }
    }
}
