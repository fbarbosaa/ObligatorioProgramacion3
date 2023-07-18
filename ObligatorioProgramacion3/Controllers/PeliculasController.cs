using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObligatorioProgramacion3.Datos;
using ObligatorioProgramacion3.Models;

namespace ObligatorioProgramacion3.Controllers
{
    public class PeliculasController : Controller
    {
        public readonly ApplicationDbContext? _context;

        public PeliculasController(ApplicationDbContext? context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Pelicula>? List = _context?.Peliculas?.ToList();
            return View(List);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context?.Peliculas?.Add(pelicula);
                _context?.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
