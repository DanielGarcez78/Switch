using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class PostagemConfiguration : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            // ID
            builder.HasKey(p => p.Id);

            // DATA DE PUBLICAÇÃO
            builder.Property(p => p.DataPublicacao)
                .IsRequired();

            // TEXTO
            builder.Property(p => p.Texto)
                .IsRequired()
                .HasMaxLength(4000);

            // FK USUARIO
            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Postagens)
                .HasForeignKey(p => p.UsuarioId);
        }
    }

}