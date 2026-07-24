using System.Text.Json.Serialization;

namespace Picota.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string? Email { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Relacionamento — agora com valor padrão, deixa de ser "obrigatório"
        public ICollection<Agenda> Agendamentos { get; set; } = new List<Agenda>();
    }
}