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
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
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
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var pelicula = _context?.Peliculas?.FirstOrDefault(c => c.Id == id);
            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context?.Peliculas?.Update(pelicula);
                _context?.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var pelicula = _context?.Peliculas?.FirstOrDefault(c => c.Id == id);
            if (pelicula != null)
            {
                _context?.Peliculas?.Remove(pelicula);
            }
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
