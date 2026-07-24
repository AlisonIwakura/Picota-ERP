using System.ComponentModel.DataAnnotations.Schema;

namespace Picota.Models
{
    public class Agenda
    {
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public string Status { get; set; }
        // Agendado, Confirmado, Cancelado, Finalizado

        public decimal Valor { get; set; }


        // Cliente
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }

}

