using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder <Persona> builder)
    {
        builder.ToTable("Persona");
        builder.Property("Nombre")
        .IsRequired()
        .HasMaxLength(30);

        builder.Property("Apellido")
        .IsRequired()
        .HasMaxLength(30);

        builder.Property("Edad")
        .IsRequired()
        .HasColumnType("int")
        .HasMaxLength(3);

        builder.HasOne(p => p.Equipo)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdEquipoFk);

        builder.HasOne(p => p.Tipo)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoFk);
    
        builder.HasOne(p => p.Jugador)
        .WithOne(p => p.Persona)
        .HasForeignKey<Jugador>(p => p.IdPersonaFk);
    }


}
