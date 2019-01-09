using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // ID
            builder.HasKey(u => u.Id);

            // NOME
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(400);

            // SOBRENOME
            builder.Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(400);

            // EMAIL
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(800);

            // SENHA
            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(800);

            // DATA NASCIMENTO
            builder.Property(u => u.DataNascimento)
                .IsRequired();

            // GENERO
            builder.Property(u => u.Genero)
                .IsRequired();

            // URLFOTO
            builder.Property(u => u.UrlFoto)
                .HasMaxLength(4000);

            // FK IDENTIFICACAO
            builder.HasOne(u => u.Identificacao)
                .WithOne(i => i.Usuario)
                .HasForeignKey<Identificacao>(i => i.UsuarioId);

            // FK POSTAGENS
            builder.HasMany(u => u.Postagens)
                .WithOne(p => p.Usuario);

        }
    }
}
