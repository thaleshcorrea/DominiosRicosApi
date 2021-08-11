using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Models;

namespace Teste.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.OwnsOne(x => x.Documento,
                doc => {
                    doc.Property(p => p.Numero)
                        .HasMaxLength(20)
                        .HasColumnName("Documento")
                        .IsRequired();
                    doc.Property(p => p.Tipo)
                        .HasColumnName("TipoDocumento")
                        .IsRequired();
                    doc.Ignore(p => p.Notifications);
                    doc.Ignore(p => p.IsValid);
                });
            builder.OwnsOne(x => x.Email,
                email => {
                    email.Property(p => p.Endereco)
                        .HasMaxLength(160)
                        .HasColumnName("Email")
                        .IsRequired();
                    email.Ignore(p => p.Notifications);
                    email.Ignore(p => p.IsValid);
                });            
        }
    }
}