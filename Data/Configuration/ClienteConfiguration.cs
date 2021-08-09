using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Models;

namespace Teste.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CpfCnpj)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}