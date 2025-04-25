using Alura.Adopet.API.Dominio.Entity;
using Microsoft.EntityFrameworkCore;

namespace Alura.Adopet.API.Dados.Context
{
    internal class DataBaseContext: DbContext
    {      

        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options) {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }   
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pet> Pets { get; set; }

    }
}
