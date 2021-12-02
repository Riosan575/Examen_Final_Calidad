using Final_Examen.DB;
using Final_Examen.Models;
using Final_Examen.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            this.homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            var cuenta = homeRepository.GetAllCuentas();
            return View(cuenta);
        }
    }
}
