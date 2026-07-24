using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Picota.Models
{
    // Fornece uma instância do Contexto em tempo de design (migrações/Update-Database)
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            // Connection string usada durante o design-time (ajuste se necessário)
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PicotaDb;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
            return new Contexto(optionsBuilder.Options);
        }
    }
}
