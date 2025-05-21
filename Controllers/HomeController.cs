using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiProyectoPortable.Models;

namespace MiProyectoPortable.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Encuentra tu lugar ideal - Maka House"; // Título para la pestaña del navegador
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
        // ----- NUEVO MÉTODO DE ACCIÓN PARA MISION, VISION Y OBJRTIVOS -----
    public IActionResult MisionVisionObjetivos()
    {
        ViewData["Title"] = "Misión, Visión y Objetivos - Maka House"; // Título para la pestaña del navegador
        return View(); // Esto buscará una vista llamada MisionVisionObjetivos.cshtml
    }

    // ----- NUEVO MÉTODO DE ACCIÓN PARA CATEGORIAS -----
    public IActionResult Categorias()
    {
        ViewData["Title"] = "Categorías de Propiedades - Maka House"; // Título para la pestaña del navegador
        return View(); // Esto buscará una vista llamada Categorias.cshtml
    }

    // ----- NUEVO MÉTODO DE ACCIÓN PARA PROPIEDADES -----
    public IActionResult Propiedades()
    {
        ViewData["Title"] = "Nuestras Propiedades - Maka House"; // Título para la pestaña del navegador
        // Aquí, más adelante, obtendrías la lista de propiedades de tu base de datos
        // y la pasarías a la vista. Por ahora, la dejamos vacía.
        return View(); // Esto buscará una vista llamada Propiedades.cshtml
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
