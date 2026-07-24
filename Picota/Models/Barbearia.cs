namespace Picota.Models
{
    public class Barbearia
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }


        public ICollection<Cliente> Clientes { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }

}