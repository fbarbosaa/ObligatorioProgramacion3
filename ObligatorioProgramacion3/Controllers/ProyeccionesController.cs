using Microsoft.AspNetCore.Mvc;
using ObligatorioProgramacion3.Datos;
using ObligatorioProgramacion3.Models;

namespace ObligatorioProgramacion3.Controllers
{
    public class ProyeccionesController : Controller
    {
		public readonly ApplicationDbContext? _context;

		public ProyeccionesController(ApplicationDbContext? context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			List<Proyeccion>? List = _context?.Proyecciones?.ToList();
			return View(List);
		}
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Crear(Proyeccion proyeccion)
		{
			if (ModelState.IsValid)
			{
				_context?.Proyecciones?.Add(proyeccion);
				_context?.SaveChanges();
				// return RedirectToAction("Index");
				return RedirectToAction(nameof(Index));
			}
			return View();
		}
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var proyeccion = _context?.Proyecciones?.FirstOrDefault(c => c.Id == id);
            return View(proyeccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Proyeccion proyeccion)
        {
            if (ModelState.IsValid)
            {
                _context?.Proyecciones?.Update(proyeccion);
                _context?.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View(proyeccion);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var proyeccion = _context?.Proyecciones?.FirstOrDefault(c => c.Id == id);
            if (proyeccion != null)
            {
                _context?.Proyecciones?.Remove(proyeccion);
            }
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
