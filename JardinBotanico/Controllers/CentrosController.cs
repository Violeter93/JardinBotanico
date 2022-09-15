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
    public class CentrosController : Controller
    {
        private readonly MiContexto _context;

        public CentrosController(MiContexto context)
        {
            _context = context;
        }

        // GET: Centros
        public async Task<IActionResult> Index()
        {
              return _context.Centros != null ? 
                          View(await _context.Centros.ToListAsync()) :
                          Problem("Entity set 'MiContexto.Centros'  is null.");
        }

        // GET: Centros/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Centros == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centro == null)
            {
                return NotFound();
            }

            return View(centro);
        }

        // GET: Centros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Centros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCentro,Direccion,Ciudad")] Centro centro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centro);
        }

        // GET: Centros/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Centros == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros.FindAsync(id);
            if (centro == null)
            {
                return NotFound();
            }
            return View(centro);
        }

        // POST: Centros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NombreCentro,Direccion,Ciudad")] Centro centro)
        {
            if (id != centro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroExists(centro.Id.Value))
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
            return View(centro);
        }

        // GET: Centros/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Centros == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centro == null)
            {
                return NotFound();
            }

            return View(centro);
        }

        // POST: Centros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Centros == null)
            {
                return Problem("Entity set 'MiContexto.Centros'  is null.");
            }
            var centro = await _context.Centros.FindAsync(id);
            if (centro != null)
            {
                _context.Centros.Remove(centro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroExists(long id)
        {
          return (_context.Centros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
