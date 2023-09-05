using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
{
    public void Configure(EntityTypeBuilder <Equipo> builder)
    {
        builder.ToTable("Equipo");
        builder.Property("Nombre")
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Equipos)
        .HasForeignKey(p => p.IdPaisFk);

    }


}
