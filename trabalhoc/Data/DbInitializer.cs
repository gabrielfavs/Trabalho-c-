using GerenciamentoTimes.Models;

namespace GerenciamentoTimes.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Times.Any()) return;

            var time = new Time
            {
                Nome = "Palmeiras",
                Tecnico = "Abel Ferreira",
                Categoria = "Profissional",
                AnoFundacao = 1914,
                Jogadores = new List<Jogador>()
            };

            for (int i = 1; i <= 22; i++)
            {
                time.Jogadores.Add(new Jogador
                {
                    Nome = $"Jogador {i}",
                    Numero = i,
                    Posicao = "Meio-Campo",
                    NumeroDeJogos = 100 + i,
                    NumeroDeTitulos = i % 5
                });
            }

            context.Times.Add(time);
            context.SaveChanges();
        }
    }
}
