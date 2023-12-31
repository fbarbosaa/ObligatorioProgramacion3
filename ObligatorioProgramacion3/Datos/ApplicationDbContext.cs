﻿using Microsoft.EntityFrameworkCore;
using ObligatorioProgramacion3.Models;


namespace ObligatorioProgramacion3.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
        }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Proyeccion> Proyecciones { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
