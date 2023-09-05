using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class JugadorConfiguration : IEntityTypeConfiguration <Jugador>
{
    public void Configure(EntityTypeBuilder<Jugador> builder)
    {
        builder.ToTable("Jugador");
        builder.Property("Dorsal")
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Persona)
        .WithOne(p => p.Jugador)
        .HasForeignKey<Persona>(p => p.IdJugadorFk);

        builder
        .HasMany(p => p.Posiciones)
        .WithMany(p => p.Jugadores)
        .UsingEntity<JugadorPosicion>
        (
            j => j
            .HasOne(p => p.Posicion)
            .WithMany(p => p.JugadorPosiciones),

            j => j
            .HasOne(p => p.Jugador)
            .WithMany(p => p.JugadorPosiciones),
        
            j => j.HasKey(j=> new {j.IdJugadorFk, j.IdPosicionFk})
        );

        
    }


}
