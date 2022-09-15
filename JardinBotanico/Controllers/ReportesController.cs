using JardinBotanico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JardinBotanico.Controllers
{
    public class ReportesController : Controller
    {
        private MiContexto ctx;

        public ReportesController(MiContexto ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Index( string? filtro)
        {
            IQueryable<Planta> plantas = ctx.Plantas.Include(x => x.Jardinero).Include(x => x.Jardinero.Centro);
            if (filtro != null)
            {
                plantas = plantas.Where(x => x.Jardinero.Nombre.Contains(filtro) && x.NombreComun.Contains(filtro)
                && x.NombreCientifico.Contains(filtro) && x.Jardinero.Centro.NombreCentro.Contains(filtro));
            }
            ViewBag.filtro = filtro;
            return View(plantas);
        }
    }
}
