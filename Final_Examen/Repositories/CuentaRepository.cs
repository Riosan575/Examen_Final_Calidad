using Final_Examen.DB;
using Final_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.Repositories
{
    public interface ICuentaRepository
    {
        List<Detalle> GetAllDetalles(int id);
        Cuenta GetCuenta(int id);
        Cuenta GetCuentaForDetalle(int id);
        void CrearCuenta(Cuenta cuenta);
        void CrearTransaccion(Detalle detalle);
        void ModificaMontoCuenta(int cuentaId);
    }
    public class CuentaRepository: ICuentaRepository
    {
        private readonly FinalContext context;
        public CuentaRepository(FinalContext context)
        {
            this.context = context;
        }

        public void CrearCuenta(Cuenta cuenta)
        {
            if (cuenta.Categoria == "Propio")
            {
                cuenta.Saldo = cuenta.Saldo;
                cuenta.Limite = 0;
                cuenta.Detalles = new List<Detalle>
                {
                    new Detalle
                    {
                        Categoria = "Ingreso",
                        Fecha = DateTime.Now,
                        Monto = cuenta.Saldo,
                        Descripcion = "Primer monto"
                    }
                };
                context.Cuentas.Add(cuenta);
                context.SaveChanges();
            }
            if (cuenta.Categoria == "Crédito")
            {
                cuenta.Limite = cuenta.Saldo;
                cuenta.Saldo = 0;
                context.Cuentas.Add(cuenta);
                context.SaveChanges();
            }
        }      
        public void CrearTransaccion(Detalle detalle)
        {            
            context.Detalles.Add(detalle);
            context.SaveChanges();
            ModificaMontoCuenta(detalle.IdCuenta);
        }

        public List<Detalle> GetAllDetalles(int id)
        {
            return context.Detalles.Where(o => o.IdCuenta == id).ToList();
        }

        public Cuenta GetCuenta(int id)
        {
            return context.Cuentas.FirstOrDefault(o => o.Id == id);
        }

        public Cuenta GetCuentaForDetalle(int id)
        {
            return context.Cuentas.Where(o => o.Id == id).First();
        }

        public void ModificaMontoCuenta(int cuentaId)
        {
            var cuenta = context.Cuentas
                .Include("Detalles")
                .FirstOrDefault(o => o.Id == cuentaId);

            var total = cuenta.Detalles.Sum(o => o.Monto);
            cuenta.Saldo = total;
            context.SaveChanges();
        }
    }
}
