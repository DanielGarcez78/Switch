using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class IdentificacaoConfiguration : IEntityTypeConfiguration<Identificacao>
    {
        public void Configure(EntityTypeBuilder<Identificacao> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.TipoDocumento)
                .IsRequired();

            builder.Property(i => i.Numero)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}