using Microsoft.AspNetCore.Mvc;
using ObligatorioProgramacion3.Datos;
using ObligatorioProgramacion3.Models;

namespace ObligatorioProgramacion3.Controllers
{
    public class SalasController : Controller
    {
        public readonly ApplicationDbContext? _context;

        public SalasController(ApplicationDbContext? context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Sala>? List = _context?.Salas?.ToList();
            return View(List);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context?.Salas?.Add(sala);
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
            var sala = _context?.Salas?.FirstOrDefault(c => c.Id == id);
            return View(sala);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context?.Salas?.Update(sala);
                _context?.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var sala = _context?.Salas?.FirstOrDefault(c => c.Id == id);
            if (sala != null)
            {
                _context?.Salas?.Remove(sala);
            }
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
