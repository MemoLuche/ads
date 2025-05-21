// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using MiProyectoPortable.Models;
using System;

namespace MiProyectoPortable.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Propiedad> Propiedades { get; set; }
        // Aquí añadirías otros DbSet para otros modelos si los tienes (ej. Testimonios, etc.)

        // Opcional: Si quieres pre-cargar datos (seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ejemplo de cómo podrías pre-cargar algunas propiedades
            modelBuilder.Entity<Propiedad>().HasData(
                new Propiedad {
                    Id = 1,
                    Titulo = "Casa Moderna en Juriquilla",
                    Descripcion = "Hermosa casa con acabados de lujo y amplio jardín.",
                    Precio = 4500000,
                    TipoOperacion = "Venta",
                    TipoPropiedad = "Casa",
                    Ubicacion = "Juriquilla, Querétaro",
                    Habitaciones = 3,
                    Banos = 2, // Si tu modelo `Propiedad` espera un double o decimal para Baños, usa 2.0 o 2.5 si es necesario
                    MetrosCuadrados = 250,
                    Cocheras = 2,
                    RutaImagenPrincipal = "/images/propiedad-ejemplo-1.jpg",
                    // Ejemplo de fecha fija (elige la que quieras):
                    FechaPublicacion = new DateTime(2024, 5, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                new Propiedad {
                    Id = 2,
                    Titulo = "Departamento Céntrico Ideal para Inversión",
                    Descripcion = "Luminoso departamento de 2 recámaras cerca de todos los servicios.",
                    Precio = 12000,
                    TipoOperacion = "Renta",
                    TipoPropiedad = "Departamento",
                    Ubicacion = "Centro, Querétaro",
                    Habitaciones = 2,
                    Banos = 1, // Igual que arriba, ajusta si es 1.0
                    MetrosCuadrados = 90,
                    Cocheras = 1,
                    RutaImagenPrincipal = "/images/propiedad-ejemplo-2.jpg",
                    // Ejemplo de otra fecha fija:
                    FechaPublicacion = new DateTime(2024, 5, 15, 15, 30, 0, DateTimeKind.Utc)
                }
                // Añade más propiedades de ejemplo aquí
            );
        }
    }
}