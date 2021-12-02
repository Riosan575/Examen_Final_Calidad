using Final_Examen.DB;
using Final_Examen.Models;
using Final_Examen.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ICuentaRepository cuentaRepository;
        public CuentaController(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Transacciones(int id)
        {
            ViewBag.transaccion = cuentaRepository.GetAllDetalles(id);
            ViewBag.cuenta = cuentaRepository.GetCuenta(id);
            return View();
        }
        [HttpGet]
        public IActionResult CrearTransaccion(int id)
        {
            ViewBag.cuenta = id;
            return View();
        }
        [HttpPost]
        public IActionResult CrearCuenta(Cuenta cuenta)
        {
            if (ModelState.IsValid && cuenta != null)
            {
                cuentaRepository.CrearCuenta(cuenta);

                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }
        [HttpPost]
        public IActionResult CrearTransaccion(Detalle detalle)
        {
            if (detalle != null) 
            {
                if (detalle.Categoria == "Gasto")
                {
                    detalle.Fecha = DateTime.Now;
                    var cuenta = cuentaRepository.GetCuentaForDetalle(detalle.IdCuenta);
                    if (cuenta.Limite + cuenta.Saldo <= detalle.Monto)
                    {
                        ModelState.AddModelError("Cuenta", "Monto superado");

                    }
                    if (ModelState.IsValid)
                    {
                        detalle.Monto = detalle.Monto * -1;
                        cuentaRepository.CrearTransaccion(detalle);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.cuenta = detalle.IdCuenta;
                        return View("CrearTransaccion");
                    }
                }
                if (detalle.Categoria == "Ingreso")
                {
                    detalle.Fecha = DateTime.Now;
                    cuentaRepository.CrearTransaccion(detalle);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.cuenta = detalle.IdCuenta;
            }
            

            return View("CrearTransaccion");
        }
    }
}
