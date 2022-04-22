using AccesoADatos.Generico;
using Entidades.Dominio;
using BuscandoMiTrago.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entidades.DataContext;

namespace BuscandoMiTrago.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BuscandoMiTragoDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public HomeController(ILogger<HomeController> logger, BuscandoMiTragoDbContext context, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index(DrinksViewModel model)
        {
            if (model.UF == null)
            {
                model.UF = new UsersFavorites
                {
                    Name = "",
                    Favorites = new List<int>()
                };
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
