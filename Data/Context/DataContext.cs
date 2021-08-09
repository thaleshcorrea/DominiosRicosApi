using Microsoft.EntityFrameworkCore;
using Teste.Data.Configuration;
using Teste.Models;

namespace Teste.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
        DbSet<Cliente> Clientes { get;set; }
        DbSet<NotaFiscal> NotasFiscais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new NotaFiscalConfiguration());
        }
    }
}