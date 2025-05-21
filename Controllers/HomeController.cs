using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiProyectoPortable.Models;
using MiProyectoPortable.Data; // Asegúrate que este sea el namespace de tu DbContext
using Microsoft.EntityFrameworkCore; // Necesario para ToListAsync y otros métodos de EF Core
using System.Linq; // Necesario para LINQ queries como Where, OrderBy
using System.Threading.Tasks; // Necesario para métodos asíncronos
using System.Collections.Generic; // Necesario para List<T>

namespace MiProyectoPortable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // <--- 1. Añade tu DbContext aquí

        // ----- 2. Modifica el constructor para inyectar ApplicationDbContext -----
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Asigna el DbContext inyectado
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Encuentra tu lugar ideal - Maka House";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MisionVisionObjetivos()
        {
            ViewData["Title"] = "Misión, Visión y Objetivos - Maka House";
            return View();
        }

        public IActionResult Categorias()
        {
            ViewData["Title"] = "Categorías de Propiedades - Maka House";
            return View();
        }

        // ----- 3. MÉTODO DE ACCIÓN PARA PROPIEDADES (MODIFICADO) -----
        public async Task<IActionResult> Propiedades(
            List<string> tipoPropiedad, // Para los checkboxes de tipo de propiedad
            List<string> ciudad,        // Para los checkboxes de ciudad
            List<string> barrio,        // Para los checkboxes de barrio
            int? dormitorios,           // Para el input de dormitorios (mapeado a Habitaciones)
            int? banos,                 // Para el input de baños
            int? cocheras,              // Para el input de cocheras
            string sortOrder)           // Para las opciones de ordenamiento
        {
            ViewData["Title"] = "Nuestras Propiedades - Maka House";

            // Empezamos con una consulta base a todas las propiedades
            IQueryable<Propiedad> query = _context.Propiedades.AsQueryable();

            // Aplicar filtros
            // Nota: El filtro de 'ambientes' del HTML no se incluye aquí porque
            // no hay un campo 'ambientes' claro en el modelo Propiedad que me has mostrado.
            // Si existe, necesitarás añadir la lógica correspondiente.

            if (tipoPropiedad != null && tipoPropiedad.Any())
            {
                // Filtra si la TipoPropiedad de la propiedad está en la lista de tipos seleccionados
                // Asume que los 'value' de tus checkboxes (ej. "departamento", "casa")
                // coinciden con los valores en tu campo Propiedad.TipoPropiedad.
                // Si los values son IDs, la lógica sería diferente.
                query = query.Where(p => tipoPropiedad.Contains(p.TipoPropiedad));
            }

            if (ciudad != null && ciudad.Any())
            {
                // Filtra si la Ubicacion de la propiedad contiene alguna de las ciudades seleccionadas.
                // Esto es una búsqueda simple de subcadena. Para mayor precisión,
                // se necesitaría una estructura de datos más normalizada (Ciudad como entidad separada).
                query = query.Where(p => ciudad.Any(c => p.Ubicacion.Contains(c)));
            }

            if (barrio != null && barrio.Any())
            {
                // Similar al filtro de ciudad, busca si la Ubicacion contiene alguno de los barrios.
                query = query.Where(p => barrio.Any(b => p.Ubicacion.Contains(b)));
            }

            if (dormitorios.HasValue && dormitorios.Value > 0)
            {
                // Asumimos que 'Habitaciones' es el campo en tu modelo Propiedad
                query = query.Where(p => p.Habitaciones >= dormitorios.Value);
            }

            if (banos.HasValue && banos.Value > 0)
            {
                query = query.Where(p => p.Banos >= banos.Value);
            }

            if (cocheras.HasValue && cocheras.Value >= 0) // Puede ser 0 si no tiene cochera
            {
                query = query.Where(p => p.Cocheras >= cocheras.Value);
            }

            // Aplicar ordenamiento
            // ¡IMPORTANTE! Para que el ordenamiento por Precio funcione correctamente como número,
            // la columna 'Precio' en tu base de datos DEBE ser de tipo numérico (REAL o NUMERIC),
            // no TEXT. Si es TEXT, se ordenará alfabéticamente (ej. "10000" vendría antes de "200").
            // Revisa la migración que creó la tabla Propiedades.
            ViewData["CurrentSort"] = sortOrder; // Para mantener el estado del dropdown de ordenamiento en la vista
            switch (sortOrder)
            {
                case "precio-asc":
                    query = query.OrderBy(p => p.Precio);
                    break;
                case "precio-desc":
                    query = query.OrderByDescending(p => p.Precio);
                    break;
                case "fecha-reciente":
                    query = query.OrderByDescending(p => p.FechaPublicacion);
                    break;
                default:
                    query = query.OrderByDescending(p => p.FechaPublicacion); // Orden por defecto
                    break;
            }

            // Ejecutar la consulta y obtener la lista de propiedades
            var propiedadesFiltradas = await query.ToListAsync();

            ViewData["SelectedTipos"] = tipoPropiedad;
            ViewData["SelectedCiudades"] = ciudad;
            ViewData["SelectedBarrios"] = barrio;
            ViewData["DormitoriosValue"] = dormitorios; // Asegúrate que el nombre del parámetro en la vista sea 'dormitorios'
            ViewData["BanosValue"] = banos;             // Asegúrate que el nombre del parámetro en la vista sea 'banos'
            ViewData["CocherasValue"] = cocheras;     // Asegúrate que el nombre del parámetro en la vista sea 'cochera'
            // ViewData["CurrentSort"] = sortOrder; // Ya lo tenías

            // Pasar la lista de propiedades a la vista
            return View(propiedadesFiltradas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         // GET: /Home/Contacto
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        // POST: /Home/Contacto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contacto(ContactViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: aquí podrías guardar en BD, enviar email, etc.
            ViewBag.Message = "¡Gracias por contactarnos! En breve te responderemos.";
            return View();
        }
    }
}