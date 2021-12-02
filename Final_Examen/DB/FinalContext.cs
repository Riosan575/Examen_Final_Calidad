using Final_Examen.DB.Mapping;
using Final_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.DB
{
    public class FinalContext: DbContext
    {
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }
        public FinalContext(DbContextOptions<FinalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new DetalleMap());
        }
    }
}
