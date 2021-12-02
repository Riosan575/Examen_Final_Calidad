using Final_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.DB.Mapping
{
    public class CuentaMap : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuenta");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Detalles)
                .WithOne()
                .HasForeignKey(o => o.IdCuenta);
        }
    }
}
