using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JardinBotanico.Models;

namespace JardinBotanico.Controllers
{
    public class PlantasController : Controller
    {
        private readonly MiContexto _context;

        public PlantasController(MiContexto context)
        {
            _context = context;
        }

        // GET: Plantas
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.Plantas.Include(p => p.Jardinero);
            return View(await miContexto.ToListAsync());
        }

        // GET: Plantas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Plantas == null)
            {
                return NotFound();
            }

            var planta = await _context.Plantas
                .Include(p => p.Jardinero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
        }

        // GET: Plantas/Create
        public IActionResult Create()
        {
            ViewData["JardineroId"] = new SelectList(_context.Jardineros, "Id", "Nombre");
            return View();
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCientifico,NombreComun,JardineroId")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JardineroId"] = new SelectList(_context.Jardineros, "Id", "Nombre", planta.JardineroId);
            return View(planta);
        }

        // GET: Plantas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Plantas == null)
            {
                return NotFound();
            }

            var planta = await _context.Plantas.FindAsync(id);
            if (planta == null)
            {
                return NotFound();
            }
            ViewData["JardineroId"] = new SelectList(_context.Jardineros, "Id", "Nombre", planta.JardineroId);
            return View(planta);
        }

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NombreCientifico,NombreComun,JardineroId")] Planta planta)
        {
            if (id != planta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantaExists(planta.Id.Value))
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
            ViewData["JardineroId"] = new SelectList(_context.Jardineros, "Id", "Nombre", planta.JardineroId);
            return View(planta);
        }

        // GET: Plantas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Plantas == null)
            {
                return NotFound();
            }

            var planta = await _context.Plantas
                .Include(p => p.Jardinero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
        }

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Plantas == null)
            {
                return Problem("Entity set 'MiContexto.Plantas'  is null.");
            }
            var planta = await _context.Plantas.FindAsync(id);
            if (planta != null)
            {
                _context.Plantas.Remove(planta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantaExists(long id)
        {
          return (_context.Plantas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
