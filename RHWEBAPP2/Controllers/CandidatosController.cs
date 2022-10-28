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
    public class CandidatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidatos.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombre,Puesto_Al_Que_Aspira,Departamento,Salario_Al_Que_Aspira,Principales_Competencias,Principales_Capacitaciones,Experiencia_Laboral,Recomendado_Por")] Candidatos candidatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatos);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos.FindAsync(id);
            if (candidatos == null)
            {
                return NotFound();
            }
            return View(candidatos);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombre,Puesto_Al_Que_Aspira,Departamento,Salario_Al_Que_Aspira,Principales_Competencias,Principales_Capacitaciones,Experiencia_Laboral,Recomendado_Por")] Candidatos candidatos)
        {
            if (id != candidatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosExists(candidatos.Id))
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
            return View(candidatos);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatos = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidatos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
