using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class ProcurandoPorConfiguration : IEntityTypeConfiguration<ProcurandoPor>
    {
        public void Configure(EntityTypeBuilder<ProcurandoPor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(p => p.Usuarios)
                .WithOne(u => u.ProcurandoPor)
                .HasForeignKey(u => u.ProcurandoPorId);

            builder.HasData(
                new StatusRelacionamento() { Id = 1, Descricao = "Não Especificado" },
                new StatusRelacionamento() { Id = 2, Descricao = "Namoro" },
                new StatusRelacionamento() { Id = 3, Descricao = "Amizade" },
                new StatusRelacionamento() { Id = 4, Descricao = "Relacionamento Sério" },
                new StatusRelacionamento() { Id = 5, Descricao = "Apenas Sexo" }
            );
        }
    }
}