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

namespace BuscandoMiTrago.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioGenerico<Category> _repositorioGenerico;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public HomeController(ILogger<HomeController> logger, IRepositorioGenerico<Category> repositorioGenerico, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public IActionResult Index()
        {
            
            return View();
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
