using Microsoft.AspNetCore.Mvc;
using ObligatorioProgramacion3.Datos;
using ObligatorioProgramacion3.Models;

namespace ObligatorioProgramacion3.Controllers
{
    public class EmpleadosController : Controller
    {
        public readonly ApplicationDbContext? _context;

        public EmpleadosController(ApplicationDbContext? context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Empleado>? List = _context?.Empleados?.ToList();
            return View(List);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context?.Empleados?.Add(empleado);
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
            var pelicula = _context?.Empleados?.FirstOrDefault(c => c.Id == id);
            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context?.Empleados?.Update(empleado);
                _context?.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var empleado = _context?.Empleados?.FirstOrDefault(c => c.Id == id);
            if (empleado != null)
            {
                _context?.Empleados?.Remove(empleado);
            }
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
