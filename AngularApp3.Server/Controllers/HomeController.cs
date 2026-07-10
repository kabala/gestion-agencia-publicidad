using System.Diagnostics;
using AngularApp3.Server.Data;
using AngularApp3.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApp3.Server.Controllers;
public class HomeController(AgenciaContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Clientes = await context.Clientes.CountAsync();
        ViewBag.Campanas = await context.Campanas.CountAsync();
        ViewBag.Disenadores = await context.Disenadores.CountAsync();
        ViewBag.Entregables = await context.Entregables.CountAsync();
        ViewBag.Proximos = await context.Entregables.Include(e => e.Campana).Include(e => e.Disenador)
            .OrderBy(e => e.FechaEntrega).Take(5).ToListAsync();
        return View();
    }
    public IActionResult Privacy() => View();
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
