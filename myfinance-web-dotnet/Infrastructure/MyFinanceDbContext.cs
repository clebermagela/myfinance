using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public required DbSet<PlanoConta> PlanoConta { get; set; }
        public required DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=tcp:127.0.0.1,1433;Database=myFinance;User Id=admin;Password=abc123;Trusted_Connection=False;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}