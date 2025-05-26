using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoTimes.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Posicao { get; set; }
        public int NumeroDeJogos { get; set; }
        public int NumeroDeTitulos { get; set; }
        public int TimeId { get; set; }
        public Time Time { get; set; }
    }
}