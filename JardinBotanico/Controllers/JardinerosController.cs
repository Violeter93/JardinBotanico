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
    public class JardinerosController : Controller
    {
        private readonly MiContexto _context;

        public JardinerosController(MiContexto context)
        {
            _context = context;
        }

        // GET: Jardineros
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.Jardineros.Include(j => j.Centro);
            return View(await miContexto.ToListAsync());
        }

        // GET: Jardineros/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Jardineros == null)
            {
                return NotFound();
            }

            var jardinero = await _context.Jardineros
                .Include(j => j.Centro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jardinero == null)
            {
                return NotFound();
            }

            return View(jardinero);
        }

        // GET: Jardineros/Create
        public IActionResult Create()
        {
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "NombreCentro");
            return View();
        }

        // POST: Jardineros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,CentroId")] Jardinero jardinero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jardinero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "NombreCentro", jardinero.CentroId);
            return View(jardinero);
        }

        // GET: Jardineros/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Jardineros == null)
            {
                return NotFound();
            }

            var jardinero = await _context.Jardineros.FindAsync(id);
            if (jardinero == null)
            {
                return NotFound();
            }
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "NombreCentro", jardinero.CentroId);
            return View(jardinero);
        }

        // POST: Jardineros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nombre,Apellido,CentroId")] Jardinero jardinero)
        {
            if (id != jardinero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jardinero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JardineroExists(jardinero.Id.Value))
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
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "NombreCentro", jardinero.CentroId);
            return View(jardinero);
        }

        // GET: Jardineros/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Jardineros == null)
            {
                return NotFound();
            }

            var jardinero = await _context.Jardineros
                .Include(j => j.Centro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jardinero == null)
            {
                return NotFound();
            }

            return View(jardinero);
        }

        // POST: Jardineros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Jardineros == null)
            {
                return Problem("Entity set 'MiContexto.Jardineros'  is null.");
            }
            var jardinero = await _context.Jardineros.FindAsync(id);
            if (jardinero != null)
            {
                _context.Jardineros.Remove(jardinero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JardineroExists(long id)
        {
          return (_context.Jardineros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
