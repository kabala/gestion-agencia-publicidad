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
    public class CampanasController : Controller
    {
        private readonly AgenciaContext _context;

        public CampanasController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Campanas
        public async Task<IActionResult> Index()
        {
            var agenciaContext = _context.Campanas.Include(c => c.Cliente);
            return View(await agenciaContext.ToListAsync());
        }

        // GET: Campanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campana = await _context.Campanas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.CampanaId == id);
            if (campana == null)
            {
                return NotFound();
            }

            return View(campana);
        }

        // GET: Campanas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Contacto");
            return View();
        }

        // POST: Campanas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampanaId,ClienteId,Nombre,Presupuesto,FechaInicio")] Campana campana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Contacto", campana.ClienteId);
            return View(campana);
        }

        // GET: Campanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campana = await _context.Campanas.FindAsync(id);
            if (campana == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Contacto", campana.ClienteId);
            return View(campana);
        }

        // POST: Campanas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampanaId,ClienteId,Nombre,Presupuesto,FechaInicio")] Campana campana)
        {
            if (id != campana.CampanaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampanaExists(campana.CampanaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Contacto", campana.ClienteId);
            return View(campana);
        }

        // GET: Campanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campana = await _context.Campanas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.CampanaId == id);
            if (campana == null)
            {
                return NotFound();
            }

            return View(campana);
        }

        // POST: Campanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campana = await _context.Campanas.FindAsync(id);
            if (campana != null)
            {
                _context.Campanas.Remove(campana);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampanaExists(int id)
        {
            return _context.Campanas.Any(e => e.CampanaId == id);
        }
    }
}
