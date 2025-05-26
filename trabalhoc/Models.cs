using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTimes.Models
{
    public class Time
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Tecnico { get; set; }
        public string Categoria { get; set; }
        public int AnoFundacao { get; set; }
        public List<Jogador> Jogadores { get; set; }
    }
}