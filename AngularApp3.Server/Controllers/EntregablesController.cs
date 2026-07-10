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
    public class EntregablesController : Controller
    {
        private readonly AgenciaContext _context;

        public EntregablesController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Entregables
        public async Task<IActionResult> Index()
        {
            var agenciaContext = _context.Entregables.Include(e => e.Campana).Include(e => e.Disenador);
            return View(await agenciaContext.ToListAsync());
        }

        // GET: Entregables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregable = await _context.Entregables
                .Include(e => e.Campana)
                .Include(e => e.Disenador)
                .FirstOrDefaultAsync(m => m.EntregableId == id);
            if (entregable == null)
            {
                return NotFound();
            }

            return View(entregable);
        }

        // GET: Entregables/Create
        public IActionResult Create()
        {
            ViewData["CampanaId"] = new SelectList(_context.Campanas, "CampanaId", "Nombre");
            ViewData["DisenadorId"] = new SelectList(_context.Disenadores, "DisenadorId", "Email");
            return View();
        }

        // POST: Entregables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntregableId,CampanaId,DisenadorId,Tipo,FechaEntrega")] Entregable entregable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entregable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampanaId"] = new SelectList(_context.Campanas, "CampanaId", "Nombre", entregable.CampanaId);
            ViewData["DisenadorId"] = new SelectList(_context.Disenadores, "DisenadorId", "Email", entregable.DisenadorId);
            return View(entregable);
        }

        // GET: Entregables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregable = await _context.Entregables.FindAsync(id);
            if (entregable == null)
            {
                return NotFound();
            }
            ViewData["CampanaId"] = new SelectList(_context.Campanas, "CampanaId", "Nombre", entregable.CampanaId);
            ViewData["DisenadorId"] = new SelectList(_context.Disenadores, "DisenadorId", "Email", entregable.DisenadorId);
            return View(entregable);
        }

        // POST: Entregables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntregableId,CampanaId,DisenadorId,Tipo,FechaEntrega")] Entregable entregable)
        {
            if (id != entregable.EntregableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregableExists(entregable.EntregableId))
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
            ViewData["CampanaId"] = new SelectList(_context.Campanas, "CampanaId", "Nombre", entregable.CampanaId);
            ViewData["DisenadorId"] = new SelectList(_context.Disenadores, "DisenadorId", "Email", entregable.DisenadorId);
            return View(entregable);
        }

        // GET: Entregables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregable = await _context.Entregables
                .Include(e => e.Campana)
                .Include(e => e.Disenador)
                .FirstOrDefaultAsync(m => m.EntregableId == id);
            if (entregable == null)
            {
                return NotFound();
            }

            return View(entregable);
        }

        // POST: Entregables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entregable = await _context.Entregables.FindAsync(id);
            if (entregable != null)
            {
                _context.Entregables.Remove(entregable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregableExists(int id)
        {
            return _context.Entregables.Any(e => e.EntregableId == id);
        }
    }
}
