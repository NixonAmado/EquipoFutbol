using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class TipoNominaConfiguration : IEntityTypeConfiguration<TipoNomina>
{
    public void Configure(EntityTypeBuilder <TipoNomina> builder)
    {
        builder.ToTable("TipoNomina");
        builder.Property("Nombre")
        .IsRequired()
        .HasMaxLength(50);

    }


}
