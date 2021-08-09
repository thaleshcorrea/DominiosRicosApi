using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Models;

namespace Teste.Data.Configuration
{
    public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Modelo)
                .IsRequired();
            builder.Property(x => x.Serie)
                .IsRequired();
            builder.Property(x => x.Numero)
                .IsRequired();

            builder.HasOne(nf => nf.Cliente)
                .WithMany(c => c.NotasFiscais)
                .HasForeignKey(nf => nf.ClienteId);
        }
    }
}