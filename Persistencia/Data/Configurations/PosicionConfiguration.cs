using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PosicionConfiguration : IEntityTypeConfiguration<Posicion>
{
    public void Configure(EntityTypeBuilder <Posicion> builder)
    {
        builder.ToTable("Posicion");
        builder.Property("Nombre")
        .IsRequired()
        .HasMaxLength(50);


    }


}
