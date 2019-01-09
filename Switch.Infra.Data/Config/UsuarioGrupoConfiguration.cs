using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class UsuarioGrupoConfiguration : IEntityTypeConfiguration<UsuarioGrupo>
    {
        public void Configure(EntityTypeBuilder<UsuarioGrupo> builder)
        {
            // ID
            builder.HasKey(ug => new { ug.UsuarioId, ug.GrupoId});

            // DATA CRIACAO
            builder.Property(ug => ug.DataCriacao)
                .IsRequired();

            // EHADMINISTRADOR
            builder.Property(ug => ug.EhAdministrador)
                .IsRequired();
        }
    }

}