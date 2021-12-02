using Final_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.DB.Mapping
{
    public class DetalleMap : IEntityTypeConfiguration<Detalle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Detalle> builder)
        {
            builder.ToTable("Detalle");
            builder.HasKey(o => o.Id);
        }
    }
}
