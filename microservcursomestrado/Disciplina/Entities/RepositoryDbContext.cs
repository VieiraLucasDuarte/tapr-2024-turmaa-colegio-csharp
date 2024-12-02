using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace microservcursomestrado.Disciplina.Entities
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Horario> Horario { get; set; }

        private IConfiguration _configuration;
        public RepositoryDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
            connectionString: this._configuration["CosmosDBURL"],
            databaseName: this._configuration["CosmosDBDBName"],
            cosmosOptionsAction: options =>
            {
                options.ConnectionMode(ConnectionMode.Gateway);
                options.HttpClientFactory(() => new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                }));
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disciplina>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Disciplina>()
                .ToContainer("disciplina");
            modelBuilder.Entity<Disciplina>()
                .Property(c => c.Id)
                .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Disciplina>()
                .HasPartitionKey(c => c.Id);

            modelBuilder.Entity<Horario>()
            .HasNoDiscriminator()
            .ToContainer("horario")
            .Property(h => h.Id)
            .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Horario>()
                .HasPartitionKey(h => h.IdDisciplina);
        }
    }
}