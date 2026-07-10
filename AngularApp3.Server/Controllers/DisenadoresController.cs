using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularApp3.Server.Data;
using AngularApp3.Server.Models;

namespace AngularApp3.Server.Controllers
{
    public class DisenadoresController : Controller
    {
        private readonly AgenciaContext _context;

        public DisenadoresController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Disenadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disenadores.ToListAsync());
        }

        // GET: Disenadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disenador = await _context.Disenadores
                .FirstOrDefaultAsync(m => m.DisenadorId == id);
            if (disenador == null)
            {
                return NotFound();
            }

            return View(disenador);
        }

        // GET: Disenadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisenadorId,Nombre,Especialidad,Email,Telefono")] Disenador disenador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disenador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disenador);
        }

        // GET: Disenadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disenador = await _context.Disenadores.FindAsync(id);
            if (disenador == null)
            {
                return NotFound();
            }
            return View(disenador);
        }

        // POST: Disenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisenadorId,Nombre,Especialidad,Email,Telefono")] Disenador disenador)
        {
            if (id != disenador.DisenadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disenador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisenadorExists(disenador.DisenadorId))
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
            return View(disenador);
        }

        // GET: Disenadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disenador = await _context.Disenadores
                .FirstOrDefaultAsync(m => m.DisenadorId == id);
            if (disenador == null)
            {
                return NotFound();
            }

            return View(disenador);
        }

        // POST: Disenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disenador = await _context.Disenadores.FindAsync(id);
            if (disenador != null)
            {
                _context.Disenadores.Remove(disenador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisenadorExists(int id)
        {
            return _context.Disenadores.Any(e => e.DisenadorId == id);
        }
    }
}
