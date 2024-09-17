using ClienteCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
       {
       }        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Endereco).WithOne().HasForeignKey<Cliente>(c => c.EnderecoId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
