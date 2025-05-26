using GerenciamentoTimes.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTimes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
    }
}