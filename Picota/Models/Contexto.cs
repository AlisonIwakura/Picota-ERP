using Microsoft.EntityFrameworkCore;


namespace Picota.Models
{
    public class Contexto : DbContext
    {

        public DbSet<Picota.Models.Barbearia> Barbearia { get; set; } = default!;

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Agenda> Agendas { get; set; } = null!;

        public DbSet<Servico> Servicos { get; set; } = null!;

        public DbSet<Barbearia> Barbearias { get; set; } = null!;


    }
}
