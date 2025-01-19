using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public required DbSet<PlanoConta> PlanoConta { get; set; }
        public required DbSet<Transacao> Transacao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=tcp:127.0.0.1,1433;Database=myFinance;User Id=admin;Password=abc123;Trusted_Connection=False;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento Pessoa -> Transacao
            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Pessoa)
                .WithMany()
                .HasForeignKey(t => t.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict); // Evita deleção em cascata
        }
    }
}
