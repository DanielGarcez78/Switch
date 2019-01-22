using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            // ID
            builder.HasKey(g => g.Id);

            // NOME
            builder.Property(g => g.Nome)
                .IsRequired()
                .HasMaxLength(100);

            // DESCRICAO
            builder.Property(g => g.Descricao)
                .IsRequired()
                .HasMaxLength(400);

            // URL DA FOTO
            builder.Property(g => g.UrlFoto)
                .HasMaxLength(2000);

            // FK POSTAGENS
            builder.HasMany(g => g.Postagens)
                .WithOne(p => p.Grupo)
                .HasForeignKey(p => p.GrupoId);

        }
    }

}