﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeiroSite.Models;
using System.Diagnostics;

namespace PrimeiroSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Pagina()
        {
            ViewData["Nome"] = "Jorge";
            ViewData["Idade"] = "35";
            ViewBag.Cpf = "78945515578";
            ViewBag.Rg = "7851552";

            Cachorro doguinho = new Cachorro
            {
                Nome = "Scooby-Doo",
                NomedoDono = "Salsicha",
                Idade = 7,
                IsDocil = true
            };
            return View(doguinho);
        }

        public IActionResult CadastroUsuario()
        {
            return View();
        }
        public IActionResult AuthCadastro(string userName, string senha)
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult AuthLogin(string user, string password)
        {
            if (user == "Admin" && password == "Juquinha")
            {
                return RedirectToAction("LoginEfetuado","Home");
            }
            else
            {
                return RedirectToAction("Pagina", "Home");
            }
        }

        public IActionResult LoginEfetuado()
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
